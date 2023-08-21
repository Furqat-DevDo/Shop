using Registration_user.UserModel.Request;
using Registration_user.UserModel.Response;

namespace Registration_user.Services.Interfaces;

public interface IUserService
{
    Task<GetUserResponse> CreateUserAsync(CreateUserRequest request);
    Task<GetUserResponse> UpdateUserAsync(string password, UpdateUserRequest request);
    Task<GetUserResponse?> GetUserByEmailAsync(UserLogInByEmailRequest emailRequest);
    Task<GetUserResponse?> GetUserByPhoneNumberAsync(UserLogInByPhoneNumberRequest numberRequest);
}
