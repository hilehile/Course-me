using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;
namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietGoalController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public DietGoalController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietGoal>>> GetDietGoals()
        {
            return await _context.DietGoals.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DietGoal>> GetDietGoal(int id)
        {
            var dietGoal = await _context.DietGoals.FindAsync(id);

            if (dietGoal == null)
            {
                return NotFound();
            }

            return dietGoal;
        }

        [HttpPost]
        public async Task<ActionResult<DietGoal>> CreateDietGoal(DietGoal dietGoal)
        {
            _context.DietGoals.Add(dietGoal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDietGoal), new { id = dietGoal.DietGoalId }, dietGoal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDietGoal(int id, DietGoal dietGoal)
        {
            if (id != dietGoal.DietGoalId)
            {
                return BadRequest();
            }

            _context.Entry(dietGoal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DietGoals.Any(e => e.DietGoalId == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietGoal(int id)
        {
            var dietGoal = await _context.DietGoals.FindAsync(id);

            if (dietGoal == null)
            {
                return NotFound();
            }

            _context.DietGoals.Remove(dietGoal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
