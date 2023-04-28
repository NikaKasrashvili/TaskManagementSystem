using Application.BLL.Models.Auth;

namespace Application.BLL.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResult> Login(AuthRequest request);
        Task<AuthResponse> Register(RegistrationRequest request);
    }
}
