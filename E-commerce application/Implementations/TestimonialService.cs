using E_commerce_application.Context;
using E_commerce_application.DTOs.Testimonial.Request;
using E_commerce_application.DTOs.Testimonial.Response;
using E_commerce_application.Entities;
using E_commerce_application.Helper;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class TestimonialService : ITestimonialService
    {
        private readonly CommerceDbContext _dbContext;
        public TestimonialService(CommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateTestimonial(CreateTestimonialDTOs input, string token)
        {
            if(input != null)
            {
                var userId = TokenHelper.GetPersonIdFromToken(token);
                Testimonial testimonial = new Testimonial()
                {
                    UserId =int.Parse( userId),
                    Description = input.Description,
                    DescriptionAr  =input.DescriptionAr,
                    Rating =input.Rating,
                    TestimonialTypeId = input.TestimonialTypeId,
                };
                _dbContext.Add(testimonial);
                await _dbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception("You Must Add Data To Create Your Testimonial !");
            }
        }

        public async Task<List<TestimonialDTOs>> ReadAllTestimonials()
        {

            var res = from li in _dbContext.Testimonials
                      select new TestimonialDTOs
                      {
                          Id = li.Id,
                          UserId =li.UserId,
                          Description = li.Description,
                          DescriptionAr =li.DescriptionAr,
                          Rating =li.Rating,
                          TestimonialTypeId=li.TestimonialTypeId,
                      };
            return await res.ToListAsync();
            
        }
    }
}
