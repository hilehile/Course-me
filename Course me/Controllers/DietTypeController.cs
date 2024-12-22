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
    public class DietTypeController : ControllerBase
    {
        private readonly IDietTypeService _dietTypeService;

        public DietTypeController(IDietTypeService dietTypeService)
        {
            _dietTypeService = dietTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _dietTypeService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _dietTypeService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(DietType dietType)
        {
            await _dietTypeService.AddAsync(dietType);
            return CreatedAtAction(nameof(GetById), new { id = dietType.DietTypeId }, dietType);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DietType dietType)
        {
            await _dietTypeService.UpdateAsync(dietType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dietTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
