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
    public class TestRepository : ITestRepository
    {
        private readonly MecourselaContext _context;

        public TestRepository(MecourselaContext context) => _context = context;

        public async Task<Test?> GetByIdAsync(int id) => await _context.Tests.FindAsync(id);

        public async Task<IEnumerable<Test>> GetAllAsync() => await _context.Tests.ToListAsync();

        public async Task AddAsync(Test entity)
        {
            await _context.Tests.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Test entity)
        {
            _context.Tests.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Tests.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}