using Shop.Application.Logins.Models;
using Shop.Application.Users.Responces;

namespace Shop.Application.Logins.Services;

public interface ILoginService
{
    Task<GetUserResponse> GetUserByEmailAddressAsync(LoginByEmail request);
    Task<GetUserResponse> GetUserByPhoneNumberAsync(LoginPhoneRequest request);
}
