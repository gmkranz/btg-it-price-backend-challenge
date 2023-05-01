using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    public virtual DbSet<GithubItemResponse> GithubGitResponse => Set<GithubItemResponse>();
}
