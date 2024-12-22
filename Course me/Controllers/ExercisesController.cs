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
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _exerciseService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _exerciseService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Exercise exercise)
        {
            await _exerciseService.AddAsync(exercise);
            return CreatedAtAction(nameof(GetById), new { id = exercise.ExerciseId }, exercise);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Exercise exercise)
        {
            await _exerciseService.UpdateAsync(exercise);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exerciseService.DeleteAsync(id);
            return NoContent();
        }
    }
}