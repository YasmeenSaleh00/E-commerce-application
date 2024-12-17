using E_commerce_application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_application.EntityConfiguration
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.DescriptionAr).IsUnicode(true);

            builder.HasOne<User>().WithOne().HasForeignKey<Testimonial>(x => x.UserId);
        }
    }
}
