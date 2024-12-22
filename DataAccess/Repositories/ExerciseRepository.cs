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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly MecourselaContext _context;

        public ExerciseRepository(MecourselaContext context) => _context = context;

        public async Task<Exercise?> GetByIdAsync(int id) => await _context.Exercises.FindAsync(id);

        public async Task<IEnumerable<Exercise>> GetAllAsync() => await _context.Exercises.ToListAsync();

        public async Task AddAsync(Exercise entity)
        {
            await _context.Exercises.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Exercise entity)
        {
            _context.Exercises.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Exercises.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}