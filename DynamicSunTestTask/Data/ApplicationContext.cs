using DynamicSunTestTask.Entites;
using Microsoft.EntityFrameworkCore;

namespace DynamicSunTestTask.Data
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<WheatherColumn> WheatherColumns => Set<WheatherColumn>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        { }
    }
}