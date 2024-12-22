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
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Exercise?> GetByIdAsync(int id) => await _exerciseRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Exercise>> GetAllAsync() => await _exerciseRepository.GetAllAsync();

        public async Task AddAsync(Exercise entity) => await _exerciseRepository.AddAsync(entity);

        public async Task UpdateAsync(Exercise entity) => await _exerciseRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _exerciseRepository.DeleteAsync(id);
    }
}