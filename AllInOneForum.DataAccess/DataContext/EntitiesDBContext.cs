using AllInOneForum.DataAccess.Configurations;
using AllInOneForum.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AllInOneForum.DataAccess.DataContext
{
    public class EntitiesDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

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
