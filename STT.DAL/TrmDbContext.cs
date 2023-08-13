using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TRM_STT.Core.Domain.Models;

namespace TRM_STT.DAL
{
    public class TrmDbContext : DbContext
    {
        public TrmDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Good> Goods { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}