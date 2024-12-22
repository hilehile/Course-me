using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public DietController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diet>>> GetDiets()
        {
            return await _context.Diets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Diet>> GetDiet(int id)
        {
            var diet = await _context.Diets.FindAsync(id);

            if (diet == null)
            {
                return NotFound();
            }

            return diet;
        }

        [HttpPost]
        public async Task<ActionResult<Diet>> CreateDiet(Diet diet)
        {
            _context.Diets.Add(diet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDiet), new { id = diet.DietId }, diet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiet(int id, Diet diet)
        {
            if (id != diet.DietId)
            {
                return BadRequest();
            }

            _context.Entry(diet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Diets.Any(e => e.DietId == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiet(int id)
        {
            var diet = await _context.Diets.FindAsync(id);

            if (diet == null)
            {
                return NotFound();
            }

            _context.Diets.Remove(diet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
