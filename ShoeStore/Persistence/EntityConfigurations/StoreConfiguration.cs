using ShoeStore.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoeStore.Persistence.EntityConfigurations
{
    public class StoreConfiguration : EntityTypeConfiguration<Store>
    {
        public StoreConfiguration()
        {
            Property(s => s.Adress)
                .HasMaxLength(255);

            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);            
        }
    }
}