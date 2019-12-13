using Microsoft.EntityFrameworkCore;

namespace Portal.Infra.Database.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

            this.Database.EnsureCreated();
        }
    }
}