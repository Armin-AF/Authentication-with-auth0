using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedCarWarrantyApi.Data;
using UsedCarWarrantyApi.Models;

namespace UsedCarWarrantyApi.Controller;


[Route("api/[controller]")]
[ApiController]
public class InsuranceController: ControllerBase
{
    private readonly WarrantyDbContext _context;

    public InsuranceController(WarrantyDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Insurance>>> GetInsurances()
    {
        return await _context.Insurance
            .Include(insurance => insurance.LegalEntity)
            .Include(insurance => insurance.Vehicle)
            .ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Insurance>> GetInsurance(int id)
    {
        var insurance = await _context.Insurance
            .Include(insurance => insurance.LegalEntity)
            .Include(insurance => insurance.Vehicle)
            .FirstOrDefaultAsync(insurance => insurance.InsuranceID == id);

        if (insurance == null)
        {
            return NotFound();
        }

        return insurance;
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Insurance>> PostInsurance(Insurance insurance)
    {
        _context.Insurance.Add(insurance);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInsurance), new { id = insurance.InsuranceID }, insurance);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInsurance(int id, Insurance insurance)
    {
        if (id != insurance.InsuranceID)
        {
            return BadRequest();
        }

        _context.Entry(insurance).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInsurance(int id)
    {
        var insurance = await _context.Insurance.FindAsync(id);
        if (insurance == null)
        {
            return NotFound();
        }

        _context.Insurance.Remove(insurance);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}