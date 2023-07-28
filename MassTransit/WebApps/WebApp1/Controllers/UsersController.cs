using Filed.Shared.Entities;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IBus _bus;

    public UsersController(IBus bus)
    {
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(CreateUserModel model)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Email = model.Email,
            Password = model.Password,
            UserName = model.UserName
        };
        await _bus.Publish(user);
        return Ok(user.Id);
    }



}