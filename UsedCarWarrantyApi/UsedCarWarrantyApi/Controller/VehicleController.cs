using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedCarWarrantyApi.Data;
using UsedCarWarrantyApi.Models;

namespace UsedCarWarrantyApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(WarrantyDbContext context) : ControllerBase
    {
        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            return await context.Vehicle.ToListAsync();
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await context.Vehicle.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }
        
        // GET: api/Vehicle/ByMake/Toyota
        [HttpGet("ByMake/{make}")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicleByMake(string make)
        {
            return await context.Vehicle.Where(v => v.Make == make).ToListAsync();
        }
        
        // POST: api/Vehicle
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            context.Vehicle.Add(vehicle);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleID }, vehicle);
        }
        
        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleID)
            {
                return BadRequest();
            }

            context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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
        
        
        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            context.Vehicle.Remove(vehicle);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleExists(int id)
        {
            return context.Vehicle.Any(e => e.VehicleID == id);
        }
    }
}