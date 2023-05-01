

using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace Application

{
    public interface IGithubAPIRepository
    {
        //language=javascript,python&visibility=public&per_page=3&page=1&sort=stars
        [Get("/repositories?language={languages}&visibility=public&per_page={perPage}&page={page}&sort=stars")]
        Task<GithubReposResponse> GetRepos([FromQuery] string languages, string perPage, string page );

    }
}
