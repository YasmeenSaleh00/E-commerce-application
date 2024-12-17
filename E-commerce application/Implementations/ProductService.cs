using E_commerce_application.Context;
using E_commerce_application.DTOs.Product.Request;
using E_commerce_application.DTOs.Product.Response;
using E_commerce_application.Entities;
using E_commerce_application.EntityConfiguration;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class ProductService : IProductService
    {
        private readonly CommerceDbContext _context;
        public ProductService(CommerceDbContext context)
        {
            _context = context;
        }
        public async Task CreatProduct(CreateProductDTOs input)
        {
            if (input != null)
            {

                var existingBrand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == input.BrandId);


                if (existingBrand == null)
                {

                    Brand newBrand = new Brand()
                    {
                        Name = input.BrandName
                    };


                    _context.Brands.Add(newBrand);
                    await _context.SaveChangesAsync();

                }


                if (!string.IsNullOrEmpty(input.NameOfProudct) )
                {

                 
                    Product product = new Product()
                    {
                     
                        NameOfProudct = input.NameOfProudct,
                        Price = input.Price,
                        CategoryId = input.CategoryId,
                        BrandId = input.BrandId,
                       Quantity = input.Quantity,
                        ManufactureDate = input.ManufactureDate,
                        StatusProductId = 8,
                        ImagePath = input.ImagePath,


                    };


                    _context.Add(product);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("You must add the name of your product.");
                }
            }
            else
            {
                throw new Exception("You must add data to add your product.");
            }
        }

        public async Task<List<ProductDTOs>> ReadProduct()
        {
            var product = from li in _context.Products
                          select new ProductDTOs
                          {
                              Id = li.Id,
                              NameOfProudct = li.NameOfProudct,
                              ImagePath = li.ImagePath,
                              Quantity = li.Quantity,
                              StatusProductId = li.StatusProductId,
                              ManufactureDate = li.ManufactureDate,

                          };
            return await product.ToListAsync();



        }

        public async Task<List<ProductViaBrandDTOs>> ReadProductByBrand(int BrandId)
        {
            var product = from li in _context.Products
                          join lt in _context.Brands
                          on li.BrandId equals lt.Id
                          where li.BrandId == BrandId
                          select new ProductViaBrandDTOs
                          {
                              Id = li.Id,
                              BrandName = lt.Name,
                              NameOfProudct = li.NameOfProudct,
                              ImagePath = li.ImagePath,
                              Quantity = li.Quantity,
                              StatusProductId = li.StatusProductId,
                              ManufactureDate = li.ManufactureDate,


                          };
            return await product.ToListAsync();
        }

        public async Task<List<ProductViaCategoryDTOs>> ReadProductByCategory(int CategoryId)
        {
            var product = from li in _context.Products
                          join lt in _context.Categories
                          on li.CategoryId equals lt.Id
                          where li.CategoryId == CategoryId
                          select new ProductViaCategoryDTOs
                          {
                              Id = li.Id,
                              CategoryName =lt.Name,
                              NameOfProudct = li.NameOfProudct,
                              ImagePath=li.ImagePath,
                              Quantity=li.Quantity,
                              StatusProductId=li.StatusProductId,
                              ManufactureDate=li.ManufactureDate,
                              

                          };
            return await product.ToListAsync();
        }

        public async Task UpdatePriceProduct(int id, float Price)
        {
            var reslt = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (reslt != null)
            {
                if (Price < 0)
                {
                    throw new Exception("Price cannot be negative.");
                }

                reslt.Price = Price;
                reslt.ModificationDate = DateTime.Now;
                _context.Update(reslt);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No product with the given Id {id}");
            }
        }

        public async Task UpdateQuantityProduct(int id, int Quantity)
        {
            
            var reslt = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (reslt != null)
            {
                if (Quantity < 0)
                {
                    throw new Exception("Quantity cannot be negative.");
                }

                reslt.Quantity=Quantity;  
                reslt.ModificationDate = DateTime.Now;
                _context.Update(reslt);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No product with the given Id {id}");
            }

        }
    }
}