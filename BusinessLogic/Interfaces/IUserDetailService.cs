using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IUserDetailService
    {
        Task<UserDetail?> GetByIdAsync(int id);
        Task<IEnumerable<UserDetail>> GetAllAsync();
        Task AddAsync(UserDetail userDetail);
        Task UpdateAsync(UserDetail userDetail);
        Task DeleteAsync(int id);
    }
}
