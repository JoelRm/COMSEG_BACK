
using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;

        public BranchRepository(ComsegDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Branch>> GetCollectionAsync()
        {
            return await _context.Set<Branch>()
                                .ToListAsync();
        }
        public async Task<Branch?> GetByIdAsync(int id)
        {
            return await _context.Set<Branch>()
                              .AsTracking()
                            .FirstOrDefaultAsync(p => p.BranchId == id);
        }
        public async Task<ICollection<BranchInfo?>> GetBranchInfoCollectionAsync()
        {
            return await _context.Set<Branch>()
                                .Select(x => _mapper.Map<BranchInfo?>(x))
                                .ToListAsync();
        }
        public async Task<BranchInfo?> GetBranchInfoByIdAsync(int id)
        {
            return await _context.Set<Branch>()
                                .Where(x => x.BranchId == id)
                                .Select(x => _mapper.Map<BranchInfo?>(x))
                                .SingleOrDefaultAsync();
        }
        public async Task<int> CreateAsync(Branch entity)
        {
            await _context.Set<Branch>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.BranchId;
        }
        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var branch = await GetByIdAsync(id);
            if (branch == null) return;
            branch.BranchStatus = false;
            await _context.SaveChangesAsync();
        }

        
    }
}
