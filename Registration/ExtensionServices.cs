using EfCore.Middlewares;
using Shop.Application.Clients;
using Shop.Application.Emails.Clients;
using Shop.Application.Emails.Models;
using Shop.Application.Emails.Services;
using Shop.Application.Logins.Services;
using Shop.Application.Registrations.Services;
using Shop.Application.SMS.Clients;
using Shop.Application.SMS.Models;
using System.Reflection;

namespace Registration;

public static class ExtensionServices
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<ILoginService,LoginService>();
        services.AddScoped<ISenderClient<SenderResponse, SendEmailRequest>, EmailSenderClient>();
        services.AddScoped<ISenderClient<SenderResponse, SendSMSRequest>, SMS_SenderClient>();
        services.AddScoped<IEmailSender, EmailSender>();

        services.AddTransient<GlobalExceptionHandlingMiddleWare>();


        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });


        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }
}
