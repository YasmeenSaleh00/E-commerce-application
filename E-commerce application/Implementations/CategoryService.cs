using E_commerce_application.Context;
using E_commerce_application.DTOs.Category.Request;
using E_commerce_application.DTOs.Category.Response;
using E_commerce_application.Entities;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly CommerceDbContext _dbContext1;
        public CategoryService(CommerceDbContext dbContext) { 
            _dbContext1 = dbContext;
        } 
        public async Task CreateCategory(CategoryDTOs input)
        {
            if (input != null)
            {
                if (input.Name != null && input.Description != null)
                {
                    Category category = new Category()
                    {
                        Name = input.Name,
                        Description = input.Description,
                    };
                    await _dbContext1.AddAsync(category);
                    await _dbContext1.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("You must add Name and Description");
                }

            }
            else
            {
                throw new Exception("You must add info");
            }
        }

        public async Task<List<AllCategoryDTOs>> ReadAllCategory()
        {
            var res = from li in _dbContext1.Categories
                      select new AllCategoryDTOs
                      {
                         Name = li.Name,
                         Description = li.Description,
                         CreationDate = li.CreationDate,
                         IsDeleted = li.IsDeleted,  
                         ModificationDate = li.ModificationDate,    

                      };
            return await res.ToListAsync();
        }

        public async Task UpdateCategory(UpdateCategoryDTOs input)
        {
            if (input != null)
            {
                var res = await _dbContext1.Categories.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (res != null)
                {
                    if (!string.IsNullOrEmpty(input.Name))
                    {
                        res.Name = input.Name;
                        res.ModificationDate = DateTime.Now;

                    }
                    if (!string.IsNullOrEmpty(input.Description))
                    {
                        res.Description = input.Description;
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
                    throw new Exception($"No Category with the Given Id {input.Id}");
                }


            }
            else
            {
                throw new Exception("YOU Must pass the id ");
            }


        }
    }
}
