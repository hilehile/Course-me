using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article?> GetByIdAsync(int id);
        Task<IEnumerable<Article>> GetAllAsync();
        Task AddAsync(Article entity);
        Task UpdateAsync(Article entity);
        Task DeleteAsync(int id);
    }
}
