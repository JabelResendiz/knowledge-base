

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        [Required]
        public string Tipo{ get; set; }
        
        [JsonIgnore]
        // Relación muchos-a-muchos
        public ICollection<MantenimientoRealizado> MantenimientosRealizados { get; set; } = new List<MantenimientoRealizado>();
    
    }
}
