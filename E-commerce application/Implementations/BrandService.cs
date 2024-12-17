using E_commerce_application.Context;
using E_commerce_application.DTOs.Brand.Request;
using E_commerce_application.DTOs.Brand.Response;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly CommerceDbContext _dbContext1;
        public BrandService(CommerceDbContext dbContext)
        {
            _dbContext1 = dbContext;

        }
        public async Task<List<BrandDTOs>> GetAllBrand()
        {
            var res = from li in _dbContext1.Brands
                      select new BrandDTOs
                      {
                          Id = li.Id,
                          Name = li.Name,
                          CreationDate = li.CreationDate,
                          IsDeleted = li.IsDeleted,

                      };
            return await res.ToListAsync();
            
        }

        public async Task UpdateBrand(UpdateBrandDTOs input)
        {
           if(input != null)
            {
                var res = await _dbContext1.Brands.FirstOrDefaultAsync(x=>x.Id == input.Id);
                if(res != null)
                {
                    if(!string.IsNullOrEmpty(input.Name))
                    {
                      res.Name = input.Name;
                        res.ModificationDate = DateTime.Now;

                    }
                    if(input.IsDeleted != null)
                    {
                        res.IsDeleted =(bool) input.IsDeleted;
                        res.ModificationDate = DateTime.Now;
                    }
                    _dbContext1.Update(res);
                    await _dbContext1.SaveChangesAsync();   

                }
                else
                {
                    throw new Exception($"no Brand with the Given id {input.Id}");
                }

            }
            else
            {
                throw new Exception("you must pass the id");
            }
        }
    }
}
