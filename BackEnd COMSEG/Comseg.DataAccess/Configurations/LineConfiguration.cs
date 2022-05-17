using Comseg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comseg.DataAccess.Configurations
{
    public class LineConfiguration : IEntityTypeConfiguration<Line> 
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.HasQueryFilter(p => p.LineStatus);
        }
    }
}
