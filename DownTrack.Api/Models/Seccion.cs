using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Seccion
    {

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }


        //llaves forane que conecta con JefeSecc
        [Required]
        public int JefeSeccId {get;set;}
        [JsonIgnore]
        public Usuario? JefeSecc {get;set;} // propiedad de navegacion

        [JsonIgnore]
        public ICollection<Departamento> Departamentos{get;set;} = new List<Departamento>();

        [JsonIgnore]
        public ICollection<Traslado>? TrasladosRecibidos{get;set;}

        [JsonIgnore]
        public ICollection<Traslado>? TrasladosEnviados{get;set;}
    
    }
}
