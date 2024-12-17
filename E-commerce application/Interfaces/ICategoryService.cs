using E_commerce_application.DTOs.Category.Request;
using E_commerce_application.DTOs.Category.Response;

namespace E_commerce_application.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryDTOs input);
        Task UpdateCategory(UpdateCategoryDTOs input);
        Task<List<AllCategoryDTOs>> ReadAllCategory(); 
    }
}
