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
    public class DietController : ControllerBase
    {
        private readonly IDietService _dietService;

        public DietController(IDietService dietService)
        {
            _dietService = dietService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diets = await _dietService.GetAllAsync();
            return Ok(diets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var diet = await _dietService.GetByIdAsync(id);
            if (diet == null) return NotFound();
            return Ok(diet);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Diet diet)
        {
            await _dietService.AddAsync(diet);
            return CreatedAtAction(nameof(GetById), new { id = diet.DietId }, diet);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Diet diet)
        {
            await _dietService.UpdateAsync(diet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dietService.DeleteAsync(id);
            return NoContent();
        }
    }
}
