





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
        // [HttpPost]
        // public async Task<IActionResult> AddSeccion(Seccion seccion)
        // {

        //var jefe = await _appDbContext.Usuarios.FindAsync(seccion.JefeSeccId);
        // if (jefe == null)
        // {
        //     return NotFound("El JefeSecc asignado no existe.");
        // }

        //     _appDbContext.Secciones.Add(seccion);
        //     await _appDbContext.SaveChangesAsync();// guarda la Seccion en la base de datos

        //    return CreatedAtAction(nameof(GetAll), new { id = seccion.Id }, seccion); // return de que salio bien la operacion
        // }

        [HttpPost]
        public async Task<ActionResult<Seccion>> CreateSeccion(Seccion seccion)
        {
            if (seccion == null)
            {
                return BadRequest("Sección no proporcionada.");
            }

            // Validar si el Jefe de la sección existe en la base de datos y tiene el rol adecuado
            var jefeSecc = await _appDbContext.Usuarios
                                              .FindAsync(seccion.JefeSeccId);

            if (jefeSecc == null)
            {
                return BadRequest("El JefeSecc con el ID proporcionado no existe.");
            }

            if (jefeSecc.Rol != "JefeSecc")
            {
                return BadRequest("El usuario no tiene el rol adecuado para ser jefe de una sección.");
            }

            
            // Agregar la nueva sección
            _appDbContext.Secciones.Add(seccion);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateSeccion), new { id = seccion.Id }, seccion);

        }


        //obtener todos los Secciones junto con los datos del JefeSecc asociado
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var secciones = await _appDbContext.Secciones
                                               .Include(s => s.JefeSecc)
                                               .ToListAsync();

            if (secciones == null || !secciones.Any())
            {
                return NotFound("No hay secciones registradas");
            }

            return Ok(secciones);
        }

        // public async Task<ActionResult<IEnumerable<Seccion>>> GetSecciones()
        // {
        //     return await _appDbContext.Secciones.Include(s => s.JefeSecc).ToListAsync();
        // }

        //eliminar un Seccion por su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeccion(int id)
        {
            var seccion = await _appDbContext.Secciones.FindAsync(id);

            if (seccion == null)
            {
                return NotFound("Advertencia: Seccion no encontrado");
            }

            // Validar si la sección tiene dependencias en otra tabla (no es necesario)
            // var tieneDependencias = await _appDbContext.Departamento.AnyAsync(o => o.SeccionId == id);
            // if (tieneDependencias)
            // {
            //     return BadRequest(new { Message = "No se puede eliminar la sección porque tiene dependencias asociadas." });
            // }

            //usar bloque try and catch por si hay restricciones en la base de dato (integridad referencial)
            try
            {

                _appDbContext.Secciones.Remove(seccion);// Eliminar la sección
                await _appDbContext.SaveChangesAsync();


                return Ok(new { Message = $"La sección con ID {id} fue eliminada correctamente." }); // Retornar confirmación de eliminación
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de restricciones de base de datos
                return BadRequest(new { Message = $"No se pudo eliminar la sección con ID {id}.", Error = ex.Message });
            }

        }


        // actualizar una seccion dada
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeccion(int id, Seccion updatedSeccion)
        {
            if (id != updatedSeccion.Id)
            {
                return BadRequest("El ID de la sección no coincide.");
            }


            var seccion = await _appDbContext.Secciones.FindAsync(id);

            if (seccion == null)
            {
                return NotFound("Advertencia: Seccion no encontrado");
            }

            if (updatedSeccion.JefeSeccId != seccion.JefeSeccId) // si el jefe ha cambiado
            {
                var nuevoJefe = await _appDbContext.Usuarios
                                                  .FirstOrDefaultAsync(u => u.Id == updatedSeccion.JefeSeccId);

                if (nuevoJefe == null)
                {
                    return NotFound("El JefeSecc especificado no existe.");
                }

                if (nuevoJefe.Rol != "JefeSecc")
                {
                    return BadRequest("El usuario no tiene el rol adecuado para ser jefe de una sección.");
                }

                seccion.JefeSeccId = updatedSeccion.JefeSeccId;
            }

            //actualizar el campo del nombre de la seccion
            seccion.Nombre = updatedSeccion.Nombre;


            await _appDbContext.SaveChangesAsync();

            return Ok(new { Message = "Sección actualizada correctamente.", Seccion = seccion });
        }

    }
}
