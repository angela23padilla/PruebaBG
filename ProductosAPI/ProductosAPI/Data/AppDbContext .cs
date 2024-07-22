using Microsoft.EntityFrameworkCore;
using ProductosAPI.Model.Producto;

namespace ProductosAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Productos> Products { get; set; }
    }
}
