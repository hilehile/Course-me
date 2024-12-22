using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<Favorite?> GetByIdAsync(int id);
        Task<IEnumerable<Favorite>> GetAllAsync();
        Task AddAsync(Favorite entity);
        Task UpdateAsync(Favorite entity);
        Task DeleteAsync(int id);
    }
}
