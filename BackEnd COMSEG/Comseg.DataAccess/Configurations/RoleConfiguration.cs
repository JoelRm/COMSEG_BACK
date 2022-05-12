using Comseg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comseg.DataAccess.Configurations;

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure (EntityTypeBuilder<Role> builder)
        {
            builder.HasQueryFilter(p => p.RoleStatus);
        }
    }

