

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationCommandServices : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;
    public AuthenticationCommandServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Validate the user doesnt exist

        if (_userRepository.GetUserByEmail(email) is not null)
            throw new Exception("user with given email already exists");

        //create user(generate unique ID) & Persistance to Db

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password

        };

        _userRepository.Add(user);


        //create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);



        return new AuthenticationResult(user, token);
    }

    
}