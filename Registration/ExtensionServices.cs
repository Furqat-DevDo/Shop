using Registration.Services;
using Registration.Services.Interfaces;

namespace Registration;

public static class ExtensionServices
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
