
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EntityFrameworkCore.MySQL.Controllers;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Departamento
    {

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [JsonIgnore]
        public ICollection<ReceptorEquipo>? Receptores { get; set; }

        public int SeccionId { get; set; }


        [JsonIgnore]
        // Propiedad de navegación hacia la entidad Sección
        public Seccion? Seccion { get; set; }

        [JsonIgnore]
        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

        [JsonIgnore]
        public ICollection<Traslado>? TrasladosRecibidos{get;set;}

        [JsonIgnore]
        public ICollection<Traslado>? TrasladosEnviados{get;set;}
    }
}
