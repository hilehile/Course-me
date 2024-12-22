using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IAnalyticService
    {
        Task<Analytic?> GetByIdAsync(int id);
        Task<IEnumerable<Analytic>> GetAllAsync();
        Task AddAsync(Analytic analytic);
        Task UpdateAsync(Analytic analytic);
        Task DeleteAsync(int id);
    }
}
