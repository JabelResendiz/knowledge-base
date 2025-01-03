
using BubberDinner.Infrastrcuture.Authentication;
using BubberDinner.Infrastrcuture.Persistance;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastrcuture.Authentication;
using DownTrack.Infrastrcuture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastrcuture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrcuture(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        // agrega la interfaz de opciones y donde podemos solicitar la configuracion
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider,DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}