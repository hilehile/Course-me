using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IExerciseGoalService
    {
        Task<ExerciseGoal?> GetByIdAsync(int id);
        Task<IEnumerable<ExerciseGoal>> GetAllAsync();
        Task AddAsync(ExerciseGoal entity);
        Task UpdateAsync(ExerciseGoal entity);
        Task DeleteAsync(int id);
    }
}
