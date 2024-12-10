
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
    public class MantenimientosRealizadosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public MantenimientosRealizadosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region POST
        //agregar un nuevo Mantenimiento
        [HttpPost]
        public async Task<IActionResult> AddMantenimientoRealizado(MantenimientoRealizado mantenimiento)
        {
            if (mantenimiento == null)
            {
                return BadRequest("Datos no proporcionados.");
            }

            // Validar que las llaves foráneas existen en la base de datos
            var tecnicoExists = await _appDbContext.Tecnicos.AnyAsync(t => t.Id == mantenimiento.TecnicoId);
            if (!tecnicoExists)
            {
                return BadRequest("El Técnico no existe.");
            }

            //Validar que exista ese mantenimiento
            var mantenimientoExists = await _appDbContext.Mantenimientos.AnyAsync(m => m.Id == mantenimiento.MantenimientoId);
            if (!mantenimientoExists)
            {
                return BadRequest("El Mantenimiento no existe.");
            }

            // Validar que el equipo exista
            var equipoExists = await _appDbContext.Equipos.AnyAsync(e => e.Id == mantenimiento.EquipoId);
            if (!equipoExists)
            {
                return BadRequest("El Equipo no existe.");
            }


            //agregamo el mantenimiento realizado
            _appDbContext.MantenimientosRealizados.Add(mantenimiento);
            await _appDbContext.SaveChangesAsync();// guarda el Mantenimientoo en la base de datos

            return Ok(mantenimiento);// return de que salio bien la operacion
        }

        #endregion
        #region GET

        //obtener todos los Mantenimientos
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var mantenimientos = await _appDbContext.MantenimientosRealizados.ToListAsync();

            return Ok(mantenimientos);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMantenimientoRealizado(int id)
        {
            var mantenimientos = await _appDbContext.MantenimientosRealizados.FindAsync(id);

            if (mantenimientos == null)
            {
                return NotFound("Advertencia: Mantenimiento no encontrado");
            }

            return Ok(mantenimientos);
        }
        #endregion
        #region DELETE

        //eliminar un Mantenimiento por su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimientoRealizado(int id)
        {
            var mantenimiento = await _appDbContext.MantenimientosRealizados.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound("Advertencia: Mantenimiento no encontrado");
            }

            _appDbContext.MantenimientosRealizados.Remove(mantenimiento);

            await _appDbContext.SaveChangesAsync();

            return Ok($"Mantenimiento realizado con ID {id} ha sido borrado");
        }
        #endregion
        #region PUT


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMantenimientoRealizado(int id, MantenimientoRealizado updatedMantenimientoRealizado)
        {
            if (id != updatedMantenimientoRealizado.Id)
            {
                return BadRequest("El ID del mantenimiento no coincide con el proporcionado en la URL.");
            }
            var mantenimiento = await _appDbContext.MantenimientosRealizados.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound("Advertencia: Mantenimiento no encontrado");
            }

            mantenimiento.CostoMant = updatedMantenimientoRealizado.CostoMant;

            // Si cambian los IDs relacionados, validar que existan antes de actualizar
            if (mantenimiento.TecnicoId != updatedMantenimientoRealizado.TecnicoId)
            {
                var tecnicoExists = await _appDbContext.Tecnicos.AnyAsync(t => t.Id == updatedMantenimientoRealizado.TecnicoId);
                if (!tecnicoExists)
                {
                    return BadRequest("El técnico proporcionado no existe.");
                }
                mantenimiento.TecnicoId = updatedMantenimientoRealizado.TecnicoId;
            }

            if (mantenimiento.MantenimientoId != updatedMantenimientoRealizado.MantenimientoId)
            {
                var mantenimientoExists = await _appDbContext.Mantenimientos.AnyAsync(m => m.Id == updatedMantenimientoRealizado.MantenimientoId);
                if (!mantenimientoExists)
                {
                    return BadRequest("El mantenimiento proporcionado no existe.");
                }
                mantenimiento.MantenimientoId = updatedMantenimientoRealizado.MantenimientoId;
            }

            if (mantenimiento.EquipoId != updatedMantenimientoRealizado.EquipoId)
            {
                var equipoExists = await _appDbContext.Equipos.AnyAsync(e => e.Id == updatedMantenimientoRealizado.EquipoId);
                if (!equipoExists)
                {
                    return BadRequest("El equipo proporcionado no existe.");
                }
                mantenimiento.EquipoId = updatedMantenimientoRealizado.EquipoId;
            }

            // Guardar cambios
            await _appDbContext.SaveChangesAsync();

            return Ok("Mantenimiento realizado actualizado correctamente.");
        }

        #endregion

    }
}
