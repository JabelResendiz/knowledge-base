
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infrastrcuture.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastrcuture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrcuture(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        return services;
    }
}