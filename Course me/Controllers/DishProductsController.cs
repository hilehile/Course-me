using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_me.Models;

namespace Course_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishProductController : ControllerBase
    {
        private readonly MecourselaContext _context;

        public DishProductController(MecourselaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishProduct>>> GetDishProducts()
        {
            return await _context.DishProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishProduct>> GetDishProduct(int id)
        {
            var dishProduct = await _context.DishProducts.FindAsync(id);

            if (dishProduct == null)
            {
                return NotFound();
            }

            return dishProduct;
        }

        [HttpPost]
        public async Task<ActionResult<DishProduct>> CreateDishProduct(DishProduct dishProduct)
        {
            _context.DishProducts.Add(dishProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDishProduct), new { id = dishProduct.DishProductId }, dishProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDishProduct(int id, DishProduct dishProduct)
        {
            if (id != dishProduct.DishProductId)
            {
                return BadRequest();
            }

            _context.Entry(dishProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DishProducts.Any(e => e.DishProductId == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishProduct(int id)
        {
            var dishProduct = await _context.DishProducts.FindAsync(id);

            if (dishProduct == null)
            {
                return NotFound();
            }

            _context.DishProducts.Remove(dishProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
