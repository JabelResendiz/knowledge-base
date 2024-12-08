using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace EntityFrameworkCore.MySQL.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Rol { get; set; }


        // un usuario (jefe de seccion) puede ser jefe de varias secciones
         [JsonIgnore]
        public ICollection<Seccion>? Secciones {get;set;}
    }
}
