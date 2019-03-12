using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LoginUserController : ControllerBase
{
    private readonly webContextDb _context;

    public LoginUserController()
    {
        _context = new webContextDb();
    }

    // POST: api/loginuser
    [HttpPost]
    public IActionResult PostUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var userTmp = _context.User
        .Where(u => u.Email == user.Email
                && u.Password == user.Password);


        return Ok(userTmp);
    }
}