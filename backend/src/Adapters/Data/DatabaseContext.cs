using Microsoft.EntityFrameworkCore;

namespace Data;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

//REFACT
    public virtual DbSet<object> X => Set<object>();
}
