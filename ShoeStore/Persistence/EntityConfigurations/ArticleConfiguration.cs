using ShoeStore.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoeStore.Persistence.EntityConfigurations
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            Property(a => a.Desription)
                .HasMaxLength(255);

            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.StoreId)
                .IsRequired();
        }
    }
}