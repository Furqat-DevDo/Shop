using Registration.Application.Users.Requests;
using Registration.Application.Users.Responces;

namespace Registration.Application.Users.Services;

public interface IUserService
{
    Task<GetUserResponse> UpdateUserPasswordAsync(UpdateUserPassRequest request);
    Task<GetUserResponse> UpdateUserDataAsync(UpdateUserDataRequest request);
    Task<IEnumerable<GetUserResponse>> GetAllAsync();
}
