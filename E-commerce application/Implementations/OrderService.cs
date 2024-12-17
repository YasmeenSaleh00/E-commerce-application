using E_commerce_application.Context;
using E_commerce_application.DTOs.Order.Request;
using E_commerce_application.DTOs.Order.Response;
using E_commerce_application.Entities;
using E_commerce_application.Helper;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly CommerceDbContext _dbContext;
        public OrderService(CommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateOrder(CreateOrderDtOs input, string token)
        {
            if (input != null)
            {
                var cart = await _dbContext.Carts.FirstOrDefaultAsync(x => x.Id == input.CartId);
                if (cart != null && cart.StatusCartId == 18)
                {
                    var orderItems = await (from li in _dbContext.CartItems
                                            join lt in _dbContext.Products
                                            on li.ProductId equals lt.Id
                                            where li.CartId == input.CartId
                                            select new
                                            {
                                                li.Quantity,
                                                lt.Price
                                            }).ToListAsync();

                    var userId = TokenHelper.GetPersonIdFromToken(token);
                    Order order = new Order()
                    {
                        UserId = int.Parse(userId),
                        RequsterName = input.RequsterName,
                        Phone = input.Phone,
                        Note = input.Note,
                        Adress = input.Adress,
                        TotalAmount = orderItems.Sum(z => z.Quantity * z.Price),
                        CartId = cart.Id,
                        StatusOrderId = 13,
                        PaymentMethodId = input.PaymentMethodId,

                    };

                    _dbContext.Add(order);
                    await _dbContext.SaveChangesAsync();

                    cart.StatusCartId = 19;
                    _dbContext.Carts.Update(cart);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("No Cart Or Cart is not ordered");
                }


            }
            else
            {
                throw new Exception("You Must Add Data");
            }
        }

        public async Task<List<OrderDTOs>> GetAllOrdersByAdmin()
        {
            var response = from li in _dbContext.Orders
                           select new OrderDTOs
                           {
                               Id = li.Id,
                               CartId = li.CartId,
                               RequsterName = li.RequsterName,
                               Phone = li.Phone,
                               Adress = li.Adress,
                               Note = li.Note,
                               OrderStatus = li.StatusOrderId,
                               PaymentMethodId = li.PaymentMethodId,

                           };
            return await response.ToListAsync();
        }

        public async Task<List<OrderDTOs>> GetOrderById(int Id)
        {
            if (Id > 0)
            {


                var response = from li in _dbContext.Orders
                               where li.Id == Id
                               select new OrderDTOs
                               {
                                   Id = li.Id,
                                   CartId = li.CartId,
                                   RequsterName = li.RequsterName,
                                   Phone = li.Phone,
                                   Adress = li.Adress,
                                   Note = li.Note,
                                   OrderStatus = li.StatusOrderId,
                                   PaymentMethodId = li.PaymentMethodId,

                               };
                return await response.ToListAsync();
            }
            else
            {
                throw new Exception("Not valid Data");
            }

        }

        public async Task UpdateOrderStatus(int Id, int statusOrder)
        {

            if (Id > 0 )
            {
                var re = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);  
                if(re != null)
                {
                  re.StatusOrderId = statusOrder;
                    re.ModificationDate = DateTime.Now;

                    _dbContext.Update(re);
                    await _dbContext.SaveChangesAsync();

                }
                else
                {
                    throw new Exception($"no Order with the given Id {Id}");
                }

            }
            else
            {
                throw new Exception("Not valid Data");
            }
        }
    }
}