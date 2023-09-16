using Registration.Application.Logins.Models;
using Registration.Application.Users.Responces;

namespace Registration.Application.Logins.Services;

public interface ILoginService
{
    Task<GetUserResponse> GetUserByEmailAddressAsync(LoginByEmail request);
}
