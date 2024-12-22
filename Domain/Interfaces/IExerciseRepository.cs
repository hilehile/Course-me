using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IExerciseRepository
    {
        Task<Exercise?> GetByIdAsync(int id);
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task AddAsync(Exercise entity);
        Task UpdateAsync(Exercise entity);
        Task DeleteAsync(int id);
    }
}
