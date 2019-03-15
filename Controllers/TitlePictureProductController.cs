using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlePictureProductController : ControllerBase
    {
        private readonly webContextDb _context;

        public TitlePictureProductController()
        {
            _context = new webContextDb();
        }

        // GET: api/titlepictureproduct
        [HttpGet]
        public IEnumerable<TitlePictureProduct> GetTitlePictureProducts()
        {
            return  _context.TitlePictureProducts;
        }

        // GET: api/titlepictureproduct/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TitlePictureProduct>> GetTitlePictureProduct(int id)
        {
            var TitlePictureProducts = _context.TitlePictureProducts;

            if (TitlePictureProducts == null)
            {
                return NotFound();
            }

            return Ok(TitlePictureProducts);
        }

        // PUT: api/titlepictureproduct/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitlePictureProduct(int id, TitlePictureProduct TitlePictureProducts)
        {
            if (id != TitlePictureProducts.Id)
            {
                return BadRequest();
            }

            _context.Entry(TitlePictureProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitlePictureProductsExists(id))
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

        // POST: api/titlepictureproduct
        [HttpPost]
        public async Task<ActionResult<TitlePictureProduct>> PostTitlePictureProduct(TitlePictureProduct TitlePictureProducts)
        {   
            _context.TitlePictureProducts.Add(TitlePictureProducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitlePictureProducts", new { id = TitlePictureProducts.Id }, TitlePictureProducts);
        }

        // DELETE: api/titlepictureproduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitlePictureProduct>> DeleteTitlePictureProduct(int id)
        {
            var TitlePictureProducts = await _context.TitlePictureProducts.FindAsync(id);
            if (TitlePictureProducts == null)
            {
                return NotFound();
            }

            _context.TitlePictureProducts.Remove(TitlePictureProducts);
            await _context.SaveChangesAsync();

            return TitlePictureProducts;
        }

        private bool TitlePictureProductsExists(int id)
        {
            return _context.TitlePictureProducts.Any(e => e.Id == id);
        }
    }
}
