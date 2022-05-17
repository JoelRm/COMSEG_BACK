using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class MarkRepository : IMarkRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;
        
        public MarkRepository(ComsegDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Mark>> GetCollectionAsync()
        {
            return await _context.Set<Mark>()
                                .ToListAsync();
        }

        public async Task<Mark?> GetByIdAsync(int id)
        {
            return await _context.Set<Mark>()
                                .AsTracking()
                                .FirstOrDefaultAsync(p => p.MarkId == id);
        }

        public async Task<ICollection<MarkInfo?>> GetMarkInfoCollectionAsync()
        {
            return await _context.Set<Mark>()
                                .Select(x => _mapper.Map<MarkInfo?>(x))
                                .ToListAsync();
        }

        public async Task<MarkInfo?> GetMarkInfoByIdAsync(int id)
        {
            return await _context.Set<Mark>()
                                .Where(x => x.MarkId == id)
                                .Select(x => _mapper.Map<MarkInfo?>(x))
                                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Mark entity)
        {
            await _context.Set<Mark>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.MarkId;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mark = await GetByIdAsync(id);
            if (mark == null) return;
            mark.MarkStatus = false;
            await _context.SaveChangesAsync();
        }
    }
}
