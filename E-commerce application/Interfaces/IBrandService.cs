using E_commerce_application.DTOs.Brand.Request;
using E_commerce_application.DTOs.Brand.Response;

namespace E_commerce_application.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDTOs>> GetAllBrand();
        Task UpdateBrand(UpdateBrandDTOs input);  
    }
}
