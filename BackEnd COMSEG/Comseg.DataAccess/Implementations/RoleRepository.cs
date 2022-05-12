using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ComsegDbContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(ComsegDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Role>> GetCollectionAsync()
        {
            return await _context.Set<Role>()
                                .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Set<Role>()
                               .AsTracking()
                             .FirstOrDefaultAsync(p => p.RoleId == id);
        }

        public async Task<ICollection<RoleInfo?>> GetRoleInfoCollectionAsync()
        {
            return await _context.Set<Role>()
                                .Select(x => _mapper.Map<RoleInfo?>(x))
                                .ToListAsync();
        }

        public async Task<RoleInfo?> GetRoleInfoByIdAsync(int id)
        {
            return await _context.Set<Role>()
                                .Where(x => x.RoleId == id)
                                .Select(x => _mapper.Map<RoleInfo?>(x))
                                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Role entity)
        {
            await _context.Set<Role>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.RoleId;
        }
        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var unit = await GetByIdAsync(id);
            if (unit == null) return;
            unit.RoleStatus = false;
            await _context.SaveChangesAsync();
        }

    }
}
