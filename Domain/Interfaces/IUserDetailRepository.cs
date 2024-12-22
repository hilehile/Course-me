using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IUserDetailRepository
    {
        Task<UserDetail?> GetByIdAsync(int id);
        Task<IEnumerable<UserDetail>> GetAllAsync();
        Task AddAsync(UserDetail entity);
        Task UpdateAsync(UserDetail entity);
        Task DeleteAsync(int id);
    }
}
