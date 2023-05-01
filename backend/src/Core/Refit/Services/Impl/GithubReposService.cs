using Application.Requests;
using Application.Services.Contracts;
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services.Impl
{
    public class GithubReposService : IGithubReposService
    {
        private const int MAX_LANGUAGES = 5;
        private const string PATTERN_REGEX = @"[-+&]+";
        private const string PATTERN_REPLACE_REGEX = ",";


        public Task<GithubReposResponse> GetReposGithub(GithubRepoRequest request)
        {
            string teste = StandardLanguageRequest(request.Languages);

            throw new NotImplementedException();
        }

  

        private string StandardLanguageRequest(string languages)
        {
            ValidateLanguagesRequest(languages);

            return Regex.Replace(languages, PATTERN_REGEX, PATTERN_REPLACE_REGEX);
        }

    }
}
