

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DownTrack.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DinnerController : ApiController
{
    [HttpGet]
    public IActionResult ListDinner()
    {
        return Ok(Array.Empty<string>());
    }
}