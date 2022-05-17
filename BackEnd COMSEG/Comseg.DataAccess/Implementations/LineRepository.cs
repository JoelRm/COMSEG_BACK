using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class LineRepository :ILineRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;
        
        public LineRepository(ComsegDbContext context,IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;   
        }

        public async Task<ICollection<Line>> GetCollectionAsync()
        {
            return await _context.Set<Line>()
                                 .ToListAsync();
        }

        public async Task<Line?> GetByIdAsync(int id)
        {
            return await _context.Set<Line>()
                                .AsTracking()
                                .FirstOrDefaultAsync(p => p.LineId == id);
        }

        public async Task<ICollection<LineInfo?>> GetLineInfoCollectionAsync()
        {
            return await _context.Set<Line>()
                                .Select(x => _mapper.Map<LineInfo?>(x))
                                .ToListAsync();
        }

        public async Task<LineInfo?> GetLineInfoByIdAsync(int id)
        {
            return await _context.Set<Line>()
                                .Where(x => x.LineId == id)
                                .Select(x => _mapper.Map<LineInfo?>(x))
                                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Line entity)
        {
            await _context.Set<Line>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.LineId;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var line = await GetByIdAsync(id);
            if (line == null) return;
            line.LineStatus = false;
            await _context.SaveChangesAsync();
        }
    }
}
