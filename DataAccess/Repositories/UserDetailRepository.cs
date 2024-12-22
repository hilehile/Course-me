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
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly MecourselaContext _context;

        public UserDetailRepository(MecourselaContext context) => _context = context;

        public async Task<UserDetail?> GetByIdAsync(int id) => await _context.UserDetails.FindAsync(id);

        public async Task<IEnumerable<UserDetail>> GetAllAsync() => await _context.UserDetails.ToListAsync();

        public async Task AddAsync(UserDetail entity)
        {
            await _context.UserDetails.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserDetail entity)
        {
            _context.UserDetails.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.UserDetails.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}