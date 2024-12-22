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
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _workoutService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _workoutService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(Workout workout)
        {
            await _workoutService.AddAsync(workout);
            return CreatedAtAction(nameof(GetById), new { id = workout.WorkoutId }, workout);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Workout workout)
        {
            await _workoutService.UpdateAsync(workout);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workoutService.DeleteAsync(id);
            return NoContent();
        }
    }
}
