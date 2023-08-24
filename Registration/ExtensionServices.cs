using EfCore.Middlewares;
using Shop.Application.Clients;
using Shop.Application.Emails.Clients;
using Shop.Application.Emails.Models;
using Shop.Application.Emails.Options;
using Shop.Application.Emails.Services;
using Shop.Application.Logins.Services;
using Shop.Application.Registrations.Services;
using Shop.Application.SMS.Clients;
using Shop.Application.SMS.Models;
using Shop.Application.SMS.Services;
using Shop.Application.Users.Services;
using System.Reflection;

namespace Registration;

public static class ExtensionServices
{
    public static IServiceCollection AddMyServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<ILoginService,LoginService>();
        services.AddScoped<ISenderClient<SenderResponse, SendEmailRequest>, EmailSenderClient>();
        services.AddScoped<ISenderClient<SenderResponse, SendSMSRequest>, SMS_SenderClient>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<ISMS_Sender,SMS_Sender>();

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

        services.Configure<SendgridOptions>(configuration.GetSection("SendGrid"));
        services.Configure<RapidOptions>(configuration.GetSection("SendGrid:Headers"));

        return services;
    }
}
