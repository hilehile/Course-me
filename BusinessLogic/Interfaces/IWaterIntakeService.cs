using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IWaterIntakeService
    {
        Task<WaterIntake?> GetByIdAsync(int id);
        Task<IEnumerable<WaterIntake>> GetAllAsync();
        Task AddAsync(WaterIntake waterIntake);
        Task UpdateAsync(WaterIntake waterIntake);
        Task DeleteAsync(int id);
    }
}
