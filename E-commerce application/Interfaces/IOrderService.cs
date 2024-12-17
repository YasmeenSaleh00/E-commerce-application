using E_commerce_application.DTOs.Order.Request;
using E_commerce_application.DTOs.Order.Response;

namespace E_commerce_application.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderDtOs input, string token);
        Task<List<OrderDTOs>> GetAllOrdersByAdmin();

        Task<List<OrderDTOs>> GetOrderById(int Id);

        Task UpdateOrderStatus(int Id, int statusOrder);
    }
}
