using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IFavoriteService
    {
        Task<Favorite?> GetByIdAsync(int id);
        Task<IEnumerable<Favorite>> GetAllAsync();
        Task AddAsync(Favorite favorite);
        Task UpdateAsync(Favorite favorite);
        Task DeleteAsync(int id);
    }
}
