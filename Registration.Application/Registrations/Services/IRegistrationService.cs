using Shop.Application.Registrations.Requests;
using Shop.Application.Users.Responces;

namespace Shop.Application.Registrations.Services;

public interface IRegistrationService
{
    Task<GetUserResponse> CreateUserAsync(CreateUserRequest request);
}
