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
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Article?> GetByIdAsync(int id) => await _articleRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Article>> GetAllAsync() => await _articleRepository.GetAllAsync();

        public async Task AddAsync(Article entity) => await _articleRepository.AddAsync(entity);

        public async Task UpdateAsync(Article entity) => await _articleRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _articleRepository.DeleteAsync(id);
    }
}
