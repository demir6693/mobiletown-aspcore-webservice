using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly webContextDb _context;

    public ProductController()
    {
        _context = new webContextDb();
    }

    //GET: api/products
    [HttpGet]
    public IEnumerable<Product> GetProduct()
    {
        return _context.Products
        .Include(p => p.Group)
        .Include(p => p.Brand);
    }

    [HttpGet("{id}")]
    //GET: api/products/5
    public async Task<IActionResult> GetProducts([FromRoute] int id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var products = await _context.Products
        .Include(p => p.TitlePictureProduct)
        .Include(p => p.Group)
        .Include(p => p.Brand)
        .SingleOrDefaultAsync(p => p.Id == id);

        if(products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    //POST: api/products
    [HttpPost]
    public async Task<IActionResult> PostProduct([FromBody] Product product)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    //PUT: api/products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if(id != product.Id)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if(!ProductExist(id))
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

    //DELETE: api/products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducts([FromRoute] int id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = await _context.Products.FindAsync(id);

        if(product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }

    private bool ProductExist(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}