using Shop.Application.Registrations.Models;
using Shop.Application.Users.Responces;

namespace Shop.Application.Registrations.Services;

public interface IRegistrationService
{
    Task<GetUserResponse> CreateUserAsync(RegisterRequest request);
}
