using System.Linq;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CheckController : ControllerBase
{
    private readonly webContextDb _context;

    public CheckController()
    {
        _context = new webContextDb();
    }

    //GET: api/check
    [HttpPost]
    public bool PostCheck([FromBody] CheckModel checkModel)
    {   
        if(checkModel.ver == 0)
        {
            var dataCheck = _context.User.Where(u => u.Email.Equals(checkModel.checkData));
            
            if(dataCheck.Count() != 0)
            {
                return true;
            }
            
        }

        return false;
    }
}