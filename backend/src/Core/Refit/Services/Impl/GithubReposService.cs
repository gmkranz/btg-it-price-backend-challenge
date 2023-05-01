using Application.Requests;
using Application.Services.Contracts;
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services.Impl
{
    public class GithubReposService : IGithubReposService
    {
        private readonly IGithubAPIRepository _repositoryRefit;

        private const int MAX_LANGUAGES = 5;
        //TODO: improve regex
        private const string QUERY_LANGUAGE = "language:";
        private const string PATTERN_REPLACE_REGEX = ",";
        private const string OR_OPERATOR = "+OR+";


        public GithubReposService(
            IGithubAPIRepository repositoryRefit
            )
        {
            _repositoryRefit = repositoryRefit;
        }

        public async Task<IEnumerable<GithubReposResponse>> GetReposGithub(GithubRepoRequest request)
        {
            string languagesQuery = StandardLanguageRequest(request.Languages);

            try
            {
                //var response = await _repositoryRefit.GetRepos(languagesQuery, request.PerPage.ToString(), request.Page.ToString());
                //if (response != null)
                //{
                //    return response;
                //}
                //else
                //{
                //    throw new Exception($"Failed to get Github repositories. Status code: {response}");
                //}
                throw new Exception($"Failed to get Github repositories. Sta");

            }
            catch (Exception ex)
            {
                var res = ex;
                throw new Exception("Ocorreu um erro ao acessar a API do Github., Status code: { response.StatusCode }", ex);

            }
            //throw new NotImplementedException();
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
