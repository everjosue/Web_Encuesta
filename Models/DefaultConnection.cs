using Microsoft.EntityFrameworkCore;

namespace Productos.Models;

    public class DefaultConnection : DbContext
    {

        public DefaultConnection(DbContextOptions<DefaultConnection> options) : base(options)
        {
        }

        public DbSet<ModeloProductos> Products { get; set; }

    }