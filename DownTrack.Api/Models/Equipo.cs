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
        public int Ubicacion { get; set; }

        [JsonIgnore]
        // Relación muchos-a-muchos
        public ICollection<MantenimientoRealizado> MantenimientosRealizados { get; set; } = new List<MantenimientoRealizado>();

        [JsonIgnore]
        // Relación con BajaEquipo
        public ICollection<BajaEquipo> Bajas { get; set; } = new List<BajaEquipo>();


    }
}
