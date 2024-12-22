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
    public class DietGoalRepository : IDietGoalRepository
    {
        private readonly MecourselaContext _context;

        public DietGoalRepository(MecourselaContext context) => _context = context;

        public async Task<DietGoal?> GetByIdAsync(int id) => await _context.DietGoals.FindAsync(id);

        public async Task<IEnumerable<DietGoal>> GetAllAsync() => await _context.DietGoals.ToListAsync();

        public async Task AddAsync(DietGoal entity)
        {
            await _context.DietGoals.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DietGoal entity)
        {
            _context.DietGoals.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.DietGoals.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}