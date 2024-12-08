using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Tecnico
    {

        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int AñosExp { get; set; }

        [Required]
        public string Especialidad { get; set; }
        [Required]
        public double Salario { get; set; }


        [JsonIgnore]
        // Relación muchos-a-muchos con datos adicionales
        public ICollection<MantenimientoRealizado> MantenimientosRealizados { get; set; } = new List<MantenimientoRealizado>();

        [JsonIgnore]
        // Relación con BajaEquipo
        public ICollection<BajaEquipo> BajasRealizadas { get; set; } = new List<BajaEquipo>();

        [JsonIgnore]
        public ICollection<Evaluacion> EvaluacionesRecibidas{get;set;} = new List<Evaluacion>();
    
    }   
}
