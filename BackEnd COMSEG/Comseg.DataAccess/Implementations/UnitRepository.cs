using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;
        public UnitRepository(ComsegDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<ICollection<Unit>> GetCollectionAsync()
        {
            return await _context.Set<Unit>()
                                .ToListAsync();
        }

        public async Task<Unit?> GetByIdAsync(int id)
        {
            return await _context.Set<Unit>()
                                .AsTracking()
                             .FirstOrDefaultAsync(p => p.UnitId == id);
        }

        public async Task<ICollection<UnitInfo?>> GetUnitInfoCollectionAsync()
        {
            return await _context.Set<Unit>()
                                .Select(x => _mapper.Map<UnitInfo?>(x))
                                .ToListAsync();
        }

        public async Task<UnitInfo?> GetUnitInfoByIdAsync(int id)
        {
            return await _context.Set<Unit>()
                                .Where(x => x.UnitId == id)
                                .Select(x => _mapper.Map<UnitInfo?>(x))
                                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Unit entity)
        {
            await _context.Set<Unit>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.UnitId;
        }
        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var unit = await GetByIdAsync(id);
            if (unit == null) return;
            unit.UnitStatus = false;
            await _context.SaveChangesAsync();
        }

    }
}
