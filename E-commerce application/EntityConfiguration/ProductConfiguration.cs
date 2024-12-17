using E_commerce_application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net.Http.Headers;

namespace E_commerce_application.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

          
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasIndex(x => x.NameOfProudct).IsUnique(true);
            builder.HasMany<ShoppingCart>().WithOne().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
