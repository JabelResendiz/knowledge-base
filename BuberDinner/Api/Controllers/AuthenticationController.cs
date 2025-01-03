

using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
   private readonly IAuthenticationCommandService _authenticationCommandService;

   private readonly IAuthenticationQueriesService _authenticationQueriesService;

   public AuthenticationController(IAuthenticationCommandService authenticationCommandService
                                    ,IAuthenticationQueriesService authenticationQueriesService)
   {
      _authenticationCommandService = authenticationCommandService;
      _authenticationQueriesService = authenticationQueriesService;
   }


   [HttpPost("register")]
   public IActionResult Register(RegisterRequest request)
   {
      var authResult = _authenticationCommandService.Register(
       request.FirstName,
       request.LastName,
       request.Email,
       request.Password);

      var response = new AuthenticationResponse(
         authResult.user.Id,
         authResult.user.FirstName,
         authResult.user.LastName,
         authResult.user.Email,
         authResult.Token
      );

      return Ok(response);
   }

   [HttpPost("Login")]
   public IActionResult Login(LoginRequest request)
   {

      var authResult = _authenticationQueriesService.Login(
      request.Email,
      request.Password);

      var response = new AuthenticationResponse(
         authResult.user.Id,
         authResult.user.FirstName,
         authResult.user.LastName,
         authResult.user.Email,
         authResult.Token
      );
      return Ok(response);
   }
}