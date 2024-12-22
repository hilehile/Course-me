using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IArticleService
    {
        Task<Article?> GetByIdAsync(int id);
        Task<IEnumerable<Article>> GetAllAsync();
        Task AddAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(int id);
    }
}
