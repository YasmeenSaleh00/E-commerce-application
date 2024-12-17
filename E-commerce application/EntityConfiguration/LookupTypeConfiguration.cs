using E_commerce_application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_application.EntityConfiguration
{
    public class LookupTypeConfiguration : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.ToTable("LookupTypes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasMany<LookupItem>().WithOne().HasForeignKey(x => x.LookupTypeId);   

        }
    }
}
