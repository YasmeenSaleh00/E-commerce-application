using E_commerce_application.DTOs.Product.Request;
using E_commerce_application.DTOs.Product.Response;

namespace E_commerce_application.Interfaces
{
    public interface IProductService
    {
        Task CreatProduct(CreateProductDTOs input);
        Task UpdateQuantityProduct(int id ,int Quantity);
        Task<List<ProductViaCategoryDTOs>> ReadProductByCategory(int CategoryId);
        Task<List<ProductViaBrandDTOs>> ReadProductByBrand(int BrandId);
        Task<List<ProductDTOs>> ReadProduct();
        Task UpdatePriceProduct(int id, float Price);

    }
}
