using E_commerce_application.DTOs.Testimonial.Request;
using E_commerce_application.DTOs.Testimonial.Response;
using E_commerce_application.Entities;

namespace E_commerce_application.Interfaces
{
    public interface ITestimonialService
    {
        Task CreateTestimonial(CreateTestimonialDTOs input, string token);
        Task<List<TestimonialDTOs>> ReadAllTestimonials();
    }
}
