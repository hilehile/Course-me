using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MecourselaContext _context;

        public ArticleRepository(MecourselaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Article?> GetByIdAsync(int id) => await _context.Articles.FindAsync(id);

        public async Task<IEnumerable<Article>> GetAllAsync() => await _context.Articles.ToListAsync();

        public async Task AddAsync(Article entity)
        {
            await _context.Articles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Article entity)
        {
            _context.Articles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Articles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}