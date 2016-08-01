using ShoeStore.Domain.Models;
using ShoeStore.Persistence.EntityConfigurations;
using System.Data.Entity;

namespace ShoeStore.Persistence
{
    public class ShoeStoreDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }

        public ShoeStoreDbContext()
            : base("ShoeStoreConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StoreConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}