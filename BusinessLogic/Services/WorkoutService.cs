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
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<Workout?> GetByIdAsync(int id) => await _workoutRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Workout>> GetAllAsync() => await _workoutRepository.GetAllAsync();

        public async Task AddAsync(Workout entity) => await _workoutRepository.AddAsync(entity);

        public async Task UpdateAsync(Workout entity) => await _workoutRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _workoutRepository.DeleteAsync(id);
    }
}