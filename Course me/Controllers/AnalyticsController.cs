using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public AnalyticsController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analytic>>> GetAnalytics()
        {
            return await _context.Analytics.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Analytic>> GetAnalytics(int id)
        {
            var analytics = await _context.Analytics.FindAsync(id);

            if (analytics == null)
            {
                return NotFound();
            }

            return analytics;
        }

        [HttpPost]
        public async Task<ActionResult<Analytic>> CreateAnalytics(Analytic analytics)
        {
            _context.Analytics.Add(analytics);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnalytics), new { id = analytics.AnalyticsId }, analytics);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnalytics(int id, Analytic analytics)
        {
            if (id != analytics.AnalyticsId)
            {
                return BadRequest();
            }

            _context.Entry(analytics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Analytics.Any(e => e.AnalyticsId == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalytics(int id)
        {
            var analytics = await _context.Analytics.FindAsync(id);

            if (analytics == null)
            {
                return NotFound();
            }

            _context.Analytics.Remove(analytics);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
