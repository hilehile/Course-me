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
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;

        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task<Dish?> GetByIdAsync(int id) => await _dishRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Dish>> GetAllAsync() => await _dishRepository.GetAllAsync();

        public async Task AddAsync(Dish entity) => await _dishRepository.AddAsync(entity);

        public async Task UpdateAsync(Dish entity) => await _dishRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _dishRepository.DeleteAsync(id);
    }
}