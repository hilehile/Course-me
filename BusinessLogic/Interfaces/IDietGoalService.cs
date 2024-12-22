using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDietGoalService
    {
        Task<DietGoal?> GetByIdAsync(int id);
        Task<IEnumerable<DietGoal>> GetAllAsync();
        Task AddAsync(DietGoal dietGoal);
        Task UpdateAsync(DietGoal dietGoal);
        Task DeleteAsync(int id);
    }
}
