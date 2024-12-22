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
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<Test?> GetByIdAsync(int id) => await _testRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Test>> GetAllAsync() => await _testRepository.GetAllAsync();

        public async Task AddAsync(Test entity) => await _testRepository.AddAsync(entity);

        public async Task UpdateAsync(Test entity) => await _testRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _testRepository.DeleteAsync(id);
    }
}