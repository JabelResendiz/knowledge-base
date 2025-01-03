


namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationQueriesService
{

    AuthenticationResult Login(string email, string password);
   
}