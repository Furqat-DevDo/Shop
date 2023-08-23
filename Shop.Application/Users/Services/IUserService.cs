using Shop.Application.Users.Requests;
using Shop.Application.Users.Responces;

namespace Shop.Application.Users.Services;

public interface IUserService
{
    Task<GetUserResponse> UpdateUserPasswordAsync(UpdateUserPassRequest request);
    Task<GetUserResponse> UpdateUserNameAsync(UpdateUserNameRequest request);
    Task<GetUserResponse> UpdateUserEmailAsync(UpdateUserEmailRequest request);
    Task<GetUserResponse> UpdateUserPhoneAsync(UpdateUserPhoneRequest request);
}
