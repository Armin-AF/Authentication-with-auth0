using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedCarWarrantyApi.Data;
using UsedCarWarrantyApi.Models;

namespace UsedCarWarrantyApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class WarrantyController : ControllerBase
{
    private readonly WarrantyDbContext _context;

    public WarrantyController(WarrantyDbContext context)
    {
        _context = context;
    }

    // GET: api/Warranty
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Warranty>>> GetWarranties()
    {
        return await _context.Warranty.Include(w => w.Vehicle).ToListAsync();
    }

    // POST: api/Warranties
    [HttpPost]
    public async Task<ActionResult<Warranty>> PostWarranty(Warranty warranty)
    {
        _context.Warranty.Add(warranty);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWarranty), new { id = warranty.WarrantyID }, warranty);
    }

    // GET: api/Warranties/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Warranty>> GetWarranty(int id)
    {
        var warranty = await _context.Warranty.Include(w => w.Vehicle).FirstOrDefaultAsync(w => w.WarrantyID == id);

        if (warranty == null)
        {
            return NotFound();
        }

        return warranty;
    }

    // PUT: api/Warranties/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWarranty(int id, Warranty warranty)
    {
        if (id != warranty.WarrantyID)
        {
            return BadRequest();
        }

        _context.Entry(warranty).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WarrantyExists(id))
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
    
    // DELETE: api/Warranties/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWarranty(int id)
    {
        var warranty = await _context.Warranty.FindAsync(id);
        if (warranty == null)
        {
            return NotFound();
        }

        _context.Warranty.Remove(warranty);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WarrantyExists(int id)
    {
        return _context.Warranty.Any(e => e.WarrantyID == id);
    }
}