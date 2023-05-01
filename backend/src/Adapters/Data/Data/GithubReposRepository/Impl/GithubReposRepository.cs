using Domain.Entitites;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.GithubReposRepository.Impl
{
    public class GithubReposRepository : IGithubReposRepository
    {
        private readonly DatabaseContext _databaseContext;

        public GithubReposRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CreateSearchedRepos(List<GithubItemResponse> reposList)
        {
             _databaseContext.GithubGitResponse.AddRange(reposList);
             int isSave = await _databaseContext.SaveChangesAsync();
            return isSave > 0;
        }
    }
}
