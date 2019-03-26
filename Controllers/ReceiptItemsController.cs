using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ReceiptItemsController : ControllerBase
{
    private readonly webContextDb _context;

    public ReceiptItemsController()
    {
        _context = new webContextDb();
    }

    //GET: api/receiptitems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReceiptItems>>> GetReceipts()
    {
        return await _context.ReceiptItems
        .Include(r => r.Receipt)
        .Include(p => p.Product)
        .ToListAsync();
    }

    //GET: api/receiptitems/5
    [HttpGet("{id}")]
    public ActionResult<ReceiptItems> GetReceipt([FromRoute] int id)
    {
        var receiptItems = _context.ReceiptItems
        .Include(r => r.Receipt)
        .Include(p => p.Product)
        .Where(p => p.receiptId == id);

        if(receiptItems == null)
        {
            return NoContent();
        }

        return Ok(receiptItems);
    }

    //PUT: api/receiptitems/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReceipt([FromRoute] int id, [FromBody] ReceiptItems receiptItems)
    {
        if(id != receiptItems.Id)
        {
            return BadRequest();
        }

        _context.Entry(receiptItems).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if(!OrderExists(id))
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

    //POST: api/receipt
    [HttpPost]
    public async Task<ActionResult<ReceiptItems>> PostReceipt([FromBody] ReceiptItems receiptItems)
    {
        _context.ReceiptItems.Add(receiptItems);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReceipt", new { id = receiptItems.Id }, receiptItems);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ReceiptItems>> DeleteReceipt([FromRoute] int id)
    {
        var receiptItems = await _context.ReceiptItems.FindAsync(id);
        if(receiptItems == null)
        {
            return NotFound();
        }

        _context.ReceiptItems.Remove(receiptItems);
        await _context.SaveChangesAsync();

        return receiptItems;
    }

    private bool OrderExists(int id)
    {
        return _context.ReceiptItems.Any(e => e.Id == id);
    }
}