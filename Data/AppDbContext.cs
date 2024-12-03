using Microsoft.EntityFrameworkCore;
using EjemploReporte.Models;

namespace EjemploReporte.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.IdProducto); // Define la clave primaria explícitamente

            modelBuilder.Entity<Producto>()
                .Property(p => p.IdProducto)
                .ValueGeneratedOnAdd(); // Esto garantiza que el valor será generado por la base de datos

            modelBuilder.Entity<Producto>().ToTable("Productos");

            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioCosto)
                .HasColumnType("numeric(12, 2)");

            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioVenta)
                .HasColumnType("numeric(12, 2)");

            modelBuilder.Entity<Producto>()
                .Property(p => p.Porcentaje)
                .HasColumnType("numeric(12, 2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}


//using EjemploReporte.Models;
//using Microsoft.EntityFrameworkCore;

//namespace EjemploReporte.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//        // DbSet para las entidades
//        public DbSet<Producto> Productos { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Configuración adicional de entidades
//            modelBuilder.Entity<Producto>().HasKey(p => p.IdProducto);

//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}
