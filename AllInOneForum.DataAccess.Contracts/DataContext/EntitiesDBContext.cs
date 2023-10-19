using AllInOneForum.DataAccess.Contracts.Configurations;
using AllInOneForum.DataAccess.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace AllInOneForum.DataAccess.Contracts.DataContext
{
    public class EntitiesDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VR8M5QR;Initial Catalog=AllInOneForum;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntitiesDBContext).Assembly);
        }

    }
}
