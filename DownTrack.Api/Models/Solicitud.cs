
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Solicitud
    {
        public int Id { get; set; }

        public int? JefeSeccId { get; set; }

        [JsonIgnore]
        public Usuario? JefeSecc { get; set; }

        public int? EquipoId { get; set; }

        [JsonIgnore]
        public Equipo? Equipo { get; set; }

        [Required]
        public DateTime FechaSolicitud { get; set; }

        public int? TrasladoId { get; set; }
        
        [JsonIgnore]
        public Traslado? Traslado { get; set; }

    }
}