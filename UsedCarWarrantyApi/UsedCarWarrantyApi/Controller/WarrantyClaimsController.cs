using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedCarWarrantyApi.Data;
using UsedCarWarrantyApi.Models;

namespace UsedCarWarrantyApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyClaimsController : ControllerBase
    {
        private readonly WarrantyDbContext _context;

        public WarrantyClaimsController(WarrantyDbContext context)
        {
            _context = context;
        }
        
        
        // GET: api/WarrantyClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarrantyClaims>>> GetWarrantyClaims()
        {
            return await _context.WarrantyClaims
                .Include(wc => wc.Warranty) // Eagerly load the Warranty
                .ThenInclude(w => w.Vehicle) // And also include the Vehicle related to the Warranty
                .ToListAsync();
        }
        
        // POST: api/WarrantyClaims
        [HttpPost]
        public async Task<ActionResult<WarrantyClaims>> PostWarrantyClaims(WarrantyClaims warrantyClaims)
        {
            _context.WarrantyClaims.Add(warrantyClaims);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWarrantyClaims), new { id = warrantyClaims.ClaimID }, warrantyClaims);
        }
        
        // GET: api/WarrantyClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarrantyClaims>> GetWarrantyClaims(int id)
        {
            var warrantyClaims = await _context.WarrantyClaims
                .Include(wc => wc.Warranty) // Eagerly load the Warranty
                .ThenInclude(w => w.Vehicle) // And also include the Vehicle related to the Warranty
                .FirstOrDefaultAsync(wc => wc.ClaimID == id);

            if (warrantyClaims == null)
            {
                return NotFound();
            }

            return warrantyClaims;
        }
        
        // PUT: api/WarrantyClaims/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarrantyClaims(int id, WarrantyClaims warrantyClaims)
        {
            if (id != warrantyClaims.ClaimID)
            {
                return BadRequest();
            }

            _context.Entry(warrantyClaims).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        
        // DELETE: api/WarrantyClaims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarrantyClaims(int id)
        {
            var warrantyClaims = await _context.WarrantyClaims.FindAsync(id);
            if (warrantyClaims == null)
            {
                return NotFound();
            }
            
            _context.WarrantyClaims.Remove(warrantyClaims);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
