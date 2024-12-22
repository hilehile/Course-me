using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDietService
    {
        Task<Diet?> GetByIdAsync(int id);
        Task<IEnumerable<Diet>> GetAllAsync();
        Task AddAsync(Diet diet);
        Task UpdateAsync(Diet diet);
        Task DeleteAsync(int id);
    }
}
