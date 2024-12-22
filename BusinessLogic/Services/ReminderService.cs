using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task<Reminder?> GetByIdAsync(int id) => await _reminderRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Reminder>> GetAllAsync() => await _reminderRepository.GetAllAsync();

        public async Task AddAsync(Reminder entity) => await _reminderRepository.AddAsync(entity);

        public async Task UpdateAsync(Reminder entity) => await _reminderRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _reminderRepository.DeleteAsync(id);
    }
}