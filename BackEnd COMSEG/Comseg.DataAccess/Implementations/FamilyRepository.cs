using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;

        public FamilyRepository(ComsegDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Family>> GetCollectionAsync()
        {
            return await _context.Set<Family>()
                                 .ToListAsync();
        }

        public async Task<Family?> GetByIdAsync(int id)
        {
            return await _context.Set<Family>()
                                .AsTracking()
                                .FirstOrDefaultAsync(p => p.FamilyId == id);
        }

        public async Task<ICollection<FamilyInfo?>> GetFamilyInfoCollectionAsync()
        {
            return await _context.Set<Family>()
                                .Select(x => _mapper.Map<FamilyInfo?>(x))
                                .ToListAsync();
        }

        public async Task<FamilyInfo?> GetFamilyInfoByIdAsync(int id)
        {
            return await _context.Set<Family>()
                                .Where(x => x.FamilyId == id)
                                .Select(x => _mapper.Map<FamilyInfo?>(x))
                                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Family entity)
        {
            await _context.Set<Family>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.FamilyId;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var family = await GetByIdAsync(id);
            if (family == null) return;
            family.FamilyStatus = false;
            await _context.SaveChangesAsync();
        }
    }
}
