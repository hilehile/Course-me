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
    public class DietTypeRepository : IDietTypeRepository
    {
        private readonly MecourselaContext _context;

        public DietTypeRepository(MecourselaContext context) => _context = context;

        public async Task<DietType?> GetByIdAsync(int id) => await _context.DietTypes.FindAsync(id);

        public async Task<IEnumerable<DietType>> GetAllAsync() => await _context.DietTypes.ToListAsync();

        public async Task AddAsync(DietType entity)
        {
            await _context.DietTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DietType entity)
        {
            _context.DietTypes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.DietTypes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}