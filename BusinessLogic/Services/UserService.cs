using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Domain.Interfaces;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByIdAsync(int id) => await _userRepository.GetByIdAsync(id);

        public async Task<IEnumerable<User>> GetAllAsync() => await _userRepository.GetAllAsync();

        public async Task AddAsync(User entity) => await _userRepository.AddAsync(entity);

        public async Task UpdateAsync(User entity) => await _userRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _userRepository.DeleteAsync(id);
    }
}
