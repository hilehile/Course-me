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
    public class WaterIntakeController : ControllerBase
    {
        private readonly IWaterIntakeService _waterIntakeService;

        public WaterIntakeController(IWaterIntakeService waterIntakeService)
        {
            _waterIntakeService = waterIntakeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _waterIntakeService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _waterIntakeService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(WaterIntake waterIntake)
        {
            await _waterIntakeService.AddAsync(waterIntake);
            return CreatedAtAction(nameof(GetById), new { id = waterIntake.WaterIntakeId }, waterIntake);
        }

        [HttpPut]
        public async Task<IActionResult> Update(WaterIntake waterIntake)
        {
            await _waterIntakeService.UpdateAsync(waterIntake);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _waterIntakeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
