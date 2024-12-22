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
    public class DishProductService : IDishProductService
    {
        private readonly IDishProductRepository _dishProductRepository;

        public DishProductService(IDishProductRepository dishProductRepository)
        {
            _dishProductRepository = dishProductRepository;
        }

        public async Task<DishProduct?> GetByIdAsync(int id) => await _dishProductRepository.GetByIdAsync(id);

        public async Task<IEnumerable<DishProduct>> GetAllAsync() => await _dishProductRepository.GetAllAsync();

        public async Task AddAsync(DishProduct entity) => await _dishProductRepository.AddAsync(entity);

        public async Task UpdateAsync(DishProduct entity) => await _dishProductRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _dishProductRepository.DeleteAsync(id);
    }
}