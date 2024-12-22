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
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly MecourselaContext _context;

        public WorkoutRepository(MecourselaContext context) => _context = context;

        public async Task<Workout?> GetByIdAsync(int id) => await _context.Workouts.FindAsync(id);

        public async Task<IEnumerable<Workout>> GetAllAsync() => await _context.Workouts.ToListAsync();

        public async Task AddAsync(Workout entity)
        {
            await _context.Workouts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Workout entity)
        {
            _context.Workouts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Workouts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}