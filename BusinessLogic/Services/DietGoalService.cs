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
    public class DietGoalService : IDietGoalService
    {
        private readonly IDietGoalRepository _dietGoalRepository;

        public DietGoalService(IDietGoalRepository dietGoalRepository)
        {
            _dietGoalRepository = dietGoalRepository;
        }

        public async Task<DietGoal?> GetByIdAsync(int id) => await _dietGoalRepository.GetByIdAsync(id);

        public async Task<IEnumerable<DietGoal>> GetAllAsync() => await _dietGoalRepository.GetAllAsync();

        public async Task AddAsync(DietGoal entity) => await _dietGoalRepository.AddAsync(entity);

        public async Task UpdateAsync(DietGoal entity) => await _dietGoalRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _dietGoalRepository.DeleteAsync(id);
    }
}