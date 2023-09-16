using Microsoft.EntityFrameworkCore;
using Registration.Application.Exceptions;
using Registration.Application.Logins.Models;
using Registration.Application.Logins.Services;
using Registration.Application.Users.Exceptions;
using Registration.Application.Users.Mappers;
using Registration.Application.Users.Responces;
using Registration.Core.Data;

namespace Registration.Application.Logins.Services;
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
}
