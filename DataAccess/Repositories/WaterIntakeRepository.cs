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
    public class WaterIntakeRepository : IWaterIntakeRepository
    {
        private readonly MecourselaContext _context;

        public WaterIntakeRepository(MecourselaContext context) => _context = context;

        public async Task<WaterIntake?> GetByIdAsync(int id) => await _context.WaterIntakes.FindAsync(id);

        public async Task<IEnumerable<WaterIntake>> GetAllAsync() => await _context.WaterIntakes.ToListAsync();

        public async Task AddAsync(WaterIntake entity)
        {
            await _context.WaterIntakes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WaterIntake entity)
        {
            _context.WaterIntakes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.WaterIntakes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}