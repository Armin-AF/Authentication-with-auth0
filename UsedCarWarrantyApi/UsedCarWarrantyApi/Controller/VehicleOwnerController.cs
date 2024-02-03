using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedCarWarrantyApi.Data;
using UsedCarWarrantyApi.Models;

namespace UsedCarWarrantyApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class VehicleOwnerController:  ControllerBase
{
    private readonly WarrantyDbContext _context;

    public VehicleOwnerController(WarrantyDbContext context)
    {
        _context = context;
    }
    
    // GET: api/VehicleOwner
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleOwner>>> GetVehicleOwner()
    {
        return await _context.VehicleOwner
            .Include(vo => vo.Vehicle) // Include the Vehicle in the query
            .Include(vo => vo.LegalEntity) // Include the LegalEntity in the query
            .ToListAsync();
    }
    
    // POST: api/VehicleOwner
    [HttpPost]
    public async Task<ActionResult<VehicleOwner>> PostVehicleOwner(VehicleOwner vehicleOwner)
    {
        _context.VehicleOwner.Add(vehicleOwner);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVehicleOwner), new { id = vehicleOwner.OwnershipID }, vehicleOwner);
    }
    
    // GET: api/VehicleOwner/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleOwner>> GetVehicleOwner(int id)
    {
        var vehicleOwner = await _context.VehicleOwner
            .Include(vo => vo.Vehicle) // Include the Vehicle in the query
            .Include(vo => vo.LegalEntity) // Include the LegalEntity in the query
            .FirstOrDefaultAsync(vo => vo.OwnershipID == id);

        if (vehicleOwner == null)
        {
            return NotFound();
        }

        return vehicleOwner;
    }
    
    // PUT: api/VehicleOwner/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehicleOwner(int id, VehicleOwner vehicleOwner)
    {
        if (id != vehicleOwner.OwnershipID)
        {
            return BadRequest();
        }

        _context.Entry(vehicleOwner).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    // DELETE: api/VehicleOwner/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicleOwner(int id)
    {
        var vehicleOwner = await _context.VehicleOwner.FindAsync(id);
        if (vehicleOwner == null)
        {
            return NotFound();
        }
        
        _context.VehicleOwner.Remove(vehicleOwner);
        await _context.SaveChangesAsync();

        return NoContent();
    }
        
    
    private bool VehicleOwnerExists(int id)
    {
        return _context.VehicleOwner.Any(e => e.OwnershipID == id);
    }
    
    
}