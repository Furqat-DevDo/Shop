using Registration.Models.Requests;
using Registration.Models.Responces;

namespace Registration.Services.Interfaces;

public interface IUserService
{
    Task<GetUserResponse> CreateUserAsync(CreateUserRequest request);
    Task<GetUserResponse> UpdateUserAsync(UpdateUserRequest request);
    Task<GetUserResponse> GetUserByEmailAddressAsync(LogInByEmailAddressUserRequest request);
    Task<GetUserResponse> GetUserByPhoneNumberAsync(LogInByPhoneNumberUserRequest request);
}
