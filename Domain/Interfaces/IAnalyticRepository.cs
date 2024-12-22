using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IAnalyticRepository
    {
        Task<Analytic?> GetByIdAsync(int id);
        Task<IEnumerable<Analytic>> GetAllAsync();
        Task AddAsync(Analytic entity);
        Task UpdateAsync(Analytic entity);
        Task DeleteAsync(int id);
    }
}
