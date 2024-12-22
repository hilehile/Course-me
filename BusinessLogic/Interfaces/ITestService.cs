using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface ITestService
    {
        Task<Test?> GetByIdAsync(int id);
        Task<IEnumerable<Test>> GetAllAsync();
        Task AddAsync(Test test);
        Task UpdateAsync(Test test);
        Task DeleteAsync(int id);
    }
}