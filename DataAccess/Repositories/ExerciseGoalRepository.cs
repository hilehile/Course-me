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
    public class ExerciseGoalRepository : IExerciseGoalRepository
    {
        private readonly MecourselaContext _context;

        public ExerciseGoalRepository(MecourselaContext context) => _context = context;

        public async Task<ExerciseGoal?> GetByIdAsync(int id) => await _context.ExerciseGoals.FindAsync(id);

        public async Task<IEnumerable<ExerciseGoal>> GetAllAsync() => await _context.ExerciseGoals.ToListAsync();

        public async Task AddAsync(ExerciseGoal entity)
        {
            await _context.ExerciseGoals.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExerciseGoal entity)
        {
            _context.ExerciseGoals.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.ExerciseGoals.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}