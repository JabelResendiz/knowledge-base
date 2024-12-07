

namespace EntityFrameworkCore.MySQL.Models
{
    public class Tecnico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }

        public int AñosExp {get;set;}

        public string Especialidad{get;set;}
        public double Salario{get;set;}
        
    }
}
