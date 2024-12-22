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
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _favoriteService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _favoriteService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Favorite favorite)
        {
            await _favoriteService.AddAsync(favorite);
            return CreatedAtAction(nameof(GetById), new { id = favorite.FavoriteId }, favorite);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Favorite favorite)
        {
            await _favoriteService.UpdateAsync(favorite);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _favoriteService.DeleteAsync(id);
            return NoContent();
        }
    }
}