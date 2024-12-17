using E_commerce_application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_application.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasOne<Cart>()
              .WithOne()
              .HasForeignKey<Order>(x => x.CartId);
        }
    }
}
