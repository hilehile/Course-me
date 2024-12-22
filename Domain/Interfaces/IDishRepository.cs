using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDishRepository
    {
        Task<Dish?> GetByIdAsync(int id);
        Task<IEnumerable<Dish>> GetAllAsync();
        Task AddAsync(Dish entity);
        Task UpdateAsync(Dish entity);
        Task DeleteAsync(int id);
    }
}
