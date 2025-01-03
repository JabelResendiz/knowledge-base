

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationQueriesServices : IAuthenticationQueriesService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;
    public AuthenticationQueriesServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login( string email, string password)
    {
        // Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User with the given email does not exist");

        // validate the password is correct
        if (user.Password != password)
            throw new Exception("invalid password");

        // create the jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }
}