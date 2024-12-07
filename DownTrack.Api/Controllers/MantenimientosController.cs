




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
    public class MantenimientosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public MantenimientosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //agregar un nuevo Mantenimiento
        [HttpPost]
        public async Task<IActionResult> AddMantenimiento(Mantenimiento mantenimiento)
        {
            _appDbContext.Mantenimientos.Add(mantenimiento);
            await _appDbContext.SaveChangesAsync();// guarda el Mantenimientoo en la base de datos

            return Ok(mantenimiento);// return de que salio bien la operacion
        }


        //obtener todos los Mantenimientos
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var mantenimientos = await _appDbContext.Mantenimientos.ToListAsync();

            return Ok(mantenimientos);
        }

        //eliminar un Mantenimiento por su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento(int id)
        {
            var mantenimiento = await _appDbContext.Mantenimientos.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound("Advertencia: Mantenimiento no encontrado");
            }

            _appDbContext.Mantenimientos.Remove(mantenimiento);

            await _appDbContext.SaveChangesAsync();

            return Ok($"Mantenimiento con ID {id} ha sido borrado");
        }



       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMantenimiento(int id, Mantenimiento updatedMantenimiento)
        {
            var mantenimiento = await _appDbContext.Mantenimientos.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound("Advertencia: Mantenimiento no encontrado");
            }

            mantenimiento.Tipo = updatedMantenimiento.Tipo;
            
            
            await _appDbContext.SaveChangesAsync();

            return Ok(mantenimiento);
        }

    }
}
