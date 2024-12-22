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
    public class WaterIntakeService : IWaterIntakeService
    {
        private readonly IWaterIntakeRepository _waterIntakeRepository;

        public WaterIntakeService(IWaterIntakeRepository waterIntakeRepository)
        {
            _waterIntakeRepository = waterIntakeRepository;
        }

        public async Task<WaterIntake?> GetByIdAsync(int id) => await _waterIntakeRepository.GetByIdAsync(id);

        public async Task<IEnumerable<WaterIntake>> GetAllAsync() => await _waterIntakeRepository.GetAllAsync();

        public async Task AddAsync(WaterIntake entity) => await _waterIntakeRepository.AddAsync(entity);

        public async Task UpdateAsync(WaterIntake entity) => await _waterIntakeRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _waterIntakeRepository.DeleteAsync(id);
    }
}