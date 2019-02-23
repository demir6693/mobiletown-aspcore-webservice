using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly webContextDb _context;

    public BrandController()
    {
        _context = new webContextDb();
    }

    //GET: api/brands
    [HttpGet]
    public IEnumerable<Brand> GetBrand()
    {
        return _context.Brands;
    }

    //Get: api/brands/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrand([FromRoute] int id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var brand = await _context.Brands
        .FindAsync(id);

        if(brand == null)
        {
            return NotFound();
        }

        return Ok(brand);
    }

    //POST: api/brands
    [HttpPost]
    public async Task<IActionResult> PostBrand([FromBody] Brand brand)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
    }

    //PUT: api/brands/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBrand([FromRoute] int id, [FromBody] Brand brand)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if(id != brand.Id)
        {
            return BadRequest();
        }

        _context.Entry(brand).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if(!BrandExist(id))
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

    //DELETE: api/brands/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand([FromRoute] int id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var brand = await _context.Brands.FindAsync(id);

        if(brand == null)
        {
            return NotFound();
        }

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();

        return Ok(brand);
    }
    private bool BrandExist(int id)
    {
        return _context.Brands.Any(e => e.Id == id);
    }
}