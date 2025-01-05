
using BubberDinner.Infrastrcuture.Authentication;
using BubberDinner.Infrastrcuture.Persistance;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastrcuture.Authentication;
using DownTrack.Infrastrcuture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastrcuture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrcuture(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        // agrega la interfaz de opciones y donde podemos solicitar la configuracion

        services.AddAuth(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }


    public static IServiceCollection AddAuth(
        this IServiceCollection services, ConfigurationManager configuration)
    {


        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        // Configura el mapeo de la sección JwtSettings
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        // Configuración de autenticación JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(jwtSettings.Secret))
                    };
                });

        return services;
    }



}