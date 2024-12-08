

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class BajaEquipo
    {
        public int Id { get; set; }

        // Llave foránea hacia el técnico
        
        public int? TecnicoId { get; set; }
         [JsonIgnore]
        public Tecnico? Tecnico { get; set; }

        // Llave foránea hacia el equipo
        
        public int? EquipoId { get; set; }
        [JsonIgnore]
        public Equipo? Equipo { get; set; }

        // Campos adicionales
        [Required]
        public DateTime FechaBaja { get; set; }

        [Required]
        [StringLength(255)]
        public string CausaBaja { get; set; }
    }
}
