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
    public class DishProductRepository : IDishProductRepository
    {
        private readonly MecourselaContext _context;

        public DishProductRepository(MecourselaContext context) => _context = context;

        public async Task<DishProduct?> GetByIdAsync(int id) => await _context.DishProducts.FindAsync(id);

        public async Task<IEnumerable<DishProduct>> GetAllAsync() => await _context.DishProducts.ToListAsync();

        public async Task AddAsync(DishProduct entity)
        {
            await _context.DishProducts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DishProduct entity)
        {
            _context.DishProducts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.DishProducts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}