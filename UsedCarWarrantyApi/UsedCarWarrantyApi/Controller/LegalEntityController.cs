using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedCarWarrantyApi.Data;
using UsedCarWarrantyApi.Models;

namespace UsedCarWarrantyApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class LegalEntityController(WarrantyDbContext context) : ControllerBase
{
    // GET: api/LegalEntities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LegalEntity>>> GetLegalEntities()
    {
        return await context.LegalEntity.ToListAsync();
    }

    // POST: api/LegalEntities
    [HttpPost]
    public async Task<ActionResult<LegalEntity>> PostLegalEntity(LegalEntity legalEntity)
    {
        context.LegalEntity.Add(legalEntity);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLegalEntity), new { id = legalEntity.EntityID }, legalEntity);
    }

    // GET: api/LegalEntities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LegalEntity>> GetLegalEntity(int id)
    {
        var legalEntity = await context.LegalEntity.FindAsync(id);

        if (legalEntity == null)
        {
            return NotFound();
        }

        return legalEntity;
    }
    
    // GET: api/LegalEntities/ByType
    [HttpGet("ByType/{type}")]
    public async Task<ActionResult<IEnumerable<LegalEntity>>> GetLegalEntityByType(string type)
    {
        return await context.LegalEntity.Where(le => le.EntityType == type).ToListAsync();
    }
    
    // PUT: api/LegalEntities/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLegalEntity(int id, LegalEntity legalEntity)
    {
        if (id != legalEntity.EntityID)
        {
            return BadRequest();
        }

        context.Entry(legalEntity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // DELETE: api/LegalEntities/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLegalEntity(int id)
    {
        var legalEntity = await context.LegalEntity.FindAsync(id);
        if (legalEntity == null)
        {
            return NotFound();
        }
        
        context.LegalEntity.Remove(legalEntity);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    
    private bool LegalEntityExists(int id)
    {
        return context.LegalEntity.Any(e => e.EntityID == id);
    }
}