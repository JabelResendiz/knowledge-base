using EntityFrameworkCore.MySQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;


// se utiliza para interactuar con una base de dato MySQL
//DbContext es la clase principal de EntityFrameworkCore para interctuar con la base de dato
// cada DbSet<T> representa una tabla en la base de datos
// se utilizara estas propiedades para generar consultas y realizar operaciones CRUD


namespace EntityFrameworkCore.MySQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }

        public DbSet<Equipo> Equipos {get;set;}

        public DbSet<Mantenimiento> Mantenimientos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>().
                                        Property(e => e.FechaAdq).HasColumnType("date");
            base.OnModelCreating(modelBuilder);
        }
    }
}
