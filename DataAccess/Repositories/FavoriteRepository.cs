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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly MecourselaContext _context;

        public FavoriteRepository(MecourselaContext context) => _context = context;

        public async Task<Favorite?> GetByIdAsync(int id) => await _context.Favorites.FindAsync(id);

        public async Task<IEnumerable<Favorite>> GetAllAsync() => await _context.Favorites.ToListAsync();

        public async Task AddAsync(Favorite entity)
        {
            await _context.Favorites.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Favorite entity)
        {
            _context.Favorites.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Favorites.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}