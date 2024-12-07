





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
    public class SeccionesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public SeccionesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //agregar una nueva Seccion
        [HttpPost]
        public async Task<IActionResult> AddSeccion(Seccion seccion)
        {
            _appDbContext.Secciones.Add(seccion);
            await _appDbContext.SaveChangesAsync();// guarda la Seccion en la base de datos

            return Ok(seccion);// return de que salio bien la operacion
        }


        //obtener todos los Seccions
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var secciones = await _appDbContext.Secciones.ToListAsync();

            return Ok(secciones);
        }

        //eliminar un Seccion por su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeccion(int id)
        {
            var seccion = await _appDbContext.Secciones.FindAsync(id);

            if (seccion == null)
            {
                return NotFound("Advertencia: Seccion no encontrado");
            }

            _appDbContext.Secciones.Remove(seccion);

            await _appDbContext.SaveChangesAsync();

            return Ok($"Seccion con ID {id} ha sido borrado");
        }



       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeccion(int id, Seccion updatedSeccion)
        {
            var seccion = await _appDbContext.Secciones.FindAsync(id);

            if (seccion == null)
            {
                return NotFound("Advertencia: Seccion no encontrado");
            }

            seccion.Nombre = updatedSeccion.Nombre;
            
            
            await _appDbContext.SaveChangesAsync();

            return Ok(seccion);
        }

    }
}
