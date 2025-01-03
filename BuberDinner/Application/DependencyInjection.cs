
using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Application.Services.Authentication;
namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandServices>();
        services.AddScoped<IAuthenticationQueriesService, AuthenticationQueriesServices>();

        return services;
    }
}