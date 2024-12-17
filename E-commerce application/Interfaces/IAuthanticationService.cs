using E_commerce_application.DTOs.Authantication.Request;

namespace E_commerce_application.Interfaces
{
    public interface IAuthanticationService
    {
        Task<string> LogIn(LogInDTOs logIn);

    }
}
