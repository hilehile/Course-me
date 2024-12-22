using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterIntakeController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public WaterIntakeController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterIntake>>> GetWaterIntakes()
        {
            return await _context.WaterIntakes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WaterIntake>> GetWaterIntake(int id)
        {
            var waterIntake = await _context.WaterIntakes.FindAsync(id);

            if (waterIntake == null)
            {
                return NotFound();
            }

            return waterIntake;
        }

        [HttpPost]
        public async Task<ActionResult<WaterIntake>> CreateWaterIntake(WaterIntake waterIntake)
        {
            _context.WaterIntakes.Add(waterIntake);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWaterIntake), new { id = waterIntake.WaterIntakeId }, waterIntake);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWaterIntake(int id, WaterIntake waterIntake)
        {
            if (id != waterIntake.WaterIntakeId)
            {
                return BadRequest();
            }

            _context.Entry(waterIntake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.WaterIntakes.Any(e => e.WaterIntakeId == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaterIntake(int id)
        {
            var waterIntake = await _context.WaterIntakes.FindAsync(id);

            if (waterIntake == null)
            {
                return NotFound();
            }

            _context.WaterIntakes.Remove(waterIntake);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
