using Registration.Models.Requests;
using Registration.Models.Responces;
using Shop.Application.Models.Requests;

namespace Registration.Services.Interfaces;

public interface IUserService
{
    Task<GetUserResponse> CreateUserAsync(CreateUserRequest request);
    Task<GetUserResponse> UpdateUserPasswordAsync(UpdateUserPasswordRequest request);
    Task<GetUserResponse> UpdateUserAuthDataAsync(UpdateUserAuthDataRequest request);
    Task<GetUserResponse> GetUserByEmailAddressAsync(LogInByEmailAddressUserRequest request);
    Task<GetUserResponse> GetUserByPhoneNumberAsync(LogInByPhoneNumberUserRequest request);
}
