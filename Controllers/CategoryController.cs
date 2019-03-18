using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly webContextDb _context;

    public CategoryController()
    {
        _context = new webContextDb();
    }

    //POST by Category: api/category
    [HttpPost]
    public IActionResult PostCategory([FromBody] CheckModel checkModel)
    {   
        if(checkModel.ver == 1)
        {
            Group grp = _context.Groups.SingleOrDefault(c => c.Name == checkModel.checkData);

            var products = _context.Products
            .Include(p => p.Group)
            .Include(p => p.Brand)
            .Include(p => p.TitlePictureProduct)
            .Where(p => p.groupId == grp.Id);

            return Ok(products);
        }
        else if(checkModel.ver == 2)
        {
            Brand brand = _context.Brands.SingleOrDefault(b => b.Name == checkModel.checkData);

            var products = _context.Products
            .Include(p => p.Group)
            .Include(p => p.Brand)
            .Include(p => p.TitlePictureProduct)
            .Where(p => p.brandId == brand.Id);

            return Ok(products);
        }
        
        return NoContent();
    }
}