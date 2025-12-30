using System.Web;
// using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.DTO;

namespace UserService.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController: ControllerBase
{
    private readonly UsersDbContext _db;
    
    public UsersController(UsersDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginData)
    {
        var username = await _db.Users.FirstOrDefaultAsync((x) => x.username == loginData.username);
        var password = await _db.Users.FirstOrDefaultAsync((x) => x.password_hash == loginData.password);

        if (username != null && password != null)
        {
            return Ok();
        }
        return BadRequest();
    }

    public async Task<IActionResult> Logout()
    {
        return Ok();
    }

    public async Task<IActionResult> Register()
    {
        return Ok();
    }
    
    
}