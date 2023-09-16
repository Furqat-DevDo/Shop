using Registration.Application.Registrations.Requests;
using Registration.Application.Users.Responces;

namespace Registration.Application.Registrations.Services;

public interface IRegistrationService
{
    Task<GetUserResponse> CreateUserAsync(CreateUserRequest request);
}
