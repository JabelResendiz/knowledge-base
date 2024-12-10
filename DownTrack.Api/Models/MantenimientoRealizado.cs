



using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace EntityFrameworkCore.MySQL.Models
{
    public class MantenimientoRealizado
    {
        public int Id { get; set; }

        // Llaves foráneas
        public int? TecnicoId { get; set; }
        [JsonIgnore]
        public Tecnico? Tecnico { get; set; }

        public int? MantenimientoId { get; set; }
        [JsonIgnore]
        public Mantenimiento? Mantenimiento { get; set; }

        public int? EquipoId{get;set;}
        [JsonIgnore]
        public Equipo? Equipo {get;set;}

        // Campos adicionales para registrar información sobre la relación
        [Required]
        public DateTime FechaRealizacion { get; set; }
        [Required]
        public double CostoMant { get; set; }
    }
}