using E_commerce_application.DTOs;
using E_commerce_application.DTOs.Cart.Requset;
using E_commerce_application.DTOs.Category.Request;
using E_commerce_application.DTOs.Order.Request;
using E_commerce_application.DTOs.Testimonial.Request;
using E_commerce_application.DTOs.Users.Request;
using E_commerce_application.Helper;
using E_commerce_application.Implementations;
using E_commerce_application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce_application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly ITestimonialService _testimonialService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
       

        public UserController(IProductService productService, IUserService userService,ITestimonialService testimonialService ,ICartService cartService,IOrderService orderService )
        {
            _productService = productService;
            _userService = userService;
            _testimonialService = testimonialService;   
            _cartService = cartService;
            _orderService = orderService;   
      

        }
        /// <summary>
        /// This EndPoint To return product via Category
        /// </summary>

        [HttpGet]
        [Route("[action]/{CategoryId}")]
        public async Task<IActionResult> GetProductViaCategory([FromRoute] int CategoryId ,[FromHeader] string token)
        {
            Log.Information("Operation of Get product by Category Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Create Testimonial ");
                }
                var response = await _productService.ReadProductByCategory(CategoryId);
                Log.Information($"product by Category  Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available product ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get product by Category{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To return product via Brand
        /// </summary>

        [HttpGet]
        [Route("[action]/{BrandId}")]
        public async Task<IActionResult> GetProductViaBrand([FromRoute] int BrandId, [FromHeader] string token)
        {
            Log.Information("Operation of Get product by Brand Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For get product by brand ");
                }
                var response = await _productService.ReadProductByBrand(BrandId);
                Log.Information($"product by Brand  Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available product ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get product by Brand{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To Get CartItems By CartId
        /// </summary>

        [HttpGet]
        [Route("[action]/{CartId}")]
        public async Task<IActionResult> GetCartItemsByCartId([FromRoute] int CartId, [FromHeader] string token)
        {
            Log.Information("Operation of Get CartItems By CartId Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Get CartItems By CartId ");
                }
                var response =await _cartService.AllCartItemByCartId(CartId) ;
                Log.Information($"CartItems By CartId Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available  CartItems  ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get CartItems By CartId{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        ///<summary>
        ///This end point SignUp
        ///</summary>
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> SignUp([FromBody] CreateAccountDTOs input)
        {
            Log.Information("Operation of SignUp  Has Been Started");
            try
            {
                await _userService.CreateAccount(input);
                Log.Information($"new user Created Successfully  ");
                return StatusCode(201, "New User Created");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When SignUp  {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        ///<summary>
        ///This Endpoint Create Cart
        ///</summary>
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateCart( [FromHeader] string token)
        {
            Log.Information("Operation of  Create Cart Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For  Create Cart ");
                }
                await _cartService.CreateCart(token);   
                Log.Information($"new Cart Created Successfully  ");
                return StatusCode(201, "New cart Created");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Create cart  {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        ///<summary>
        ///This Endpoint Create Cart Item
        ///</summary>
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddingProductToCart([FromHeader] string token , [FromBody] CreateCartDTOs input)
        {
            Log.Information("Operation of  Adding product to cart Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For  Adding product to cart ");
                }
                await _cartService.AddingProductToCart(input);
                Log.Information($"new product Added Successfully  ");
                return StatusCode(201, "New product Added");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Adding product to cart   {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        ///<summary>
        ///This Endpoint Create Testimonial
        ///</summary>
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonialDTOs input ,[FromHeader] string token)
        {
            Log.Information("Operation of Testimonial  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Create Testimonial ");
                }
                await _testimonialService.CreateTestimonial(input ,token); 
                Log.Information($"new Testimonial Created Successfully  ");
                return StatusCode(201, "New Testimonial Created");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Create Testimonial  {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        ///<summary>
        ///This Endpoint Create Order
        ///</summary>
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateOrder([FromHeader] string token,[FromBody] CreateOrderDtOs input)
        {
            Log.Information("Operation of  Create Order  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For  Create Order ");
                }
                await _orderService.CreateOrder(input , token);
                Log.Information($"new Order Created Successfully  ");
                return StatusCode(201, "New Order Created");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When  Create Order {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This endpoint enables the user to reset password
        /// </summary>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] RestPasswordDTOs input,[FromHeader] string token)
        {
            Log.Information("Update User password operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Reset Password ");
                }

                await _userService.ResetPassword(input);
                Log.Information($"Updated Successfully");
                return StatusCode(200, "Updated Successfully");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  User trying  update his password");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }
        /// <summary>
        /// This endpoint enables the user to Delete CartItems
        /// </summary>

        [HttpPut]
        [Route("[action]/{Id}/{IsDeleted}")]
        public async Task<IActionResult> DeleteCartItems( [FromHeader] string token, [FromRoute] int Id , [FromRoute] bool IsDeleted)
        {
            Log.Information("Delete CartItems operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Delete CartItems");
                }

                await _cartService.DeleteCartItems(Id, IsDeleted);  
                Log.Information($"Delete CartItems Successfully");
                return StatusCode(200, "Delete CartItems Successfully");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  User trying to Delete CartItems");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }
        /// <summary>
        /// This endpoint enables the user to Update Quantity Of Product In CartItems
        /// </summary>

        [HttpPut]
        [Route("[action]/{Id}/{ProductId}/{Quantity}")]
        public async Task<IActionResult> UpdateQuantityOfProductInCartItems([FromHeader] string token, [FromRoute] int Id,[FromRoute] int ProductId, [FromRoute] int Quantity )
        {
            Log.Information("Update Quantity Of Product In CartItems operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Update Quantity Of Product In CartItems");
                }

                await _cartService.UpdateCartItems(Id, ProductId, Quantity);
                Log.Information($"Updated Quantity Of Product In CartItems Successfully");
                return StatusCode(200, "Updated Quantity Of Product In CartItems Successfully");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  User trying to Update Quantity Of Product In CartItems");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }
    }
}

    
