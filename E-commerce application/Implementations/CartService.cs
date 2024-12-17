using E_commerce_application.Context;
using E_commerce_application.DTOs.Cart.Requset;
using E_commerce_application.DTOs.Cart.Response;
using E_commerce_application.Entities;
using E_commerce_application.Helper;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class CartService : ICartService
    {
        private readonly CommerceDbContext _context;
        public CartService(CommerceDbContext context)
        {
            _context = context;
        }
        public async Task CreateCart(string token)
        {
            var userId = int.Parse(TokenHelper.GetPersonIdFromToken(token));

            var existingCart = await _context.Carts
                           .FirstOrDefaultAsync(c => c.UserId == userId);
            if (existingCart == null)
            {
                Cart cart = new Cart()
                {
                    UserId = userId,
                    StatusCartId = 18



                };
                _context.Add(cart);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("You already have Cart ");
            }


        }
        public async Task AddingProductToCart(CreateCartDTOs input)
        {

            if (input != null)
            {
                if (input.ProductId > 0 && input.CartId > 0 && input.Quantity > 0)
                {
                    var cart = await _context.Carts.FirstOrDefaultAsync(z => z.Id == input.CartId);
                    if (cart != null)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == input.ProductId);

                        if (product != null && product.StatusProductId == 8) // التحقق من حالة المنتج
                        {
                            // التحقق من وجود المنتج في السلة
                            var existingCartItem = await _context.CartItems
                                .FirstOrDefaultAsync(ci => ci.CartId == input.CartId && ci.ProductId == input.ProductId);

                            if (existingCartItem != null)
                            {
                                // تحديث الكمية إذا كان المنتج موجودًا
                                existingCartItem.Quantity += input.Quantity;
                                _context.CartItems.Update(existingCartItem);
                            }
                            else
                            {
                                // إضافة المنتج كعنصر جديد في السلة إذا لم يكن موجودًا
                                ShoppingCart shoppingCart = new ShoppingCart()
                                {
                                    ProductId = input.ProductId,
                                    Quantity = input.Quantity,
                                    CartId = input.CartId,
                                };
                                _context.Add(shoppingCart);
                            }

                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            throw new Exception("Product not found or Product is out of stock");
                        }
                    }
                    else
                    {
                        throw new Exception("Cart not found.");
                    }
                }
                else
                {
                    throw new Exception("All input data must be valid.");
                }
            }
            else
            {
                throw new Exception("All Data Are Required");
            }

        }

        public async Task<List<CartItemsDTOs>> AllCartItemByCartId(int CartId)
        {
           if(CartId > 0)
            {
                var result = from li in _context.CartItems
                             join lt in _context.Products
                             on li.ProductId equals lt.Id
                             where li.CartId == CartId
                             select new CartItemsDTOs
                             {
                                 Id = li.Id,    
                                 CartId = li.CartId,
                                NameOfProduct = lt.NameOfProudct,
                                Quantity = li.Quantity,
                                Price = lt.Price,
                                
                             };
                return await result.ToListAsync();
            }
            else
            {
                throw new Exception(" input data  must be valid.");
            }
        }

        public async Task DeleteCartItems(int Id, bool IsDeleted)
        {
            if(Id > 0)
            {
                var result = await _context.CartItems.FirstOrDefaultAsync(x => x.Id == Id);
                if (result != null)
                {
                    result.IsDeleted = IsDeleted;
                    result.ModificationDate = DateTime.Now;
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"No CartItems with the Given Id {Id}");
                }
            }
            else
            {
                throw new Exception(" input data  must be valid.");
            }
          
        }

        public async Task UpdateStatusCart(int Id, int StatusCartId)
        {
            if (Id > 0)
            {
                var result = await _context.Carts.FirstOrDefaultAsync(x => x.Id == Id);
                if (result != null)
                {
                   result.StatusCartId = StatusCartId;
                    result.ModificationDate = DateTime.Now;
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"No Cart with the Given Id {Id}");
                }
            }
            else
            {
                throw new Exception(" input data  must be valid.");
            }
        }

        public async Task UpdateCartItems(int cartId, int productId, int Quantity)
        {
            if(cartId > 0 && Quantity >0 && productId>0)
            {
              
                var result = await _context.CartItems
                           .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);

                if (result != null)
                {
                    result.Quantity = Quantity;
                    result.ModificationDate = DateTime.Now;
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"No CartItem with the Given Id");
                }

            }
            else
            {
                throw new Exception(" input data  must be valid.");
            }
        }
    }
}

