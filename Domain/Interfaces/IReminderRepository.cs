using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IReminderRepository
    {
        Task<Reminder?> GetByIdAsync(int id);
        Task<IEnumerable<Reminder>> GetAllAsync();
        Task AddAsync(Reminder entity);
        Task UpdateAsync(Reminder entity);
        Task DeleteAsync(int id);
    }
}
