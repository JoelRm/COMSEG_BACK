using Comseg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comseg.DataAccess.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure (EntityTypeBuilder<Menu> builder)
        {
            builder.HasQueryFilter(p => p.MenuStatus);
        }
    }
}
