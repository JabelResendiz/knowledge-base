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

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<MantenimientoRealizado> MantenimientosRealizados { get; set; }
        public DbSet<BajaEquipo> BajasEquipos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>()
                .Property(e => e.FechaAdq).HasColumnType("date");


            modelBuilder.Entity<Seccion>()
                .HasOne(s => s.JefeSecc) // Configura una relacion "muchos a uno" (una seccion tiene un solo jefe)
                .WithMany(u => u.Secciones)  // La entidad Usuario tiene muchas secciones
                .HasForeignKey(s => s.JefeSeccId) // Seccion tiene una llave foranea JefeId
                .OnDelete(DeleteBehavior.Restrict); // configuracion de eliminacion de la relacion (no se permitira la eliminacion del jefe si tiene secciones asociadas)

            //.OnDelete(DeleteBehavior.Cascade); // cuando se elimine un JefeSecc se elimina las secciones tmb


            modelBuilder.Entity<Seccion>()
                .HasMany(s => s.Departamentos)// una seccion tiene muchos departamentos
                .WithOne(d => d.Seccion) // Un dpto pertenece a una sola seccion
                .HasForeignKey(d => d.SeccionId) // La llave foránea en Departamento
                .OnDelete(DeleteBehavior.Cascade);  // Eliminar Departamentos cuando se elimina una Sección


            modelBuilder.Entity<MantenimientoRealizado>()
                .HasKey(mr => mr.Id);// llave primaria de la relacion

            modelBuilder.Entity<MantenimientoRealizado>()
                .HasOne(mr => mr.Tecnico) // llave primaria de la relacion
                .WithMany(t => t.MantenimientosRealizados)
                .HasForeignKey(mr => mr.TecnicoId) //llave foranea a TecnicoId
                .OnDelete(DeleteBehavior.SetNull); //si borramos un tecnico se setea a null el valor del campo

            modelBuilder.Entity<MantenimientoRealizado>()
                .HasOne(mr => mr.Mantenimiento)
                .WithMany(m => m.MantenimientosRealizados)
                .HasForeignKey(mr => mr.MantenimientoId)
                .OnDelete(DeleteBehavior.SetNull); //si borramos un tecnico se setea a null el valor del campo

            modelBuilder.Entity<MantenimientoRealizado>()
                .HasOne(mr => mr.Equipo)
                .WithMany(e => e.MantenimientosRealizados)
                .HasForeignKey(mr => mr.EquipoId)
                .OnDelete(DeleteBehavior.SetNull); //si borramos un tecnico se setea a null el valor del campo

            modelBuilder.Entity<MantenimientoRealizado>()
                .Property(e => e.FechaRealizacion).HasColumnType("date");


            // entidad BajaEquipo
            modelBuilder.Entity<BajaEquipo>()
                .HasOne(b => b.Tecnico)
                .WithMany(t => t.BajasRealizadas)
                .HasForeignKey(b => b.TecnicoId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BajaEquipo>()
                .HasOne(b => b.Equipo)
                .WithMany(e => e.Bajas)
                .HasForeignKey(b => b.EquipoId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);

        }
    }
}
