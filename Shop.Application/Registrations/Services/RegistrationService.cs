using Microsoft.Extensions.Logging;
using Registration.Exceptions;
using Registration.Services;
using Shop.Application.Emails.Models;
using Shop.Application.Emails.Services;
using Shop.Application.Registrations.Requests;
using Shop.Application.Users.Mappers;
using Shop.Application.Users.Responces;
using Shop.Application.Verification;
using Shop.Application.Verification.Requests;
using Shop.Core.Data;

namespace Shop.Application.Registrations.Services;

public class RegistrationService : IRegistrationService
{
    private readonly RegDbContext _dbContext;
    private readonly ILogger<RegistrationService> _logger;
    private readonly IEmailSender _emailSender;
    private readonly IVerificationService _verificationService;
    public RegistrationService(
        RegDbContext context,
        ILogger<RegistrationService> logger,
        IEmailSender emailSender,
        IVerificationService verificationService)
    {
        _dbContext = context;
        _logger = logger;
        _emailSender = emailSender;
        _verificationService = verificationService;
    }

    public async Task<GetUserResponse> CreateUserByEmailAsync(CreateUserByEmailRequest request)
    {
        if (_dbContext.Users.Any(u => u.EmailAddress == request.EmailAddress))
        {
            _logger.LogWarning("User allready exist !!!!");
            throw new WrongInputException("User allready exist !!!!");
        }

        var user = request.CreateUser();

        var newUser = await _dbContext.Users.AddAsync(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        var code = GeneratedCode();
        var link = "https://www.ilmhub.uz";

        await _emailSender.SendEmailAsync(new SendEmailRequest
        {
            To = request.EmailAddress,
            From = "ilmhub.uz@gmail.com",
            Subject = "Registratsiya",
            Body = $@"<!DOCTYPE html>
             <html>
             <body>
             <p>Siz bizning platformadan ro'yxatdan o'tish uchun quyidagi linka bosing:</p>
             <p><a href=""{link}"">Ro'yxatdan o'tish</a></p>
             <p>yoki {code} ko'dni kiriting.</p>
             </body>
             </html>"
        });


        await _verificationService.CreateVerificationAsync(new CreateVerificationRequest
        {
            EmailAddress = request.EmailAddress,
            VerificationCode = code
        });

        return newUser.Entity.ResponseUser();
    }

    public async Task<GetUserResponse> CreateUserByPhoneAsync(CreateUserByPhoneRequest request)
    {
        if (_dbContext.Users.Any(u => u.PhoneNumber == request.PhoneNumber))
        {
            _logger.LogWarning("User allready exist !!!!");
            throw new WrongInputException("User allready exist !!!!");
        }


        var user = request.CreateUser();

        var newUser = await _dbContext.Users.AddAsync(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        var code = GeneratedCode();

        throw new NotImplementedException();
    }

    private int GeneratedCode()
        => new Random().Next(1000, 9999);

}
