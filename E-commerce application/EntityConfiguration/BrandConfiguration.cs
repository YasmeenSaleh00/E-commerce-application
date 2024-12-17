using E_commerce_application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_application.EntityConfiguration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasIndex(x => x.Name).IsUnique(true);
            builder.HasMany<Product>().WithOne().HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
