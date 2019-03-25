using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ReceiptController : ControllerBase
{
    private readonly webContextDb _context;

    public ReceiptController()
    {
        _context = new webContextDb();
    }

    //GET: api/receipt
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
    {
        return await _context.Receipts
        .Include(u => u.UsersInfo)
        .ToListAsync();
    }

    //GET: api/receipt/5
    [HttpGet("{id}")]
    public ActionResult<Receipt> GetReceipt([FromRoute] int id)
    {
        var receipt = _context.Receipts
        .Include(u => u.UsersInfo)
        .Where(u => u.userInfoId == id);

        if(receipt == null)
        {
            return NoContent();
        }

        return Ok(receipt);
    }

    //PUT: api/receipt/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReceipt([FromRoute] int id, [FromBody] Receipt receipt)
    {
        if(id != receipt.Id)
        {
            return BadRequest();
        }

        _context.Entry(receipt).State = EntityState.Modified;

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
    public async Task<ActionResult<Receipt>> PostReceipt([FromBody] Receipt receipt)
    {
        _context.Receipts.Add(receipt);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReceipt", new { id = receipt.Id }, receipt);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Receipt>> DeleteReceipt([FromRoute] int id)
    {
        var receipt = await _context.Receipts.FindAsync(id);
        if(receipt == null)
        {
            return NotFound();
        }

        _context.Receipts.Remove(receipt);
        await _context.SaveChangesAsync();

        return receipt;
    }
    private bool OrderExists(int id)
    {
        return _context.Receipts.Any(e => e.Id == id);
    }
}