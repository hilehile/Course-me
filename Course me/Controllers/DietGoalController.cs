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
    public class DietGoalController : ControllerBase
    {
        private readonly IDietGoalService _dietGoalService;

        public DietGoalController(IDietGoalService dietGoalService)
        {
            _dietGoalService = dietGoalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _dietGoalService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _dietGoalService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(DietGoal dietGoal)
        {
            await _dietGoalService.AddAsync(dietGoal);
            return CreatedAtAction(nameof(GetById), new { id = dietGoal.DietGoalId }, dietGoal);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DietGoal dietGoal)
        {
            await _dietGoalService.UpdateAsync(dietGoal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dietGoalService.DeleteAsync(id);
            return NoContent();
        }
    }
}
