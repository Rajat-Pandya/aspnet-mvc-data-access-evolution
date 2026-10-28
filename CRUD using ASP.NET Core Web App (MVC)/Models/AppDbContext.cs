using Microsoft.EntityFrameworkCore;

namespace CRUD_using_ASP.NET_Core_Web_App__MVC_.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){ }

        public DbSet<Products> Products => Set<Products>();
        public DbSet<Employees> Employees => Set<Employees>();
    }
}
