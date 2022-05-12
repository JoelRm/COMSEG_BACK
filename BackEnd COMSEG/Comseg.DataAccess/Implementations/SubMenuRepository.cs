using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class SubMenuRepository : ISubMenuRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;

        public SubMenuRepository(ComsegDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<SubMenu>> GetCollectionAsync()
        {
            return await _context.Set<SubMenu>()
                                .ToListAsync();
        }

        public async Task<SubMenu?> GetByIdAsync(int id)
        {
            return await _context.Set<SubMenu>()
                                .AsTracking()
                             .FirstOrDefaultAsync(p => p.SubMenuId == id);
        }

        public async Task<ICollection<SubMenuInfo?>> GetSubMenuInfoCollectionAsync()
        {
            return await _context.Set<SubMenu>()
                                .Select(x => _mapper.Map<SubMenuInfo?>(x))
                                .ToListAsync();
        }

        public async Task<SubMenuInfo?> GetSubMenuInfoByIdAsync(int id)
        {
            return await _context.Set<SubMenu>()
                                .Where(x => x.SubMenuId == id)
                                .Select(x => _mapper.Map<SubMenuInfo?>(x))
                                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(SubMenu entity)
        {
            await _context.Set<SubMenu>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.SubMenuId;
        }
        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var submenu = await GetByIdAsync(id);
            if (submenu == null) return;
            submenu.SubMenuStatus = false;
            await _context.SaveChangesAsync();
        }

    }
}
