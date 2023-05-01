using Domain.Entitites;

namespace Domain.Ports
{
    public interface IGithubReposRepository
    {
        Task<bool> CreateSearchedRepos(List<GithubItemResponse> reposList);
    }
}
