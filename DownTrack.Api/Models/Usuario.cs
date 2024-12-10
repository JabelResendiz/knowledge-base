

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EntityFrameworkCore.MySQL.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Rol { get; set; }

        [JsonIgnore]
        public ICollection<Seccion>? SeccionesDirige { get; set; }

        [JsonIgnore]
        public ICollection<Evaluacion>? EvaluacionesOtorgadas { get; set; }

        [JsonIgnore]

        public ICollection<Solicitud>? SolicitudesHechas { get; set; }

        [JsonIgnore]
        public ICollection<Traslado>? TrasladosEnviados { get; set; }
    }


    public class ReceptorEquipo : Usuario

    {

        // Relación con Departamento al que pertenece
        [Required]
        public int DepartamentoId { get; set; }
        [JsonIgnore]
        public Departamento? Departamento { get; set; }

        [Required]
        public int SeccionId { get; set; }
        [JsonIgnore]
        public Seccion? Seccion { get; set; }

        [JsonIgnore]
        public ICollection<Traslado>? TrasladosRecibidos { get; set; }


    }


    public class CambiarRolRequest
    {
        public string RolNuevo { get; set; }
        public int AñosExp { get; set; }

        public string Especialidad { get; set; }
        public double Salario { get; set; }

        public int SeccionId { get; set; }
        public int DepartamentoId { get; set; }
    }


}