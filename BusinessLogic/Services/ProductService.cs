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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product?> GetByIdAsync(int id) => await _productRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Product>> GetAllAsync() => await _productRepository.GetAllAsync();

        public async Task AddAsync(Product entity) => await _productRepository.AddAsync(entity);

        public async Task UpdateAsync(Product entity) => await _productRepository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _productRepository.DeleteAsync(id);
    }
}