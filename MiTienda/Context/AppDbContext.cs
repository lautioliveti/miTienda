using Microsoft.EntityFrameworkCore;
using MiTienda.Entities;

namespace MiTienda.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Categoria>Categoria { get; set; }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrdenItem> OrdenItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Categoria>(e =>
            {
                e.HasKey("CategoriaID");
                e.Property("CategoriaID").ValueGeneratedOnAdd();
                e.HasData(
                    new Categoria { CategoriaID = 1, CategoriaNombre = "Tecnologia" },
                    new Categoria { CategoriaID = 2, CategoriaNombre = "Bedroom" }
                    );
            });

            modelBuilder.Entity<Producto>(e =>
            {
                e.HasKey("ProductoID");
                e.Property("ProductoID").ValueGeneratedOnAdd();
                e.Property("ProductoPrecio").HasColumnType("decimal(10,2)");
                e.HasOne(e => e.Categoria).WithMany(p => p.Productos).HasForeignKey(e => e.ProductoCategoria)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Usuario>(e =>
            {
                e.HasKey("UsuarioID");
                e.Property("UsuarioID").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Orden>(e =>
            {
                e.HasKey("OrdenID");
                e.Property("OrdenID").ValueGeneratedOnAdd();
                e.Property("OrdenTotal").HasColumnType("decimal(10,2)");
                e.HasOne(e => e.OrdenUsuario).WithMany(p => p.UsuarioOrdenes).HasForeignKey(e => e.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrdenItem>(e =>
            {
                e.HasKey("OrdenItemID");
                e.Property("OrdenItemID").ValueGeneratedOnAdd();
                e.Property("Precio").HasColumnType("decimal(10,2)");

                e.HasOne(e => e.Orden).WithMany(p => p.OrdenItems).HasForeignKey(e => e.OrdenID)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.Producto).WithMany().HasForeignKey(e => e.ProductoID)
                .OnDelete(DeleteBehavior.Restrict);


            });

            
        }
    }
}
