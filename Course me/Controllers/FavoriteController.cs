using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public FavoriteController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var favorites = _context.Favorites.Include(f => f.User).ToList();
            return Ok(favorites);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var favorite = _context.Favorites.Include(f => f.User).FirstOrDefault(f => f.FavoriteId == id);
            if (favorite == null)
            {
                return NotFound(new { message = "Favorite not found" });
            }
            return Ok(favorite);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Favorite favorite)
        {
            if (favorite == null)
            {
                return BadRequest(new { message = "Invalid data" });
            }

            _context.Favorites.Add(favorite);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = favorite.FavoriteId }, favorite);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Favorite updatedFavorite)
        {
            if (updatedFavorite == null || updatedFavorite.FavoriteId != id)
            {
                return BadRequest(new { message = "Invalid data" });
            }

            var existingFavorite = _context.Favorites.FirstOrDefault(f => f.FavoriteId == id);
            if (existingFavorite == null)
            {
                return NotFound(new { message = "Favorite not found" });
            }

            existingFavorite.ItemId = updatedFavorite.ItemId;
            existingFavorite.ItemType = updatedFavorite.ItemType;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var favorite = _context.Favorites.FirstOrDefault(f => f.FavoriteId == id);
            if (favorite == null)
            {
                return NotFound(new { message = "Favorite not found" });
            }

            _context.Favorites.Remove(favorite);
            _context.SaveChanges();
            return NoContent();
        }
    }
}