using E_commerce_application.DTOs.Cart.Requset;
using E_commerce_application.DTOs.Cart.Response;

namespace E_commerce_application.Interfaces
{
    public interface ICartService
    {
        Task CreateCart( string token);
        Task AddingProductToCart(CreateCartDTOs input);
        Task<List<CartItemsDTOs>> AllCartItemByCartId (int CartId);
        Task DeleteCartItems(int Id , bool IsDeleted);
        Task UpdateStatusCart(int Id , int StatusCart);
        Task UpdateCartItems(int cartId, int productId, int Quantity);
    }
}
