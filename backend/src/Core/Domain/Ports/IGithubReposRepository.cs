using Domain.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IGithubReposRepository
    {
        Task<bool> CreateSearchedRepos(List<GithubItemResponse> reposList);

        Task<List<GithubItemResponse>> GetAllSearchedRepos();

    }
}
