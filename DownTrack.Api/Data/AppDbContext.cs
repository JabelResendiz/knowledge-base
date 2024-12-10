
using EntityFrameworkCore.MySQL.Models;
using Microsoft.EntityFrameworkCore;


// se utiliza para interactuar con una base de dato MySQL
//DbContext es la clase principal de EntityFrameworkCore para interctuar con la base de dato
// cada DbSet<T> representa una tabla en la base de datos
// se utilizara estas propiedades para generar consultas y realizar operaciones CRUD


namespace EntityFrameworkCore.MySQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        // public DbSet<JefeSecc> JefeSecciones { get; set; }
        public DbSet<ReceptorEquipo> ReceptoresEquipos { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<MantenimientoRealizado> MantenimientosRealizados { get; set; }
        public DbSet<BajaEquipo> BajasEquipos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public DbSet<Solicitud> Solicitudes { get; set; }

        public DbSet<Traslado> Traslados { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // configurar TPT (Table-Per-Table)

            modelBuilder.Entity<Departamento>()
                .HasKey(d => new { d.Id, d.SeccionId });

                
            // Configuración para Usuario
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.Id);

            // Configuración para Tecnico
            modelBuilder.Entity<Tecnico>()
                .ToTable("Tecnicos")
                .HasOne<Usuario>() // Relación uno-a-uno implícita con Usuario
                .WithOne()
                .HasForeignKey<Tecnico>(t => t.Id);

            //Configuración para Receptor de Equipo
            modelBuilder.Entity<ReceptorEquipo>()
                .ToTable("ReceptoresEquipos")
                .HasOne<Usuario>() // Relación uno-a-uno implícita con Usuario
                .WithOne()
                .HasForeignKey<ReceptorEquipo>(t => t.Id);



            // Configuración de relación Receptor-Departamento 
            modelBuilder.Entity<ReceptorEquipo>()
                .HasOne(r => r.Departamento) // Relación muchos a uno
                .WithMany(d => d.Receptores)
                .HasForeignKey(r => new { r.DepartamentoId, r.SeccionId })
                .OnDelete(DeleteBehavior.Restrict); // no se puede eliminar departamento si tiene receptores de equipo asociados

            //Configuración de relación Seccion-JefeSecc
            modelBuilder.Entity<Seccion>()
                .HasOne(s => s.JefeSecc) // Configura una relacion "muchos a uno" (una seccion tiene un solo jefe)
                .WithMany()  // La entidad Usuario tiene muchas secciones
                .HasForeignKey(s => s.JefeSeccId) // Seccion tiene una llave foranea JefeId
                .OnDelete(DeleteBehavior.Restrict); // configuracion de eliminacion de la relacion (no se permitira la eliminacion del jefe si tiene secciones asociadas)


            //Configuración de relación Seccion-Departamento
            modelBuilder.Entity<Seccion>()
                .HasMany(s => s.Departamentos)// una seccion tiene muchos departamentos
                .WithOne(d => d.Seccion) // Un dpto pertenece a una sola seccion
                .HasForeignKey(d => d.SeccionId) // La llave foránea en Departamento
                .OnDelete(DeleteBehavior.Cascade);  //Eliminar Departamentos cuando se elimina una Sección


            modelBuilder.Entity<Seccion>()
                .HasMany(s=> s.TrasladosEnviados)
                .WithOne(t=>t.SeccionReceptor)
                .HasForeignKey(t=> t.SeccionReceptorId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Seccion>()
                .HasMany(s=> s.TrasladosRecibidos)
                .WithOne(t=>t.SeccionSalida)
                .HasForeignKey(t=> t.SeccionSalidaId)
                .OnDelete(DeleteBehavior.SetNull);
            
            
            //Configuración de relación Equipo-Departamento

            modelBuilder.Entity<Equipo>()
                .HasOne(s => s.Departamento)
                .WithMany(d => d.Equipos)
                .HasForeignKey(r => new { r.DepartamentoId, r.SeccionId })
                .OnDelete(DeleteBehavior.Restrict); // evitar la eliminacion de un departamento si tiene equipos asociados

            //Configuración de relación manteniento Realizados

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
                .OnDelete(DeleteBehavior.SetNull); //si borramos un mantenimiento se setea a null el valor del campo

            modelBuilder.Entity<MantenimientoRealizado>()
                .HasOne(mr => mr.Equipo)
                .WithMany(e => e.MantenimientosRealizados)
                .HasForeignKey(mr => mr.EquipoId)
                .OnDelete(DeleteBehavior.SetNull); //si borramos un equipo se setea a null el valor del campo

            modelBuilder.Entity<MantenimientoRealizado>()
                .Property(e => e.FechaRealizacion).HasColumnType("date");

            //Configuración de relación Baja De Equipo

            // Relación BajaEquipo - Técnico (uno-a-muchos)
            modelBuilder.Entity<BajaEquipo>()
                .HasOne(b => b.Tecnico) // BajaEquipo tiene un Técnico
                .WithMany(t => t.BajasRealizadas) // Técnico tiene muchas bajas realizadas
                .HasForeignKey(b => b.TecnicoId) // Llave foránea en BajaEquipo
                .OnDelete(DeleteBehavior.SetNull); // Si se elimina un Técnico, establecerá TécnicoId en null

            // Relación BajaEquipo - Equipo (uno-a-uno)
            modelBuilder.Entity<BajaEquipo>()
                .HasOne(b => b.Equipo) // BajaEquipo tiene un Equipo
                .WithOne(e => e.Baja) // Equipo tiene una sola BajaEquipo
                .HasForeignKey<BajaEquipo>(b => b.EquipoId) // Llave foránea en BajaEquipo
                .OnDelete(DeleteBehavior.SetNull); // Si se elimina un Equipo, establecerá EquipoId en null


            //Configuración de relación Evaluacion

            //Relación Evaluacion - JefeSecc (uno-a-muchos)
            modelBuilder.Entity<Evaluacion>()
                .HasOne(e => e.JefeSecc)
                .WithMany(j => j.EvaluacionesOtorgadas)
                .HasForeignKey(e => e.JefeSeccId)
                .OnDelete(DeleteBehavior.SetNull);

            //Relación Evaluacion - Tecnico (uno-a-muchos)
            modelBuilder.Entity<Evaluacion>()
                .HasOne(e => e.Tecnico)
                .WithMany(t => t.EvaluacionesRecibidas)
                .HasForeignKey(e => e.TecnicoId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Evaluacion>()
                .Property(e => e.FechaEvaluacion).HasColumnType("date");


            //Configuración de relación Solicitud

            modelBuilder.Entity<Solicitud>()
                .HasOne(e => e.Equipo)
                .WithMany(t => t.SolicitudesEquipo)
                .HasForeignKey(e => e.EquipoId)
                .OnDelete(DeleteBehavior.SetNull);
            //OnDelete(DeleteBehavior.Restrict)

            modelBuilder.Entity<Solicitud>()
                .HasOne(e => e.JefeSecc)
                .WithMany(j => j.SolicitudesHechas)
                .HasForeignKey(s => s.JefeSeccId)
                .OnDelete(DeleteBehavior.SetNull);

            //Configuración de relación Traslado

            //Relacion Solicitud-Traslado (uno a uno)
            modelBuilder.Entity<Traslado>()
                .HasOne(t => t.Solicitud) // Traslado tiene una sola Solicitud
                .WithOne(s => s.Traslado) //  Solictitud tiene un solo Traslado
                .HasForeignKey<Traslado>(t => t.SolicitudId) // Llave foránea en Traslado
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina una Solicitud, se eliminara la info del Traslado
            //.OnDelete(DeleteBehavior.Restrict);


            //Relacion Traslado_Receptor (uno a muchos)
            modelBuilder.Entity<Traslado>()
                .HasOne(t => t.receptorEquipo)
                .WithMany(r => r.TrasladosRecibidos)
                .HasForeignKey(t => t.ReceptorEquipoId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relacion Traslado-ResponsableEnvio

            modelBuilder.Entity<Traslado>()
                .HasOne(t => t.ResponsableEnvio)
                .WithMany(u => u.TrasladosEnviados)
                .HasForeignKey(t => t.ResponsableEnvioId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Traslado>()
                .HasOne(t => t.DepartamentoSalida)
                .WithMany(d => d.TrasladosEnviados)
                .HasForeignKey(t => new { t.DepartamentoSalidaId, t.SeccionSalidaId })
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Traslado>()
                .HasOne(t => t.DepartamentoReceptor)
                .WithMany(d => d.TrasladosRecibidos)
                .HasForeignKey(t => new { t.DepartamentoReceptorId, t.SeccionReceptorId })
                .OnDelete(DeleteBehavior.SetNull);


            base.OnModelCreating(modelBuilder);
        }
    }
}