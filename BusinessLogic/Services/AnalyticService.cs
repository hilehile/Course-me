using System;
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
    public class AnalyticService : IAnalyticService
    {
        private readonly IAnalyticRepository _analyticRepository;

        public AnalyticService(IAnalyticRepository analyticRepository)
        {
            _analyticRepository = analyticRepository;
        }

        public async Task<Analytic?> GetByIdAsync(int id) => await _analyticRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Analytic>> GetAllAsync() => await _analyticRepository.GetAllAsync();

        public async Task AddAsync(Analytic entity) => await _analyticRepository.AddAsync(entity);

        public async Task UpdateAsync(Analytic entity) => await _analyticRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _analyticRepository.DeleteAsync(id);
    }
}