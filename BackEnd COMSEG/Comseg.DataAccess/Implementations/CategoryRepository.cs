using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comseg.DataAccess.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ComsegDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Category>> GetCollectionAsync()
        {
            return await _context.Set<Category>()
                                 .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Set<Category>()
                                .AsTracking()
                                .FirstOrDefaultAsync(p => p.CategoryId == id);
        }

        public async Task<ICollection<CategoryInfo?>> GetCategoryInfoCollectionAsync()
        {
            return await _context.Set<Category>()
                                .Select(x => _mapper.Map<CategoryInfo?>(x))
                                .ToListAsync();
        }

        public async Task<CategoryInfo?> GetCategoryInfoByIdAsync(int id)
        {
            return await _context.Set<Category>()
                                .Where(x => x.CategoryId == id)
                                .Select(x => _mapper.Map<CategoryInfo?>(x))
                                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Category entity)
        {
            await _context.Set<Category>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.CategoryId;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category == null) return;
            category.CategoryStatus = false;
            await _context.SaveChangesAsync();
        }
    }
}
