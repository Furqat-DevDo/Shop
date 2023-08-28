using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Registration.Application.Helpers;
using Registration.Exceptions;
using Registration.Services;
using Shop.Application.Emails.Models;
using Shop.Application.Emails.Services;
using Shop.Application.Users.Exceptions;
using Shop.Application.Users.Mappers;
using Shop.Application.Users.Requests;
using Shop.Application.Users.Responces;
using Shop.Application.Verification;
using Shop.Application.Verification.Requests;
using Shop.Core.Data;

namespace Shop.Application.Users.Services;

public class UserService : IUserService
{
    private readonly RegDbContext _dbContext;
    private readonly ILogger<UserService> _logger;
    private readonly IEmailSender _emailSender;
    private readonly IVerificationService _verificationService;

    public UserService(
        RegDbContext context,
        ILogger<UserService> logger,
        IEmailSender emailSender,
        IVerificationService verificationService)
    {
        _dbContext = context;
        _logger = logger;
        _emailSender = emailSender;
        _verificationService = verificationService;
    }

    public async Task<GetUserResponse> UpdateUserPasswordAsync(UpdateUserPassRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.EmailAddress == request.EmailAddress)
            ?? throw new UserNotFoundException($"User Not Found");    

        var code = CodeGeneratorHelper.GeneratedCode().ToString();

        var link = $"http://localhost:5099/api/verifications";

        var uriBuilder = new UriBuilder(link);
        var resultLink = uriBuilder.Query = $"email={user.EmailAddress}&code={code}";

        await _emailSender.SendEmailAsync(
            new SendEmailRequest
            {
                To = request.EmailAddress,
                From = "ilmhub.uz@gmail.com",
                Subject = "Shaxsni tasdiqlash",
                Body = $"Shaxsingizni tasdiqlash uchun quyidagi linkni bosing: \n{resultLink}\n" +
                       $" yoki \n\t{code}\n kodni kiriting."
            });

        await _verificationService.PasswordUpdateVerificationAsync(new VerificationRequest
        {
            Email = request.EmailAddress,
            Code = code
        }, request.NewPassword);

        //user.UpdateUserPassword(request);
        //_dbContext.Users.Update(user);

        //if (await _dbContext.SaveChangesAsync() <= 0)
        //    throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> UpdateUserDataAsync(UpdateUserDataRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.EmailAddress == request.EmailAddress);

        if (user is null)
            throw new UserNotFoundException("User not Found");

        if (!user.CheckPassword(request.Password))
            throw new WrongInputException($"Password or Email is not correct please check and try again later !!!"); 

        user.UpdateUserData(request);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }
}
