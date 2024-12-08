





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
    public class EvaluacionesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public EvaluacionesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        

        [HttpPost]
        public async Task<ActionResult<Seccion>> CreateEvaluacion(Evaluacion evaluacion)
        {
            if (evaluacion == null)
            {
                return BadRequest("Sección no proporcionada.");
            }

            // Validar si el Jefe de la sección existe en la base de datos y tiene el rol adecuado
            var jefeSecc = await _appDbContext.Usuarios
                                              .FindAsync(evaluacion.JefeSeccId);

            if (jefeSecc == null)
            {
                return BadRequest("El JefeSecc con el ID proporcionado no existe.");
            }

            if (jefeSecc.Rol != "JefeSecc")
            {
                return BadRequest("El usuario no tiene el rol adecuado para ser jefe de una sección.");
            }

            // validar la existencia del tecnico

            var tecnico= await _appDbContext.Tecnicos.FindAsync(evaluacion.TecnicoId);
            if(tecnico == null)
            {
                return BadRequest("El Tecnico con el ID proporcionado no existe.");
            }

            
            // Agregar la nueva evaluacion
            _appDbContext.Evaluaciones.Add(evaluacion);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateEvaluacion), new { id = evaluacion.Id }, evaluacion);

        }


        //obtener todos las evaluaciones
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var evaluaciones = await _appDbContext.Evaluaciones
                                               .Include(s => s.JefeSecc)
                                               .Include(j=>j.Tecnico)
                                               .ToListAsync();

            if (evaluaciones == null || !evaluaciones.Any())
            {
                return NotFound("No hay evaluaciones registradas");
            }

            return Ok(evaluaciones);
        }

        

        //eliminar una evaluacion por su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluacion(int id)
        {
            var evaluacion = await _appDbContext.Evaluaciones.FindAsync(id);

            if (evaluacion == null)
            {
                return NotFound("Advertencia: Evaluacion no encontrada");
            }

            
            try
            {

                _appDbContext.Evaluaciones.Remove(evaluacion);// Eliminar la evaluacion
                await _appDbContext.SaveChangesAsync();


                return Ok(new { Message = $"La evaluacion con ID {id} fue eliminada correctamente." }); // Retornar confirmación de eliminación
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de restricciones de base de datos
                return BadRequest(new { Message = $"No se pudo eliminar la evaluacion con ID {id}.", Error = ex.Message });
            }

        }


        // actualizar una evaluacion dada
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvaluacion(int id, Evaluacion updatedEvaluacion)
        {
            if (id != updatedEvaluacion.Id)
            {
                return BadRequest("El ID de la evaluacion no coincide.");
            }


            var evaluacion = await _appDbContext.Evaluaciones.FindAsync(id);

            if (evaluacion == null)
            {
                return NotFound("Advertencia: Evaluacion no encontrado");
            }

            if (updatedEvaluacion.JefeSeccId != evaluacion.JefeSeccId) // si el jefe ha cambiado
            {
                var nuevoJefe = await _appDbContext.Usuarios
                                                  .FirstOrDefaultAsync(u => u.Id == updatedEvaluacion.JefeSeccId);

                if (nuevoJefe == null)
                {
                    return NotFound("El JefeSecc especificado no existe.");
                }

                if (nuevoJefe.Rol != "JefeSecc")
                {
                    return BadRequest("El usuario no tiene el rol adecuado para ser jefe de una sección.");
                }

                evaluacion.JefeSeccId = updatedEvaluacion.JefeSeccId;
            }


            evaluacion.Valoracion = updatedEvaluacion.Valoracion;


            await _appDbContext.SaveChangesAsync();

            return Ok(new { Message = "Evaluacion actualizada correctamente.", Evaluacion = evaluacion });
        }

    }
}
