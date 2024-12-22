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
    public class DishProductController : ControllerBase
    {
        private readonly IDishProductService _dishProductService;

        public DishProductController(IDishProductService dishProductService)
        {
            _dishProductService = dishProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _dishProductService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _dishProductService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(DishProduct dishProduct)
        {
            await _dishProductService.AddAsync(dishProduct);
            return CreatedAtAction(nameof(GetById), new { id = dishProduct.DishProductId }, dishProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DishProduct dishProduct)
        {
            await _dishProductService.UpdateAsync(dishProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dishProductService.DeleteAsync(id);
            return NoContent();
        }
    }
}
