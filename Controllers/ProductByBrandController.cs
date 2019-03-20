using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProductByBrandController : ControllerBase
{
    private readonly webContextDb _context;

    public ProductByBrandController()
    {
        _context = new webContextDb();
    }

    //GET: api/productbybrand/5
    [HttpGet("{brandId}")]
    public IActionResult GetProductByBrand([FromRoute] int brandId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var productByBrand = _context.Products
        .Include(p => p.Brand)
        .Include(p => p.Group)
        .Include(p => p.TitlePictureProduct)
        .Where(p => p.brandId == brandId);

        if(productByBrand == null)
        {
            return NoContent();
        }

        return Ok(productByBrand);
    }

    //POST: api/productbybrand
    [HttpPost]
    public IActionResult PostProductByBrand([FromBody] postData postData)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        List<object> lsProdSpecs = new List<object>();

        foreach (int i in postData.specsId)
        {
            object productDescription = new object();
            productDescription = _context.ProductDescriptions
            .Where(p => p.productId == i);

            lsProdSpecs.Add(productDescription);
        }


        return Ok(lsProdSpecs);
    }
}

public class postData
{
    public int[] specsId { get; set; }
}