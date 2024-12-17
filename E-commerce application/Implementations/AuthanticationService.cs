using E_commerce_application.Context;
using E_commerce_application.DTOs.Authantication.Request;
using E_commerce_application.Helper;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace E_commerce_application.Implementations
{
    public class AuthanticationService : IAuthanticationService
    {
        private readonly CommerceDbContext _context;
        public AuthanticationService(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<string> LogIn(LogInDTOs logIn)
        {
            if (logIn != null)
            {
                if (!string.IsNullOrEmpty(logIn.Email) && !string.IsNullOrEmpty(logIn.Password))
                {
                    logIn.Email = EncryptionHelper.GenerateSHA384String(logIn.Email);
                    logIn.Password = EncryptionHelper.GenerateSHA384String(logIn.Password);
                    var authUser = await (from p in _context.Users
                                          join li in _context.LookupItems
                                          on p.UserTypeId equals li.Id
                                          where p.Email == logIn.Email && p.Password == logIn.Password
                                          select new
                                          {
                                              PersonId = p.Id.ToString(),
                                              Role = li.Value.ToString(),
                                          }).FirstOrDefaultAsync();
                    return authUser != null ? await TokenHelper.GenerateToken(authUser.PersonId, authUser.Role) : "Authentication Failed";
                }
                else
                {
                    throw new Exception("Email And Password Required ");

                }

            }
            else
            {
                throw new Exception("Email And Password Required ");
            }

        }
    }
}
