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
    public class ReminderRepository : IReminderRepository
    {
        private readonly MecourselaContext _context;

        public ReminderRepository(MecourselaContext context) => _context = context;

        public async Task<Reminder?> GetByIdAsync(int id) => await _context.Reminders.FindAsync(id);

        public async Task<IEnumerable<Reminder>> GetAllAsync() => await _context.Reminders.ToListAsync();

        public async Task AddAsync(Reminder entity)
        {
            await _context.Reminders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reminder entity)
        {
            _context.Reminders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Reminders.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}