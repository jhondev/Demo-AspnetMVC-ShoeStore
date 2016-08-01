using ShoeStore.Domain.Models;
using ShoeStore.Persistence.EntityConfigurations;
using System.Data.Entity;

namespace ShoeStore.Persistence
{
    public class ShoeStoreDbContext : DbContext
    {
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Store> Stores { get; set; }

        public ShoeStoreDbContext()
            : base("ShoeStoreConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StoreConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}