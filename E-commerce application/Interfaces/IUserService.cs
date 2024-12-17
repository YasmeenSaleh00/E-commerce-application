using E_commerce_application.DTOs.Users.Request;
using E_commerce_application.DTOs.Users.Response;

namespace E_commerce_application.Interfaces
{
    public interface IUserService
    {
        Task CreateAccount(CreateAccountDTOs input);
        Task ResetPassword(RestPasswordDTOs input);
        Task<List<UsersDTOs>> GetUserProfile();
    }
}
