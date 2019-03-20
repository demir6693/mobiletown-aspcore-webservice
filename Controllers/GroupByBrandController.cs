using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class GroupByBrandController : ControllerBase
{
    private readonly webContextDb _context;

    public GroupByBrandController()
    {
        _context = new webContextDb();
    }

    //GET: api/groupbybrand
    [HttpGet]
    public IEnumerable<BrandByGroup> GetBrandByGroup()
    {
        return _context.BrandByGroups
        .Include(b => b.Brand)
        .Include(b => b.Group);
    }

    [HttpGet("{id}")]
    //GET: api/groupbybrand/5
    public IActionResult GetGroupByBrand([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var brands = _context.BrandByGroups
        .Include(b => b.Brand)
        .Include(b => b.Group)
        .Where(g => g.groupId == id);

        if (brands == null)
        {
            return NotFound();
        }

        return Ok(brands);
    }

    //POST: api/groupbybrand
    [HttpPost]
    public async Task<IActionResult> PostGroupByBrand([FromBody] BrandByGroup brandByGroup)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        _context.BrandByGroups.Add(brandByGroup);
        await _context.SaveChangesAsync();
        
        return Ok(brandByGroup);
    }
}