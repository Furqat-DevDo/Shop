using Microsoft.EntityFrameworkCore;
using Registration.Services;
using Shop.Application.Logins.Models;
using Shop.Application.Users.Exceptions;
using Shop.Application.Users.Mappers;
using Shop.Application.Users.Responces;
using Shop.Core.Data;

namespace Shop.Application.Logins.Services;
public class LoginService : ILoginService
{
    private readonly RegDbContext _dbContext;
    public LoginService(RegDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<GetUserResponse> GetUserByEmailAddressAsync(LoginByEmail request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.EmailAddress == request.EmailAddress);
        if (user is null)
            throw new UserNotFoundException($"User Not Found !!!");

        if (!user.CheckPassword(request.Password))
            throw new WrongInputException($"Password or Email is not correct please check and try again later !!!");

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> GetUserByPhoneNumberAsync(LoginPhoneRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber);
        if (user is null)
            throw new UserNotFoundException($"User Not Found !!!");

        if (!user.CheckPassword(request.Password))
            throw new WrongInputException($"Password or Email is not correct please check and try again later !!!");

        return user.ResponseUser();
    }
}
