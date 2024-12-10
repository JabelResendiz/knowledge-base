
using EntityFrameworkCore.MySQL.Data;
using EntityFrameworkCore.MySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// controladores de API que se utiliza para interactuar con la base de datos
// cada controlador maneja operaciones CRUD  para una entidad especifica
// todos deben heredar de ControllerBase que es la base para los controladores


namespace EntityFrameworkCore.MySQL.Controllers
{
    [Route("api/[controller]")] // define una ruta base , lo que significa que las rutas comenzaran con "api/" seguido del nombre del controlador
    [ApiController] // atributo especifico para habilitra comportamientos de API
    public class SolicitudesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public SolicitudesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region  POST
        //agregar una nueva solicitud
        [HttpPost]
        public async Task<IActionResult> AddSolicitud([FromBody] Solicitud solicitud)
        {
            if (solicitud == null)
            {
                return BadRequest("Solicitud no proporcionada.");
            }

            // Verificar que el JefeSecc exista
            var jefeSecc = await _appDbContext.Usuarios
                                              .FindAsync(solicitud.JefeSeccId);
            if (jefeSecc == null)
            {
                return BadRequest("El JefeSecc con el ID proporcionado no existe.");
            }

            if (jefeSecc.Rol != "JefeSecc")
            {
                return BadRequest("El usuario no tiene el rol adecuado para ser jefe de una sección.");
            }

            //verificar que el equipo exista
            var equipo = await _appDbContext.Equipos
                                            .FindAsync(solicitud.EquipoId);
            if (equipo == null)
            {
                return BadRequest("El Equipo con el ID proporcionado no existe.");
            }

            // Verificar que el equipo pertenece al inventario del jefe de sección
            var perteneceInventario = await _appDbContext.Secciones
                                                         .Where(s => s.JefeSeccId == solicitud.JefeSeccId)
                                                         .SelectMany(s => s.Departamentos)
                                                         .SelectMany(d => d.Equipos)
                                                         .AnyAsync(e => e.Id == solicitud.EquipoId);
            if (!perteneceInventario)
            {
                return BadRequest("El equipo no pertenece al inventario del jefe de sección.");
            }

            _appDbContext.Solicitudes.Add(solicitud);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSolicitud), new { id = solicitud.Id }, solicitud);

        }
        #endregion
        #region GET

        //obtener todos los bajas
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var solicitudes = await _appDbContext.Solicitudes
                                   .Include(b => b.JefeSecc)
                                   .Include(b => b.Equipo)
                                   .ToListAsync();

            return Ok(solicitudes);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSolicitud(int id)
        {
            var solicitud = await _appDbContext.Solicitudes.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound("No hay solicitud con ese ID");
            }

            return Ok(solicitud);
        }


        #endregion

        #region DELETE
        //eliminar una solicitud dado su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int id)
        {
            var solicitud = await _appDbContext.Solicitudes.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound("Solicitud no encontrada.");
            }

            _appDbContext.Solicitudes.Remove(solicitud);
            await _appDbContext.SaveChangesAsync();

            return Ok("Solicitud eliminada correctamente.");
        }
        #endregion

        #region PUT
        //actualizar una solicitud dado su ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSolicitud(int id, Solicitud updatedSolicitud)
        {
            if (id != updatedSolicitud.Id)
            {
                return BadRequest("El ID de la solicitud no coincide con el proporcionado en la URL.");
            }
            var existingSolicitud = await _appDbContext.Solicitudes.FindAsync(id);

            if (existingSolicitud == null)
            {
                return NotFound("Solicitud no encontrada.");
            }

            // Si cambian los IDs relacionados, validar que existan antes de actualizar
            if (existingSolicitud.JefeSeccId != updatedSolicitud.JefeSeccId)
            {
                var jefeSecc = await _appDbContext.Usuarios.FindAsync(updatedSolicitud.JefeSeccId);
                if (jefeSecc == null)
                {
                    return BadRequest("El Jefe de sección proporcionado no existe.");
                }

                if (jefeSecc.Rol != "JefeSecc")
                {
                    return BadRequest("El usuario no tiene el rol adecuado para ser jefe de una sección.");
                }

                
            }

            //validar la presencia del equipo
            if (existingSolicitud.EquipoId != updatedSolicitud.EquipoId)
            {
                

                var equipo = await _appDbContext.Equipos.FindAsync(updatedSolicitud.EquipoId);
                if (equipo == null)
                {
                    return BadRequest("El equipo proporcionado no existe.");
                }

                // Verificar que el equipo nuevo pertenece al inventario del jefe de sección nuevo
                var perteneceInventario = await _appDbContext.Secciones
                                                             .Where(s => s.JefeSeccId == updatedSolicitud.JefeSeccId)
                                                             .SelectMany(s => s.Departamentos)
                                                             .SelectMany(d => d.Equipos)
                                                             .AnyAsync(e => e.Id == updatedSolicitud.EquipoId);
                if (!perteneceInventario)
                {
                    return BadRequest("El equipo no pertenece al inventario del jefe de sección.");
                }

                existingSolicitud.EquipoId = updatedSolicitud.EquipoId;
            }

            existingSolicitud.FechaSolicitud = updatedSolicitud.FechaSolicitud;
            existingSolicitud.JefeSeccId = updatedSolicitud.JefeSeccId;

            await _appDbContext.SaveChangesAsync();

            return Ok("Solicitud actualizada correctamente.");
        }

        #endregion

    }
}
