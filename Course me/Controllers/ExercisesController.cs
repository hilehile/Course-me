using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public ExercisesController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exercises = _context.Exercises.ToList();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var exercise = _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);
            if (exercise == null)
            {
                return NotFound(new { message = "Exercise not found" });
            }
            return Ok(exercise);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Exercise exercise)
        {
            if (exercise == null)
            {
                return BadRequest(new { message = "Invalid data" });
            }

            _context.Exercises.Add(exercise);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = exercise.ExerciseId }, exercise);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Exercise updatedExercise)
        {
            if (updatedExercise == null || updatedExercise.ExerciseId != id)
            {
                return BadRequest(new { message = "Invalid data" });
            }

            var existingExercise = _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);
            if (existingExercise == null)
            {
                return NotFound(new { message = "Exercise not found" });
            }

            existingExercise.Name = updatedExercise.Name;
            existingExercise.CaloriesBurnedPerMinute = updatedExercise.CaloriesBurnedPerMinute;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exercise = _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);
            if (exercise == null)
            {
                return NotFound(new { message = "Exercise not found" });
            }

            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
