using E_commerce_application.Entities;
using E_commerce_application.EntityConfiguration;
using E_commerce_application.Helper;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Context
{
    public class CommerceDbContext : DbContext
    {
        public DbSet<LookupType> LookupTypes { get; set; }
        public DbSet<LookupItem> LookupItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }    
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }  
        public DbSet<ShoppingCart> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TransactionOrder> Transactions { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }    

        public CommerceDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //pre data
            modelBuilder.Entity<LookupType>().HasData(
           new LookupType { Id = 1, Name = "Nationality" },
           new LookupType { Id = 2, Name = "Gender" },
           new LookupType { Id = 3, Name = "StatusProduct" },
           new LookupType { Id = 4, Name = "TestimonialType" },
           new LookupType { Id = 5, Name = "StatusOrder" },
           new LookupType { Id = 6, Name = "Role" },
           new LookupType { Id =7 , Name="CartStatus"},
            new LookupType { Id = 8, Name = "PaymentMethod" });

            modelBuilder.Entity<LookupItem>().HasData(
           new LookupItem { Id = 1, LookupTypeId = 1, Value = "Jordanian"},
           new LookupItem { Id = 2, LookupTypeId = 1, Value = "Egyptian" },
           new LookupItem { Id = 3, LookupTypeId = 1, Value = "Palestinian" },
           new LookupItem { Id = 4, LookupTypeId = 1, Value = "Saudi" },
           new LookupItem { Id = 5, LookupTypeId = 2, Value = "Male" },
           new LookupItem { Id = 6, LookupTypeId = 2, Value = "Female" },
           new LookupItem { Id = 7, LookupTypeId = 2, Value = "Other" },
           new LookupItem { Id = 8, LookupTypeId = 3, Value = "Available" },
           new LookupItem { Id = 9, LookupTypeId = 3, Value = "Out of Stock" },
           new LookupItem { Id = 10, LookupTypeId = 3, Value = "Discontinued" },
           new LookupItem { Id = 11, LookupTypeId = 4, Value = "User Experience" },
           new LookupItem { Id = 12, LookupTypeId = 4, Value = "Product Feedback" },
           new LookupItem { Id = 13, LookupTypeId = 5, Value = "Pending" },
           new LookupItem { Id = 14, LookupTypeId = 5, Value = "Accepted" },
           new LookupItem { Id = 15, LookupTypeId = 5, Value = "Rejected" },
           new LookupItem { Id = 16, LookupTypeId = 6, Value = "User" },
           new LookupItem { Id = 17, LookupTypeId = 6, Value = "Admin" },
           new LookupItem { Id = 18, LookupTypeId = 7, Value = "Active" },
           new LookupItem { Id = 19, LookupTypeId = 7, Value = "Ordered" },
           new LookupItem { Id = 20, LookupTypeId = 7, Value = "Abandoned" },
           new LookupItem { Id = 21, LookupTypeId = 8, Value = "Credit" },
           new LookupItem { Id = 22, LookupTypeId = 8, Value = "Bank Transfers" },
           new LookupItem { Id = 23, LookupTypeId = 8, Value = "Cash on Delivery" }
           );
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FullName =  "Yasmeen Saleh",
                Email = EncryptionHelper.GenerateSHA384String("yasmeensaleh147@gmail.com"),
                Password = EncryptionHelper.GenerateSHA384String("yas123@t"),
                Phone = "0788205614",
                NationalityId = 1,
                GenderId = 6,
                Adress = "Jordan - Amman",
                UserTypeId = 17
            });
            modelBuilder.ApplyConfiguration(new LookupTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LookupItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfigraution());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());   
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());  
            modelBuilder.ApplyConfiguration(new TestimonialConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfigration());


        }
    }
}
