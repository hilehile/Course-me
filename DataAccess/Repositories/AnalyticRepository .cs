﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AnalyticRepository : IAnalyticRepository
    {
        private readonly MecourselaContext _context;

        public AnalyticRepository(MecourselaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Analytic?> GetByIdAsync(int id) => await _context.Analytics.FindAsync(id);

        public async Task<IEnumerable<Analytic>> GetAllAsync() => await _context.Analytics.ToListAsync();

        public async Task AddAsync(Analytic entity)
        {
            await _context.Analytics.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Analytic entity)
        {
            _context.Analytics.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Analytics.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}