
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Set;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // private readonly IIdentityService _identityService;
    private readonly UserManager<User> _userManager;
    //private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<User>> CreateUser (User user,string password)
    {
         var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Error creating user: {errors}");
        }

        return Ok(user);
    }

}