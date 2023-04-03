using FirstAPIApp.Authentication;

namespace FirstAPIApp.Services.UserService
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticateRequest model);
    }
}
