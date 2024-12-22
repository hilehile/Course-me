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
    public class ExerciseGoalController : ControllerBase
    {
        private readonly IExerciseGoalService _exerciseGoalService;

        public ExerciseGoalController(IExerciseGoalService exerciseGoalService)
        {
            _exerciseGoalService = exerciseGoalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _exerciseGoalService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _exerciseGoalService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(ExerciseGoal exerciseGoal)
        {
            await _exerciseGoalService.AddAsync(exerciseGoal);
            return CreatedAtAction(nameof(GetById), new { id = exerciseGoal.ExerciseGoalId }, exerciseGoal);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ExerciseGoal exerciseGoal)
        {
            await _exerciseGoalService.UpdateAsync(exerciseGoal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exerciseGoalService.DeleteAsync(id);
            return NoContent();
        }
    }
}

