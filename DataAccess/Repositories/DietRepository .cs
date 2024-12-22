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
    public class DietRepository : IDietRepository
    {
        private readonly MecourselaContext _context;

        public DietRepository(MecourselaContext context) => _context = context;

        public async Task<Diet?> GetByIdAsync(int id) => await _context.Diets.FindAsync(id);

        public async Task<IEnumerable<Diet>> GetAllAsync() => await _context.Diets.ToListAsync();

        public async Task AddAsync(Diet entity)
        {
            await _context.Diets.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Diet entity)
        {
            _context.Diets.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Diets.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}