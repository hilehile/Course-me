using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDietRepository
    {
        Task<Diet?> GetByIdAsync(int id);
        Task<IEnumerable<Diet>> GetAllAsync();
        Task AddAsync(Diet entity);
        Task UpdateAsync(Diet entity);
        Task DeleteAsync(int id);
    }
}
