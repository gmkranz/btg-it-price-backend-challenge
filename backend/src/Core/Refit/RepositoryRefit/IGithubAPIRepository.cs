

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
using Refit;
using System.Threading.Tasks;

namespace Application

{
    //[Headers("Cache-Control: no-cache", "Accept-Encoding: gzip, deflate, br")]

    public interface IGithubAPIRepository

    {
        ////language=javascript,python&visibility=public&per_page=3&page=1&sort=stars
        //[Get("/search/repositories?q={wordSearh}+language:{languages}&sort=stars&order=desc&page={page}&per_page={perPage}")]
        //Task<IEnumerable<GithubReposResponse>> GetRepos( string wordSearh, string languages, string page, string perPage,
        //    [Header("Content-Type")] string contentType = "application/json",
        //    [Header("User-Agent")] string userAgent = "Insomnia/2021.5.3");


        [Get("/search/repositories?q={wordSearh}+language:{languages}&sort=stars&order=desc&page={page}&per_page={perPage}")]
        [Headers("Cache-Control: no-cache", "User-Agent: Insomnia/2021.5.3")]
        Task<GithubReposResponse> GetRepos(
            string wordSearh,
            string languages,
            string page,
            string perPage,
            [Header("Content-Type")] string contentType = "application/json"
        );

    }
}
