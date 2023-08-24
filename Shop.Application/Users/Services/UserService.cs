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

        // TODO check is user real owner.

        user.UpdateUserPassword(request);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> UpdateUserNameAsync(UpdateUserNameRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.EmailAddress == request.UserAuthData ||
                                      f.PhoneNumber == request.UserAuthData);

        if (user is null)
            throw new UserNotFoundException("User not Found");

        if (!user.CheckPassword(request.Password))
            throw new InvalidDataGivenException($"Password or Email is not correct please check and try again later !!!"); 

        user.UpdateUserName(request);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> UpdateUserEmailAsync(UpdateUserEmailRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.EmailAddress == request.UserAuthData ||
                                      f.PhoneNumber == request.UserAuthData);

        if (user is null)
            throw new UserNotFoundException("User not Found");

        if (!user.CheckPassword(request.Password))
            throw new InvalidDataGivenException($"Password or Email is not correct please check and try again later !!!"); 

        user.UpdateUserEmail(request);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> UpdateUserPhoneAsync(UpdateUserPhoneRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.EmailAddress == request.UserAuthData ||
                                      f.PhoneNumber == request.UserAuthData);

        if (user is null)
            throw new UserNotFoundException("User not Found");

        if (!user.CheckPassword(request.Password))
            throw new WrongInputException("Email or Password is wrong !!!"); ;

        user.UpdateUserPhone(request);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }
}
