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
    public class OrderItemsController : ControllerBase
    {
        private readonly webContextDb _context;

        public OrderItemsController()
        {
            _context = new webContextDb();
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItems>>> GetOrders()
        {
            return await _context.OrderItems
            .Include(u => u.Product)
            .Include(c => c.Order)
            .ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<OrderItems> GetOrder(int id)
        {
            var order = _context.OrderItems
            .Include(u => u.Product)
            .Include(c => c.Order)
            .Where(o => o.orderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderItems orderItems)
        {
            if (id != orderItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderItems>> PostOrder(OrderItems orderItems)
        {
            _context.OrderItems.Add(orderItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = orderItems.Id }, orderItems);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItems>> DeleteOrder(int id)
        {
            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();

            return orderItems;
        }

        private bool OrderExists(int id)
        {
            return _context.OrderItems.Any(e => e.Id == id);
        }
    }
}
