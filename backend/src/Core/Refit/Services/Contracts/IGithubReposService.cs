using Application.Requests;
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Contracts;

public interface IGithubReposService
{
    Task<IEnumerable<GithubReposResponse>> GetReposGithub(GithubRepoRequest request);
}