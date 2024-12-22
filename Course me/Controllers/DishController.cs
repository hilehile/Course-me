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
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _dishService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _dishService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Dish dish)
        {
            await _dishService.AddAsync(dish);
            return CreatedAtAction(nameof(GetById), new { id = dish.DishId }, dish);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Dish dish)
        {
            await _dishService.UpdateAsync(dish);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dishService.DeleteAsync(id);
            return NoContent();
        }
    }
}
