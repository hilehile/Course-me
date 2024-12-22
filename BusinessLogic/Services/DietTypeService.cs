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
    public class DietTypeService : IDietTypeService
    {
        private readonly IDietTypeRepository _dietTypeRepository;

        public DietTypeService(IDietTypeRepository dietTypeRepository)
        {
            _dietTypeRepository = dietTypeRepository;
        }

        public async Task<DietType?> GetByIdAsync(int id) => await _dietTypeRepository.GetByIdAsync(id);

        public async Task<IEnumerable<DietType>> GetAllAsync() => await _dietTypeRepository.GetAllAsync();

        public async Task AddAsync(DietType entity) => await _dietTypeRepository.AddAsync(entity);

        public async Task UpdateAsync(DietType entity) => await _dietTypeRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _dietTypeRepository.DeleteAsync(id);
    }
}