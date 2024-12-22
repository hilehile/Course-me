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
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<Favorite?> GetByIdAsync(int id) => await _favoriteRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Favorite>> GetAllAsync() => await _favoriteRepository.GetAllAsync();

        public async Task AddAsync(Favorite entity) => await _favoriteRepository.AddAsync(entity);

        public async Task UpdateAsync(Favorite entity) => await _favoriteRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _favoriteRepository.DeleteAsync(id);
    }
}