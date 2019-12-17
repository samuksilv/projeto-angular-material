using Microsoft.EntityFrameworkCore;
using Portal.Domain.Models;
using Portal.Infra.Database.mapings;

namespace Portal.Infra.Database.Contexts {
    public class AppDbContext : DbContext {

        public DbSet<Company> Company { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Segment> Segment { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<CompanyLogo> CompanyLogo { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfiguration (new AddressMap ());
            modelBuilder.ApplyConfiguration (new CompanyMap ());
            modelBuilder.ApplyConfiguration (new CompanyLogoMap ());
            modelBuilder.ApplyConfiguration (new SegmentMap ());
            modelBuilder.ApplyConfiguration (new ContactMap ());
            modelBuilder.ApplyConfiguration (new UserMap ());

        }

    }
}