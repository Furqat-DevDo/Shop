using Registration.Exceptions;
using Shop.Application.Registrations.Models;
using Shop.Application.Users.Mappers;
using Shop.Application.Users.Responces;
using Shop.Core.Data;

namespace Shop.Application.Registrations.Services;

public class RegistrationService : IRegistrationService
{
    private readonly RegDbContext _dbContext;

    public RegistrationService(RegDbContext context)
    {
        _dbContext = context;
    }

    public async Task<GetUserResponse> CreateUserAsync(RegisterRequest request)
    {
        var user = request.CreateUser();

        var newUser = await _dbContext.Users.AddAsync(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return newUser.Entity.ResponseUser();
    }

}
