using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUserDetailRepository _userDetailRepository;

        public UserDetailService(IUserDetailRepository userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }

        public async Task<UserDetail?> GetByIdAsync(int id) => await _userDetailRepository.GetByIdAsync(id);

        public async Task<IEnumerable<UserDetail>> GetAllAsync() => await _userDetailRepository.GetAllAsync();

        public async Task AddAsync(UserDetail entity) => await _userDetailRepository.AddAsync(entity);

        public async Task UpdateAsync(UserDetail entity) => await _userDetailRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _userDetailRepository.DeleteAsync(id);
    }
}