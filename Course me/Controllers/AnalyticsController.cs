using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using BusinessLogic.Services;
using DataAccess;
using Domain.Interfaces;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticController : ControllerBase
    {
        private readonly IAnalyticService _analyticService;

        public AnalyticController(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var analytics = await _analyticService.GetAllAsync();
            return Ok(analytics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var analytic = await _analyticService.GetByIdAsync(id);
            if (analytic == null) return NotFound();
            return Ok(analytic);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Analytic analytic)
        {
            await _analyticService.AddAsync(analytic);
            return CreatedAtAction(nameof(GetById), new { id = analytic.AnalyticsId }, analytic);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Analytic analytic)
        {
            await _analyticService.UpdateAsync(analytic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _analyticService.DeleteAsync(id);
            return NoContent();
        }
    }
}
