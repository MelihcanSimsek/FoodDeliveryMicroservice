

using WebApp.Models.Login;
using WebApp.Models.Register;

namespace WebApp.Services.Abstracts
{
    public interface IIdentityService
    {
        Task<RegisterResponse> Register(RegisterRequest registerRequest);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();
    }
}
