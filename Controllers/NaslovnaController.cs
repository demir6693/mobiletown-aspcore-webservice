using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class NaslovnaController : ControllerBase
{
    private readonly webContextDb _context;

    public NaslovnaController()
    {
        _context = new webContextDb();
    }

    //GET: api/naslovna
    [HttpGet]
    public object GetNaslovna()
    {
        var getNaslovnaGroup = _context.Groups;
        
        var dict = new Dictionary<string, object>();
       
        foreach(var item in getNaslovnaGroup)
        {
           dict[item.Name] = _context.Products
           .Include(p => p.Brand)
           .Include(p => p.TitlePictureProduct)
           .Where(p => p.groupId == item.Id).Take(6);
        }
        
        var objectNaslovna = dict;

        return objectNaslovna;
    }

    [HttpGet("{id}")]
    //GET: api/naslovna/5
    public async Task<IActionResult> GetNaslovna([FromRoute] int id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var products = await _context.Products
        .FindAsync(id);

        if(products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    //POST: api/naslovna
    [HttpPost]
    public object PostNaslovna([FromBody] CheckModel checkModel)
    {   
        var pictureProd = checkModel.pictureIndex;

        object[] picture = new object[pictureProd.Count()];
      
        for(int i = 0; i < pictureProd.Count(); i ++)
        {
            picture[i] = pictureProd[i];
            //_context.ProductPictures.Where(p => p.Id == pictureProd[i]);
        } 

        return picture;
    }

    //PUT: api/naslovna/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNaslovna([FromRoute] int id, [FromBody] Product product)
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

    //DELETE: api/naslovna/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNaslovna([FromRoute] int id)
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