
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Departamento
    {

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        // Llave foránea que conecta el Departamento con la Sección
        public int SeccionId { get; set; }


        [JsonIgnore]
        // Propiedad de navegación hacia la entidad Sección
        public Seccion? Seccion { get; set; }
    }
}