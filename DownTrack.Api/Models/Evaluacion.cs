


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityFrameworkCore.MySQL.Models
{
    public class Evaluacion
    {
        [Key]
        public int Id {get;set;}

        [ForeignKey("JefeSecc")]
        public int? JefeSeccId{get;set;}
        [JsonIgnore]
        public Usuario? JefeSecc{get;set;}

        [ForeignKey("Tecnico")]
        public int? TecnicoId {get;set;}
        [JsonIgnore]
        public Tecnico? Tecnico {get;set;}

        [Required]
        public DateTime FechaEvaluacion{get;set;}

        [Required]
        public string Valoracion{get;set;}
    }
}