using EfCore.Middlewares;
using Registration.Services;
using Registration.Services.Interfaces;
using System.Reflection;

namespace Registration;

public static class ExtensionServices
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
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
