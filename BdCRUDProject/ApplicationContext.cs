using Microsoft.EntityFrameworkCore;

namespace BdCRUDProject
{
    class ApplicationContext : DbContext
    {
        public DbSet<Worker> workers { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Restaurant;Username=postgres;Password=posSQLpass");
        }
    }

  
}
