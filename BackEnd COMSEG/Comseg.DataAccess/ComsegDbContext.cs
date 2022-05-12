using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Comseg.Entities;

namespace Comseg.DataAccess
{
    public class ComsegDbContext : DbContext
    {
        public ComsegDbContext()
        {

        }

        public ComsegDbContext(DbContextOptions<ComsegDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}