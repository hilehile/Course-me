using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IWaterIntakeRepository
    {
        Task<WaterIntake?> GetByIdAsync(int id);
        Task<IEnumerable<WaterIntake>> GetAllAsync();
        Task AddAsync(WaterIntake entity);
        Task UpdateAsync(WaterIntake entity);
        Task DeleteAsync(int id);

    }
}
