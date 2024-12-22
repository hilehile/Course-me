using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietTypeController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public DietTypeController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietType>>> GetDietTypes()
        {
            return await _context.DietTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DietType>> GetDietType(int id)
        {
            var dietType = await _context.DietTypes.FindAsync(id);

            if (dietType == null)
            {
                return NotFound();
            }

            return dietType;
        }

        [HttpPost]
        public async Task<ActionResult<DietType>> CreateDietType(DietType dietType)
        {
            _context.DietTypes.Add(dietType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDietType), new { id = dietType.DietTypeId }, dietType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDietType(int id, DietType dietType)
        {
            if (id != dietType.DietTypeId)
            {
                return BadRequest();
            }

            _context.Entry(dietType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DietTypes.Any(e => e.DietTypeId == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietType(int id)
        {
            var dietType = await _context.DietTypes.FindAsync(id);

            if (dietType == null)
            {
                return NotFound();
            }

            _context.DietTypes.Remove(dietType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
