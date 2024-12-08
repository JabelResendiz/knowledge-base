
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Seccion
    {

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        

        //llave foranea que conecta la Seccion con el JefeSecc
        [Required]
        public int JefeSeccId {get;set;}
        [JsonIgnore]
        public Usuario? JefeSecc {get;set;} // propiedad de navegacion

        [JsonIgnore]
        public ICollection<Departamento> Departamentos{get;set;} = new List<Departamento>();
    // 
    }
}