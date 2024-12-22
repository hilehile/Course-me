using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDishProductService
    {
        Task<DishProduct?> GetByIdAsync(int id);
        Task<IEnumerable<DishProduct>> GetAllAsync();
        Task AddAsync(DishProduct dishProduct);
        Task UpdateAsync(DishProduct dishProduct);
        Task DeleteAsync(int id);
    }
}
