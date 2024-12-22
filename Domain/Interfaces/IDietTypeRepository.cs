using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDietTypeRepository
    {
        Task<DietType?> GetByIdAsync(int id);
        Task<IEnumerable<DietType>> GetAllAsync();
        Task AddAsync(DietType entity);
        Task UpdateAsync(DietType entity);
        Task DeleteAsync(int id);
    }
}
