using Application.Entities;
using Application.Requests;
using Application.Services.Contracts;
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using Data;
using Domain.Entitites;
using Domain.Exceptions;
using Domain.Ports;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Impl
{
    public class GithubReposService : IGithubReposService
    {
        private readonly IGithubAPIRepository _repositoryRefit;
        private readonly IGithubReposRepository _repository;

        private const int MAX_LANGUAGES = 5;
        //TODO: improve regex
        private const string QUERY_LANGUAGE = "language:";
        private const string PATTERN_REPLACE_REGEX = ",";
        private const string OR_OPERATOR = "+OR+";


        public GithubReposService(
            IGithubAPIRepository repositoryRefit,
            IGithubReposRepository repository
            )
        {
            _repositoryRefit = repositoryRefit;
            _repository = repository;
        }

        public async Task<GithubReposResponse> GetReposGithub(GithubRepoRequest request)
        {
            string languagesQuery = StandardLanguageRequest(request.Languages);

            try
            {
                var responseTask = _repositoryRefit.GetRepos(request.WordSearch, languagesQuery, request.PerPage.ToString(), request.Page.ToString());
                var oldDatasTask = _repository.GetAllSearchedRepos();

                await Task.WhenAll(responseTask, oldDatasTask);

                var response = await responseTask;
                var oldDatas = await oldDatasTask;

                await Upsert(response, oldDatas);
                return response;
            }
            catch (ApiException ex)
            {
                throw new InvalidFileException("Ocorreu um erro ao acessar o Github API.");
            }
        }
        private async Task Upsert(GithubReposResponse response, List<GithubItemResponse> oldDatas)
        {
            var newDatas = response.items.Where(item => !oldDatas.Any(oldItem => oldItem.Id == item.Id)).ToList();

            if (newDatas.Count > 0)
                await RepoDataPersistence(newDatas);


        }

        private async Task RepoDataPersistence(List<ItemsResponse> repoResponse)
        {
            List<GithubItemResponse> validityItems = Geto(repoResponse);

            try
            {
                bool isCreated = await _repository.CreateSearchedRepos(validityItems);
                if (!isCreated)
                    //TODO: add error handling class
                    throw new InvalidFileException("Não foi possível salvar as informações.");
            }
            catch (Exception ex)
            {
                //TODO: add error handling class
                throw new InvalidFileException("Ocorreu um erro ao acessar a API de replicação.");
            }

        }

        private List<GithubItemResponse> Geto(List<ItemsResponse> repoResponse)
        {
            List<GithubItemResponse> githubItemResponseList = new();

            foreach (var repo in repoResponse)
            {
                GithubItemResponse githubItemResponse = new();

                githubItemResponse.Id = repo.Id;
                githubItemResponse.Url = repo.Url;
                githubItemResponse.Name = repo.Name;
                githubItemResponse.Score = repo.Score;
                githubItemResponse.Description = repo.Description;
                githubItemResponse.Full_name = repo.Full_name;

                githubItemResponseList.Add(githubItemResponse);
            }
            return githubItemResponseList;
        }

        public static string StandardLanguageRequest(string languages)
        {
            ValidateLanguagesRequest(languages);

            if (languages.EndsWith(PATTERN_REPLACE_REGEX))
                languages = languages.Remove(languages.Length - 1);

            string[] listLanguages = languages.Split(PATTERN_REPLACE_REGEX);

            if (listLanguages.Length == 1)
            {
                return $"{QUERY_LANGUAGE}{languages}";
            }

            string query = "";

            for (int i = 0; i < listLanguages.Length; i++)
            {
                query += QUERY_LANGUAGE + listLanguages[i];

                if (i < listLanguages.Length - 1)
                {
                    query += OR_OPERATOR;
                }
            }
            return query;
        }

        public static void ValidateLanguagesRequest(string languages)
        {
            string[] languagesArray = languages.Split(",");

            IsMaxLanguagesRequest(languagesArray);
        }

        public static void IsMaxLanguagesRequest(string[] languagesArray)
        {
            if (languagesArray.Length > MAX_LANGUAGES)

                throw new ArgumentException("O número máximo de linguagens permitido é 5.");

        }
    }
}
