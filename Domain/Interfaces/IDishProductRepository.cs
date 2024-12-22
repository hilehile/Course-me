using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDishProductRepository
    {
        Task<DishProduct?> GetByIdAsync(int id);
        Task<IEnumerable<DishProduct>> GetAllAsync();
        Task AddAsync(DishProduct entity);
        Task UpdateAsync(DishProduct entity);
        Task DeleteAsync(int id);
    }
}
