

using EntityFrameworkCore.MySQL.Data;
using EntityFrameworkCore.MySQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// controladores de API que se utiliza para interactuar con la base de datos
// cada controlador maneja operaciones CRUD  para una entidad especifica
// todos deben heredar de ControllerBase que es la base para los controladores




namespace EntityFrameworkCore.MySQL.Controllers
{
    [Route("api/[controller]")] // define una ruta base , lo que significa que las rutas comenzaran con "api/" seguido del nombre del controlador
    [ApiController] // atributo especifico para habilitra comportamientos de API
    public class EquiposController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public EquiposController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //agregar un nuevo equipo
        [HttpPost]
        public async Task<IActionResult> AddEquipo(Equipo equipo)
        {
            if(equipo == null)
            {
                return BadRequest("Equipo no proporcionado.");
            }
            _appDbContext.Equipos.Add(equipo);
            await _appDbContext.SaveChangesAsync();// guarda el equipoo en la base de datos

            return Ok(equipo);// return de que salio bien la operacion
        }


        //obtener todos los equipos
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var equipos = await _appDbContext.Equipos.ToListAsync();

            return Ok(equipos);
        }

        //eliminar un equipo por su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            var equipo = await _appDbContext.Equipos.FindAsync(id);

            if (equipo == null)
            {
                return NotFound("Advertencia: Equipo no encontrado");
            }

            _appDbContext.Equipos.Remove(equipo);

            await _appDbContext.SaveChangesAsync();

            return Ok($"Equipo con ID {id} ha sido borrado");
        }



       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipo(int id, Equipo updatedEquipo)
        {
            var equipo = await _appDbContext.Equipos.FindAsync(id);

            if (equipo == null)
            {
                return NotFound("Advertencia: equipo no encontrado");
            }

            equipo.Estado = updatedEquipo.Estado;
            equipo.Ubicacion =updatedEquipo.Ubicacion;
            
            await _appDbContext.SaveChangesAsync();

            return Ok(equipo);
        }

    }
}
