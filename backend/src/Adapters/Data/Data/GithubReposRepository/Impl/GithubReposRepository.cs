using Domain.Entitites;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            try
            {
                _databaseContext.GithubGitResponse.AddRange(reposList);
                int isSave = await _databaseContext.SaveChangesAsync();
                return isSave > 0;
            }
            catch(Exception ex)
            { 
                return false; 
            }
        }

        public async Task<List<GithubItemResponse>> GetAllSearchedRepos()
        {
            return await _databaseContext.GithubGitResponse.ToListAsync();
        }
    }
}
