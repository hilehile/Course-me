using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDishService
    {
        Task<Dish?> GetByIdAsync(int id);
        Task<IEnumerable<Dish>> GetAllAsync();
        Task AddAsync(Dish dish);
        Task UpdateAsync(Dish dish);
        Task DeleteAsync(int id);
    }
}
