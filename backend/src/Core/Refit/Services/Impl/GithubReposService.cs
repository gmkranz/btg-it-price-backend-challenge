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
        //TODO: improve regex
        private const string PATTERN_REGEX = @"[-&]+|&&?,";
        private const string PATTERN_REPLACE_REGEX = ",";


        public Task<GithubReposResponse> GetReposGithub(GithubRepoRequest request)
        {
            string teste = StandardLanguageRequest(request.Languages);

            throw new NotImplementedException();
        }



        public static string StandardLanguageRequest(string languages)
        {
            ValidateLanguagesRequest(languages);

            var query = Regex.Replace(languages, PATTERN_REGEX, PATTERN_REPLACE_REGEX);
            return query.EndsWith(PATTERN_REPLACE_REGEX) ? query.Remove(query.Length - 1) : query;
        }

        public static void ValidateLanguagesRequest(string languages)
        {
            // separa as linguagens por vírgula
            string[] languagesArray = languages.Split(",");

            // se mais de 5 linguagens forem informadas, joga uma exceção

            IsMaxLanguagesRequest(languagesArray);
            if (languagesArray.Length > MAX_LANGUAGES)
            {
                throw new ArgumentException("O número máximo de linguagens permitido é 5.");
            }

            // substitui os caracteres '-' e '&' por ','
            for (int i = 0; i < languagesArray.Length; i++)
            {
                languagesArray[i] = languagesArray[i].Replace("-", ",").Replace("&", ",");
            }

            // junta as linguagens novamente em uma string separada por vírgula
            languages = string.Join(",", languagesArray);
        }

        private static void IsMaxLanguagesRequest(string[] languagesArray)
        {
            if (languagesArray.Length > MAX_LANGUAGES)

                throw new ArgumentException("O número máximo de linguagens permitido é 5.");

        }

        public string GetReposGitheub(GithubRepoRequest request)
        {
            string teste = StandardLanguageRequest(request.Languages);
            return teste;
        }
    }
}
