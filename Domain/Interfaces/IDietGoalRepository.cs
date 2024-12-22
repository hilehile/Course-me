using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDietGoalRepository
    {
        Task<DietGoal?> GetByIdAsync(int id);
        Task<IEnumerable<DietGoal>> GetAllAsync();
        Task AddAsync(DietGoal entity);
        Task UpdateAsync(DietGoal entity);
        Task DeleteAsync(int id);
    }
}
