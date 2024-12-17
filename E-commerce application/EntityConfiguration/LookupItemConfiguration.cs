using E_commerce_application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_application.EntityConfiguration
{
    public class LookupItemConfiguration : IEntityTypeConfiguration<LookupItem>
    {
        public void Configure(EntityTypeBuilder<LookupItem> builder)
        {
            builder.ToTable("LookupItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasMany<Product>().WithOne().HasForeignKey(x=>x.StatusProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<User>().WithOne().HasForeignKey(x => x.UserTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<User>().WithOne().HasForeignKey(x => x.NationalityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<User>().WithOne().HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Cart>().WithOne().HasForeignKey(x => x.StatusCartId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Testimonial>().WithOne().HasForeignKey(x => x.TestimonialTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.StatusOrderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);





        }
    }
}
