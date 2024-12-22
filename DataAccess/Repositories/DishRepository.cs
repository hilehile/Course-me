using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly MecourselaContext _context;

        public DishRepository(MecourselaContext context) => _context = context;

        public async Task<Dish?> GetByIdAsync(int id) => await _context.Dishes.FindAsync(id);

        public async Task<IEnumerable<Dish>> GetAllAsync() => await _context.Dishes.ToListAsync();

        public async Task AddAsync(Dish entity)
        {
            await _context.Dishes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dish entity)
        {
            _context.Dishes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Dishes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}