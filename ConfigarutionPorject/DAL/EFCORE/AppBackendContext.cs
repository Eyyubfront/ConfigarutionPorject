using ConfigarutionPorject.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConfigarutionPorject.DAL.EFCORE
{
    public class AppBackendContext:DbContext
    {
     

        public AppBackendContext(DbContextOptions<AppBackendContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categorys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}






