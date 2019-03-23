using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsersInfoController : ControllerBase
{
    private readonly webContextDb _context;

    public UsersInfoController()
    {
        _context = new webContextDb();
    }

    //GET: api/usersinfo
    [HttpGet]
    public IEnumerable<UsersInfo> GetUsersInfo()
    {
        return _context.UsersInfo
        .Include(u => u.user);
    }

    //GET: api/usersinfo/5
    [HttpGet("{id}")]
   public async Task<IActionResult> GetUserInfo([FromRoute] int id)
   {
       if(!ModelState.IsValid)
       {
           return BadRequest(ModelState);
       }

       var userInfo = await _context.UsersInfo
       .SingleOrDefaultAsync(u => u.IdUser == id);

        if(userInfo == null)
        {
            return NoContent();
        }
        
       return Ok(userInfo);
   } 

   //POST: api/usersinfo
   [HttpPost]
   public async Task<IActionResult> PostUserInfo([FromBody] UsersInfo userInfo)
   {
       if(!ModelState.IsValid || !UserExist(userInfo.IdUser))
       {
           return BadRequest();
       }

       _context.UsersInfo.Add(userInfo);
       await _context.SaveChangesAsync();

       return CreatedAtAction("GetUserInfo", new { id = userInfo.Id }, userInfo);
   }

    //PUT: api/usersinfo/5
   [HttpPut("{id}")]
   public async Task<IActionResult> PutUserInfo([FromRoute] int id, [FromBody] UsersInfo userInfo)
   {
       if(!ModelState.IsValid)
       {
           return BadRequest(ModelState);
       }

       if(id != userInfo.Id)
       {
           return BadRequest();
       }

       _context.Entry(userInfo).State = EntityState.Modified;

       try
       {
           await _context.SaveChangesAsync();
       }
       catch(DbUpdateConcurrencyException)
       {
           if(!UserInfoExists(id))
           {
               return NotFound();
           }
           else
           {
               throw;
           }
       }

       return NoContent();
   }

   //DELETE: api/usersinfo/5
   [HttpDelete("{id}")]
   public async Task<IActionResult> DeleteUsersInfo([FromRoute] int id)
   {
       if(!ModelState.IsValid)
       {
           return BadRequest(ModelState);
       }

       var userInfo = await _context.UsersInfo.FindAsync(id);

       if(userInfo == null)
       {
           return NotFound();
       }

       _context.UsersInfo.Remove(userInfo);
       await _context.SaveChangesAsync();

       return Ok(userInfo);
   }

    private bool UserInfoExists(int id)
    {
        return _context.UsersInfo.Any(e => e.Id == id);
    }

    private bool UserExist(int id)
    {
        var user = _context.User.SingleOrDefault(u => u.Id == id);

        if(user == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}