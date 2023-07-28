using Microsoft.AspNetCore.Mvc;
using WebApp2.Managers;

namespace WebApp2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager _userManager;

    public UsersController(UserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Information(Guid id)
    {
        return Ok(_userManager.UserInformation(id));
    }
}