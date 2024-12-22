using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseGoalController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public ExerciseGoalController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseGoal>>> GetExerciseGoals()
        {
            return await _context.ExerciseGoals.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseGoal>> GetExerciseGoal(int id)
        {
            var exerciseGoal = await _context.ExerciseGoals.FindAsync(id);

            if (exerciseGoal == null)
            {
                return NotFound();
            }

            return exerciseGoal;
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseGoal>> CreateExerciseGoal(ExerciseGoal exerciseGoal)
        {
            _context.ExerciseGoals.Add(exerciseGoal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExerciseGoal), new { id = exerciseGoal.ExerciseGoalId }, exerciseGoal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseGoal(int id, ExerciseGoal exerciseGoal)
        {
            if (id != exerciseGoal.ExerciseGoalId)
            {
                return BadRequest();
            }

            _context.Entry(exerciseGoal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ExerciseGoals.Any(e => e.ExerciseGoalId == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseGoal(int id)
        {
            var exerciseGoal = await _context.ExerciseGoals.FindAsync(id);

            if (exerciseGoal == null)
            {
                return NotFound();
            }

            _context.ExerciseGoals.Remove(exerciseGoal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
