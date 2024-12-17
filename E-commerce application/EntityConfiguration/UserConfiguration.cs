using E_commerce_application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_application.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasIndex(x => x.Phone).IsUnique(true);
            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasMany<Cart>().WithOne().HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
