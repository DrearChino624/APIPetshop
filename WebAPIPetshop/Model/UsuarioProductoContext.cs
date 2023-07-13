using Microsoft.EntityFrameworkCore;

namespace WebAPIPetshop.Model
{
    public class UsuarioProductoContext : DbContext
    {
        public UsuarioProductoContext(DbContextOptions<UsuarioProductoContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}