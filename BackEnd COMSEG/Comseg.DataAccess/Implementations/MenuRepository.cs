using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;

        public MenuRepository(ComsegDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Menu>> GetCollectionAsync()
        {
                 return await _context.Set<Menu>()
                                .ToListAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _context.Set<Menu>()
                                .AsTracking()
                             .FirstOrDefaultAsync(p => p.MenuId == id);
        }

        public async Task<ICollection<MenuInfo?>> GetMenuInfoCollectionAsync()
        {
            return await _context.Set<Menu>()
                           .Select(x => _mapper.Map<MenuInfo?>(x))
                           .ToListAsync();
        }

        public async Task<MenuInfo?> GetMenuInfoByIdAsync(int id)
        {
            return await _context.Set<Menu>()
                            .Where(x => x.MenuId == id)
                            .Select(x => _mapper.Map<MenuInfo?>(x))
                            .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Menu entity)
        {
            await _context.Set<Menu>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.MenuId;
        }
        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menu = await GetByIdAsync(id);
            if (menu == null) return;
            menu.MenuStatus = false;
            await _context.SaveChangesAsync();
        }

    }
}
