

namespace EntityFrameworkCore.MySQL.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Tipo{ get; set; }
        public string Estado{ get; set; }

        public DateTime FechaAdq{ get; set; }

        public int Ubicacion {get;set;}
        
    }
}
