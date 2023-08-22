using Registration.Exceptions;
using Shop.Application.Users.Mappers;
using Shop.Application.Users.Requests;
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

    public async Task<GetUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        var user = request.CreateUser();

        var newUser = await _dbContext.Users.AddAsync(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return newUser.Entity.ResponseUser();
    }

}
