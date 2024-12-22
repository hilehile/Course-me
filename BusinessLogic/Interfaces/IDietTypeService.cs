﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IDietTypeService
    {
        Task<DietType?> GetByIdAsync(int id);
        Task<IEnumerable<DietType>> GetAllAsync();
        Task AddAsync(DietType dietType);
        Task UpdateAsync(DietType dietType);
        Task DeleteAsync(int id);
    }
}