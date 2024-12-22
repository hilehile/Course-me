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
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;

        public DietService(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }

        public async Task<Diet?> GetByIdAsync(int id) => await _dietRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Diet>> GetAllAsync() => await _dietRepository.GetAllAsync();

        public async Task AddAsync(Diet entity) => await _dietRepository.AddAsync(entity);

        public async Task UpdateAsync(Diet entity) => await _dietRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _dietRepository.DeleteAsync(id);
    }
}
