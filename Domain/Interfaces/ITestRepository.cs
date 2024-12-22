using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface ITestRepository
    {
        Task<Test?> GetByIdAsync(int id);
        Task<IEnumerable<Test>> GetAllAsync();
        Task AddAsync(Test entity);
        Task UpdateAsync(Test entity);
        Task DeleteAsync(int id);
    }
}
