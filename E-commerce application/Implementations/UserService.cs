using E_commerce_application.Context;
using E_commerce_application.DTOs.Users.Request;
using E_commerce_application.DTOs.Users.Response;
using E_commerce_application.Entities;
using E_commerce_application.Helper;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class UserService : IUserService
    {
        private readonly CommerceDbContext _context;
        public UserService(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateAccount(CreateAccountDTOs input)
        {
            if(input != null)
            {
                User user = new User()
                {
                    FullName = input.FullName,
                    Email = EncryptionHelper.GenerateSHA384String(input.Email),
                    Password = EncryptionHelper.GenerateSHA384String(input.Password),
                    Phone = input.Phone,
                    UserTypeId=16,
                    Adress = input.Adress,
                    GenderId=input.GenderId,
                    NationalityId=input.NationalityId,
                    
                };
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("You Must Add Your Info");
            }

        }

        public async Task<List<UsersDTOs>> GetUserProfile()
        {
            var result = from li in _context.Users
                         select new UsersDTOs
                         {
                             Id = li.Id,
                             FullName = li.FullName,
                         
                          
                             Phone = li.Phone,
                             Adress = li.Adress,
                           
                             GenderId = li.GenderId,
                             NationalityId = li.NationalityId,
                             UserTypeId = li.UserTypeId,
                             isDeleted = li.IsDeleted,
                         };
            return await result.ToListAsync();
        }

        public async Task ResetPassword(RestPasswordDTOs input)
        {
            if (input != null)
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Email == EncryptionHelper.GenerateSHA384String(input.Email));
                if (res != null)
                {
                    res.Password = EncryptionHelper.GenerateSHA384String(input.NewPassword);


                    res.ModificationDate = DateTime.Now;

                    _context.Update(res);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new Exception("no user with the given Email");
                }

            }
            else
            {
                throw new Exception("You must pass the Email");
            }
        }
    }
}
