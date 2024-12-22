using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IWorkoutService
    {
        Task<Workout?> GetByIdAsync(int id);
        Task<IEnumerable<Workout>> GetAllAsync();
        Task AddAsync(Workout workout);
        Task UpdateAsync(Workout workout);
        Task DeleteAsync(int id);
    }
}
