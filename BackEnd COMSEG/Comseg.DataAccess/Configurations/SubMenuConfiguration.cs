using Comseg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comseg.DataAccess.Configurations
{
    public class SubMenuConfiguration : IEntityTypeConfiguration<SubMenu>
    {
        public void Configure(EntityTypeBuilder<SubMenu> builder)
        {
            builder.HasQueryFilter(p => p.SubMenuStatus);
        }
    }
}
