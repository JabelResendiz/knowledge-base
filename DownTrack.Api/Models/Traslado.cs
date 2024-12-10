

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EntityFrameworkCore.MySQL.Models
{
    public class Traslado
    {
        public int Id { get; set; }

        public int? DepartamentoSalidaId { get; set; }

        [JsonIgnore]
        public Departamento? DepartamentoSalida { get; set; }

        public int? SeccionSalidaId { get; set; }
        [JsonIgnore]
        public Seccion? SeccionSalida { get; set; }

        public int? DepartamentoReceptorId { get; set; }

        [JsonIgnore]
        public Departamento? DepartamentoReceptor { get; set; }

        public int? SeccionReceptorId { get; set; }
        [JsonIgnore]
        public Seccion? SeccionReceptor{ get; set; }
        [Required]
        public int SolicitudId { get; set; } // sin solicitud no hay traslado

        [JsonIgnore]
        public Solicitud? Solicitud { get; set; }

        [Required]
        public DateTime FechaTraslado { get; set; }
 
        public int? ReceptorEquipoId { get; set; }
        [JsonIgnore]
        public ReceptorEquipo? receptorEquipo { get; set; }

        
        public int? ResponsableEnvioId { get; set; }
        [JsonIgnore]
        public Usuario? ResponsableEnvio { get; set; }

    }
}