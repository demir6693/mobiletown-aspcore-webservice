﻿using System;
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
    public class ProductDescriptionsController : ControllerBase
    {
        private readonly webContextDb _context;

        public ProductDescriptionsController()
        {
            _context = new webContextDb();
        }

        // GET: api/ProductDescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDescription>>> GetProductDescriptions()
        {
            return await _context.ProductDescriptions.ToListAsync();
        }

        // GET: api/ProductDescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDescription>> GetProductDescription(int id)
        {
            var productDescription = await _context.ProductDescriptions.FindAsync(id);

            if (productDescription == null)
            {
                return NotFound();
            }

            return productDescription;
        }

        // PUT: api/ProductDescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDescription(int id, ProductDescription productDescription)
        {
            if (id != productDescription.Id)
            {
                return BadRequest();
            }

            _context.Entry(productDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDescriptionExists(id))
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

        // POST: api/ProductDescriptions
        [HttpPost]
        public async Task<ActionResult<ProductDescription>> PostProductDescription(ProductDescription productDescription)
        {
            _context.ProductDescriptions.Add(productDescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDescription", new { id = productDescription.Id }, productDescription);
        }

        // DELETE: api/ProductDescriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDescription>> DeleteProductDescription(int id)
        {
            var productDescription = await _context.ProductDescriptions.FindAsync(id);
            if (productDescription == null)
            {
                return NotFound();
            }

            _context.ProductDescriptions.Remove(productDescription);
            await _context.SaveChangesAsync();

            return productDescription;
        }

        private bool ProductDescriptionExists(int id)
        {
            return _context.ProductDescriptions.Any(e => e.Id == id);
        }
    }
}
