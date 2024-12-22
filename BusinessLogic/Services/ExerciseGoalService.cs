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
    public class ExerciseGoalService : IExerciseGoalService
    {
        private readonly IExerciseGoalRepository _exerciseGoalRepository;

        public ExerciseGoalService(IExerciseGoalRepository exerciseGoalRepository)
        {
            _exerciseGoalRepository = exerciseGoalRepository;
        }

        public async Task<ExerciseGoal?> GetByIdAsync(int id) => await _exerciseGoalRepository.GetByIdAsync(id);

        public async Task<IEnumerable<ExerciseGoal>> GetAllAsync() => await _exerciseGoalRepository.GetAllAsync();

        public async Task AddAsync(ExerciseGoal entity) => await _exerciseGoalRepository.AddAsync(entity);

        public async Task UpdateAsync(ExerciseGoal entity) => await _exerciseGoalRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _exerciseGoalRepository.DeleteAsync(id);
    }
}