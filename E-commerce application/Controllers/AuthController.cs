using E_commerce_application.DTOs.Authantication.Request;
using E_commerce_application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce_application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthanticationService _authService;   
        public AuthController(IAuthanticationService authantication)
        {
            _authService = authantication;  
        }
        /// <summary>
        /// This EndPoint to LogIn 
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInDTOs input)
        {
            Log.Information("Log In operation Has been Started ");
            try
            {
                var res = await _authService.LogIn(input);
                Log.Information("LogIn Successfully");
                return res.Equals("Authentication Failed") ? Unauthorized("Email Or Password Is Not Correct") : Ok(res);

            }
            catch (Exception ex)
            {
                throw new Exception($"An Error Happened {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
