
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public DateTime FechaAdq { get; set; }

        [Required]
        public int DepartamentoId { get; set; }
        [JsonIgnore]
        public Departamento? Departamento { get; set; }
        [Required]
        public int SeccionId { get; set; }
        [JsonIgnore]
        public Seccion? Seccion { get; set; }

        [JsonIgnore]
        // Relación muchos-a-muchos
        public ICollection<MantenimientoRealizado> MantenimientosRealizados { get; set; } = new List<MantenimientoRealizado>();

        // [JsonIgnore]
        // // Relación con BajaEquipo
        // public ICollection<BajaEquipo> Bajas { get; set; } = new List<BajaEquipo>();

        [JsonIgnore]

        public BajaEquipo? Baja { get; set; }

        [JsonIgnore]

        public ICollection<Solicitud>? SolicitudesEquipo { get; set; }
    }
}
