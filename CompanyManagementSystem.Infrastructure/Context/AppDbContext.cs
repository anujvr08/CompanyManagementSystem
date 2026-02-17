using System.Data.Entity;
using CompanyManagementSystem.Domain.Entities;
using CompanyManagementSystem.Infrastructure.Configurations;

namespace CompanyManagementSystem.Infrastructure.Context
{
    /// <summary>
    /// Entity Framework 6 DbContext managing the database connection
    /// and entity-to-table mappings.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes the context using the "DefaultConnection" connection string
        /// defined in App.config of the Presentation project.
        /// </summary>
        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
