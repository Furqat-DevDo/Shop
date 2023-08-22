using Microsoft.EntityFrameworkCore;
using Registration.Exceptions;
using Registration.Services;
using Shop.Application.Users.Exceptions;
using Shop.Application.Users.Mappers;
using Shop.Application.Users.Requests;
using Shop.Application.Users.Responces;
using Shop.Core.Data;

namespace Shop.Application.Users.Services;

public class UserService : IUserService
{
    private readonly RegDbContext _dbContext;
    public UserService(RegDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<GetUserResponse> UpdateUserPasswordAsync(UpdateUserPassRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.EmailAddress == request.UserAuthData ||
                                 f.PhoneNumber == request.UserAuthData);

        if (user is null)
            throw new UserNotFoundException($"User Not Found");

        // TODO check is uesr real owner.

        user.UpdateUserPassword(request);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> UpdateUserAuthDataAsync(UpdateUserRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f =>
                                 f.EmailAddress == request.UserAuthData ||
                                 f.PhoneNumber == request.UserAuthData);

        if (user is null)
            throw new UserNotFoundException("User not Found");

        if (!user.CheckPassword(request.Password))
            throw new InvalidDataGivenException($"!!!"); ;

        user.UpdateUserAuthData(request);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }
}
