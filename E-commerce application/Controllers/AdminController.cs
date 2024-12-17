using E_commerce_application.DTOs.Brand.Request;
using E_commerce_application.DTOs.Category.Request;
using E_commerce_application.DTOs.Lookups.Request;
using E_commerce_application.DTOs.Product.Request;
using E_commerce_application.DTOs.Transaction.Request;
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
    public class AdminController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService1;
        private readonly IUserService _userService;
        private readonly ITestimonialService _testimonialService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;   
        private readonly ITransactionsService _transactionService;
     
        public AdminController(ILookupService lookupService ,ICategoryService categoryService ,IBrandService brandService ,IProductService productService ,IUserService userService , ITestimonialService testimonialService ,ICartService cartService ,IOrderService orderService ,ITransactionsService transactionsService)
        {
            _lookupService = lookupService;
            _categoryService = categoryService; 
            _brandService = brandService;
            _productService1 = productService;
            _userService = userService;
            _testimonialService = testimonialService;
            _cartService = cartService; 
            _orderService = orderService;
            _transactionService = transactionsService;
        }
        /// <summary>
        /// This EndPoint To Show All LookupTypes 
        /// </summary>
        [HttpGet]
        [Route("[action]")]
      
        public async Task<IActionResult> ReadLookupType([FromHeader] string token)
        {
            Log.Information("Operation of Get Lookup Types Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Get Lookup Types ");
                }
                var response = await _lookupService.ReadLookupType();
                Log.Information($"Lookup Types  Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Lookup Types");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Lookup Types {ex.Message}");
                return StatusCode(500, ex.Message);
            }

            }

        /// <summary>
        /// This EndPoint To Show All LookupItems 
        /// </summary>
        [HttpGet]
        [Route("[action]/{LookupTypeId}")]
      
        public async Task<IActionResult> GetLookupItems([FromHeader] string token,[FromRoute] int LookupTypeId )
        {
            Log.Information("Operation of Get Lookup Items Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For  Get Lookup Items ");
                }
                var response = await _lookupService.GetLookupItem(LookupTypeId);
                Log.Information($"Lookup Items  Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Lookup Items");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Lookup Items {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To Show All Category
        /// </summary>
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetCategory([FromHeader] string token)
        {
            Log.Information("Operation of Get Category Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Get Category ");
                }
                var response = await _categoryService.ReadAllCategory();
                Log.Information($"Category  Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Category");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Category{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To Show All Brand
        /// </summary>
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetBrand()
        {
            Log.Information("Operation of Get Brand Has Been Started");
            try
            {
                var response = await _brandService.GetAllBrand();
                Log.Information($"Brand  Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Brand");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Brand{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To return product
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProduct()
        {
            Log.Information("Operation of Get product  Has Been Started");
            try
            {
                var response = await _productService1.ReadProduct();
                Log.Information($"product   Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available product ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get product{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }

        /// <summary>
        /// This EndPoint To return All user Profile
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers([FromHeader] string token  )
        {
            Log.Information("Operation of Get user  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For  Get All Users ");
                }
                var response = await _userService.GetUserProfile();
                Log.Information($"user   Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available user ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get user{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To return All user Order
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllOrders([FromHeader] string token)
        {
            Log.Information("Operation of Get user Order  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For  Get All Orders ");
                }
                var response = await _orderService.GetAllOrdersByAdmin();
                Log.Information($"Order   Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Order ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get user{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To return  user Order
        /// </summary>

        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetOrderById([FromHeader] string token , [FromRoute] int Id)
        {
            Log.Information("Operation of Get user Order  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For  Get  Order ");
                }
                var response = await _orderService.GetOrderById(Id);
                Log.Information($"Order   Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Order ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get user{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To return All Transactions
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTransactions([FromHeader] string token)
        {
            Log.Information("Operation of Get All Transactions  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For  Get All Transactions ");
                }
                var response = await _transactionService.ReadAllTransaction();
                Log.Information($"All Transactions   Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Transactions ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get All Transactions{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To return All users Testimonial
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTestimonials([FromHeader] string token)
        {
            Log.Information("Operation of Get Testimonials  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Get Testimonials ");
                }
                var response = await _testimonialService.ReadAllTestimonials(); 
                Log.Information($"Testimonials   Return  {response.Count} from DB");
                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Testimonials ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Testimonials{ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        ///<summary>
        ///This end point to add new category
        ///</summary>
        [HttpPost]
        [Route("[action]")]
        
        public async Task<IActionResult> CreateCategory([FromHeader] string token, [FromBody]CategoryDTOs input)
        {
            Log.Information("Operation of Create Category  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Create Category ");
                }
                await _categoryService.CreateCategory(input);
                Log.Information($"Category Created Successfully  ");
                return StatusCode(201, "Created");

            }
            catch(Exception ex)
            {
                Log.Error($"An Error Was Occurred When create Category  {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        ///<summary>
        ///This end point to add new Product
        ///</summary>
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateProduct([FromHeader] string token, [FromBody] CreateProductDTOs input)
        {
            Log.Information("Operation of Create Product  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Create Product ");
                }
                await _productService1.CreatProduct(input);
                Log.Information($"Product Created Successfully  ");
                return StatusCode(201, "Created");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When create Product  {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        ///<summary>
        ///This end point to add new Transaction
        ///</summary>
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateTransaction([FromHeader] string token, [FromBody] CreateTransactionDTO input)
        {
            Log.Information("Operation of Create Transaction  Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Create Transaction ");
                }
                await _transactionService.CreateTransaction(input);
                Log.Information($"Transaction Created Successfully  ");
                return StatusCode(201, "Created Transaction");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When create Transaction  {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }




        /// <summary>
        /// This EndPoint To update value for lookup item
        /// </summary>
        [HttpPut]
        [Route("[action]")]
      
        public async Task<IActionResult> UpdateLookupItems([FromHeader] string token, [FromBody] UpdateLookupItemDTO input)
        {
            Log.Information("Operation of Update Lookup Items Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Update Lookup Items ");
                }

                await _lookupService.UpdateLookupItem(input);
                Log.Information($"Lookup Items  Updated Successfully  ");
                return StatusCode(200, "Updated successfully");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update LookupItem Info {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }

        /// <summary>
        /// This EndPoint To update Category info
        /// </summary>
        [HttpPut]
        [Route("[action]")]
    
        public async Task<IActionResult> UpdateCategory([FromHeader] string token, [FromBody] UpdateCategoryDTOs input)
        {
            Log.Information("Operation of Update Category Has Been Started");
            try
            {

                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Update Category ");
                }
                await _categoryService.UpdateCategory(input);
                Log.Information($"Category  Updated Successfully  ");
                return StatusCode(200, "Updated successfully");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update Category Info {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To update Brand info
        /// </summary>
        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateBrand([FromHeader] string token, [FromBody] UpdateBrandDTOs input)
        {
            Log.Information("Operation of Update Brand Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Update Brand");
                }

                await _brandService.UpdateBrand(input);
                Log.Information($"Brand  Updated Successfully  ");
                return StatusCode(200, "Updated successfully");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update Brand Info {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To update Product Quantity
        /// </summary>
        [HttpPut]
        [Route("[action]/{id}/{Quantity}")]

        public async Task<IActionResult> UpdateQuantityOfProduct([FromHeader] string token,[FromRoute] int id , [FromRoute] int Quantity)
        {
            Log.Information("Operation of Update Product Quantity Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Update Product Quantity ");
                }

                await _productService1.UpdateQuantityProduct(id, Quantity); 
                Log.Information($"Product Quantity  Updated Successfully  ");
                return StatusCode(200, "Updated successfully");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update Product Quantity {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To update Product Price
        /// </summary>
        [HttpPut]
        [Route("[action]/{id}/{Price}")]

        public async Task<IActionResult> UpdatePriceOfProduct([FromHeader] string token, [FromRoute] int id, [FromRoute] float Price)
        {
            Log.Information("Operation of Update Product Price Has Been Started");
            try
            {

                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Update Product Price ");
                }
                await _productService1.UpdatePriceProduct(id, Price);
                Log.Information($"Price  Updated Successfully  ");
                return StatusCode(200, "Updated successfully");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update Product Price {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To update Cart Status
        /// </summary>
        [HttpPut]
        [Route("[action]/{id}/{StatusCardId}")]

        public async Task<IActionResult> UpdateCartStatus([FromHeader] string token, [FromRoute] int id, [FromRoute] int StatusCardId)
        {
            Log.Information("Operation of Update Cart Status Has Been Started");
            try
            {

                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Update  Cart Status ");
                }
                await _cartService.UpdateStatusCart(id, StatusCardId);
                Log.Information($"cart  Updated Successfully  ");
                return StatusCode(200, "Updated successfully");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update  Cart Status {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To Update Order Status
        /// </summary>
        [HttpPut]
        [Route("[action]/{id}/{StatusOrder}")]

        public async Task<IActionResult> UpdateOrderStatus([FromHeader] string token, [FromRoute] int id, [FromRoute] int StatusOrder)
        {
            Log.Information("Operation of Update Order Status Has Been Started");
            try
            {

                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Update Order Status ");
                }
                await _orderService.UpdateOrderStatus(id, StatusOrder);
                Log.Information($"Order  Updated Successfully  ");
                return StatusCode(200, "Updated successfully");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Update Order Status {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
    }
}
