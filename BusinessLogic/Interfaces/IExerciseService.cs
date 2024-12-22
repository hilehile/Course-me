using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IExerciseService
    {
        Task<Exercise?> GetByIdAsync(int id);
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task AddAsync(Exercise exercise);
        Task UpdateAsync(Exercise exercise);
        Task DeleteAsync(int id);
    }
}
