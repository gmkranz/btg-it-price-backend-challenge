using Application.Requests;
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using System.Threading.Tasks;

namespace Application.Services.Contracts;

public interface IGithubReposService
{
    Task<GithubReposResponse> GetReposGithub(GithubRepoRequest request);
}