

//using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Refit;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Application

//{
//    [Headers("Cache-Control: no-cache", "Accept-Encoding: gzip, deflate, br")]

//    public interface IGithubAPIRepository
//    {
//        //language=javascript,python&visibility=public&per_page=3&page=1&sort=stars
//        [Get("/repositories?language={languages}&visibility=public&per_page={perPage}&page={page}&sort=stars")]
//        Task<Refit.ApiResponse<IEnumerable<GithubReposResponse>>> GetRepos([FromQuery] string languages, string perPage, string page
//            );


//    }
//}
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application

{
    [Headers("Cache-Control: no-cache", "Accept-Encoding: gzip, deflate, br")]

    public interface IGithubAPIRepository
        //https://api.github.com/search/repositories?q=react+language:javascript+OR+language:typescript&sort=stars&order=desc&page=1&per_page=10
        
    {
        //language=javascript,python&visibility=public&per_page=3&page=1&sort=stars
        [Get("q={wordSearh}+language:{languages}&sort=stars&order=desc&page={page}&per_page={perPage}")]
        Task<IEnumerable<GithubReposResponse>> GetRepos( string wordSearh, string languages, string page, string perPage,
            [Header("Content-Type")] string contentType = "application/json",
            [Header("User-Agent")] string userAgent = "Insomnia/2021.5.3");

    }
}
