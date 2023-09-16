using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Registration.Application.Clients;
using Registration.Application.Emails.Clients;
using Registration.Application.Emails.Models;
using Registration.Application.Emails.Services;
using Registration.Application.Logins.Services;
using Registration.Application.Registrations.Services;
using Registration.Application.Users.Services;
using Registration.Application.Verification;
using Registration.Core.Data;

namespace Registration.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IRegistrationService, RegistrationService>()
            .AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<ILoginService,LoginService>();
        services.AddScoped<ISenderClient<SenderResponse, SendEmailRequest>, EmailSenderClient>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<IVerificationService, VerificationService>();

        services.AddDbContext<RegDbContext>(options =>
        {
            options.UseInMemoryDatabase("UsersDb");
        });
        return services;
    }
}