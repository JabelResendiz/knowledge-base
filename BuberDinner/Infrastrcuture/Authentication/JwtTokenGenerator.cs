

// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using BuberDinner.Application.Common.Interfaces.Authentication;
// using Microsoft.IdentityModel.Tokens;

// namespace BuberDinner.Infrastrcuture.Authentication;

// public class JwtTokenGenerator : IJwtTokenGenerator
// {
//     public string GenerateToken(Guid userId, string firstName, string lastName)
//     {
//         var signingCredentials = new SigningCredentials(
//             new SymmetricSecurityKey(
//                 Encoding.UTF8.GetBytes("super-secret-key ")
//             ),
//             SecurityAlgorithms.HmacSha256
//         );

//         var claims = new[]
//         {
//             new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
//             new Claim(JwtRegisteredClaimNames.GivenName, firstName),
//             new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
//             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),


//         };

//         var securityToken = new JwtSecurityToken(
//             issuer : "BuberDinner",
//             expires: DateTime.Now.AddDays(1),
//             claims: claims,
//             signingCredentials: signingCredentials
//             );

//         return new JwtSecurityTokenHandler().WriteToken(securityToken);
//     }
// }


using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastrcuture.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var secretKey = _configuration["Jwt:SecretKey"];
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new InvalidOperationException("JWT secret key is not configured.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            expires: DateTime.UtcNow.AddHours(1),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}