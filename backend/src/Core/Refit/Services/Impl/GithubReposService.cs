using Application.Requests;
using Application.Services.Contracts;
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services.Impl
{
    public class GithubReposService : IGithubReposService
    {
        private readonly IGithubAPIRepository _repositoryRefit;

        private const int MAX_LANGUAGES = 5;
        //TODO: improve regex
        private const string PATTERN_REGEX = @"[-&]+|&&?,";
        private const string PATTERN_REPLACE_REGEX = ",";

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
                var response = await _repositoryRefit.GetRepos(languagesQuery, request.PerPage.ToString(), request.Page.ToString());
                if (response != null)
                {
                    return response;
                }
                else
                {
                    throw new Exception($"Failed to get Github repositories. Status code: {response}");
                }

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

            var query = Regex.Replace(languages, PATTERN_REGEX, PATTERN_REPLACE_REGEX);
            return query.EndsWith(PATTERN_REPLACE_REGEX) ? query.Remove(query.Length - 1) : query;
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
