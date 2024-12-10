
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
    public class DepartamentosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public DepartamentosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region POST

        [HttpPost]
        public async Task<ActionResult<Departamento>> AddDepartamento(Departamento departamento)
        {
            if (departamento == null)
            {
                return BadRequest("Departamento no proporcionado.");
            }

            // Buscar la sección por el Id
            var seccion = await _appDbContext.Secciones
                                              .FindAsync(departamento.SeccionId);

            if (seccion == null)
            {
                return BadRequest("La sección asociada no existe.");
            }


            // Agregar lel nuevo departamento
            _appDbContext.Departamentos.Add(departamento);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddDepartamento), new { id = departamento.Id }, departamento);

        }

        #endregion
        #region GET

        //obtener todos los Departamentoes junto con los datos del JefeSecc asociado
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            // Obtener los departamentos junto con la sección asociada y el jefe de sección
            var departamentos = await _appDbContext.Departamentos
                                                    .Include(d => d.Seccion)  // Incluir la Sección asociada
                                                    .ToListAsync();

            if (departamentos == null || !departamentos.Any())
            {
                return NotFound("No hay departamentos registrados.");
            }

            return Ok(departamentos);
        }

        [HttpGet("{DepartamentoId}")]

        public async Task<IActionResult> GetDepartamento(int DepartamentoId, int SeccionId)
        {
            // Obtener el departamento 
            var departamento = await _appDbContext.Departamentos
                                        .Where(d => d.Id == DepartamentoId && d.SeccionId == SeccionId)  // Filtra por ambos ids
                                        .Include(d => d.Seccion)  // Incluir la Sección asociada
                                        .FirstOrDefaultAsync();
            if (departamento == null)
            {
                return NotFound("No hay departamentos registrado con ese ID.");
            }

            return Ok(departamento);
        }


        #endregion
        #region DELETE
        //eliminar un Departamento por su id
        [HttpDelete("{DepartamentoId}")]
        public async Task<IActionResult> DeleteDepartamento(int DepartamentoId, int SeccionId)
        {
            // Obtener el departamento 
            var departamento = await _appDbContext.Departamentos
                                        .Where(d => d.Id == DepartamentoId && d.SeccionId == SeccionId)  // Filtra por ambos ids
                                        .Include(d => d.Seccion)  // Incluir la Sección asociada
                                        .FirstOrDefaultAsync();
            if (departamento == null)
            {
                return NotFound("Advertencia: Departamento no encontrado");
            }

            //usar bloque try and catch por si hay restricciones en la base de dato (integridad referencial)
            try
            {

                _appDbContext.Departamentos.Remove(departamento);// Eliminar la sección
                await _appDbContext.SaveChangesAsync();

                return Ok(new { Message = $"El departamento con ID {DepartamentoId} y {SeccionId} fue eliminado correctamente." }); // Retornar confirmación de eliminación
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de restricciones de base de datos
                return BadRequest(new { Message = $"No se pudo eliminar el departamento con ID {DepartamentoId}.", Error = ex.Message });
            }

        }

        #endregion
        #region PUT
        // actualizar una Departamento dada
        [HttpPut("{DepartamentoId}")]
        public async Task<IActionResult> UpdateDepartamento(int DepartamentoId, int SeccionId, Departamento updatedDepartamento)
        {
            if (DepartamentoId != updatedDepartamento.Id)
            {
                return BadRequest("El ID del departamento no coincide.");
            }
            if(SeccionId != updatedDepartamento.SeccionId)
            {
                return BadRequest("El ID de la sección no coincide.");
            }

            var departamento = await _appDbContext.Departamentos
                                        .Where(d => d.Id == DepartamentoId && d.SeccionId == SeccionId)  // Filtra por ambos ids
                                        .Include(d => d.Seccion)  // Incluir la Sección asociada
                                        .FirstOrDefaultAsync();
            
            if (departamento == null)
            {
                return NotFound("Advertencia: Departamento no encontrado");
            }


            //actualizar el campo del nombre de la Departamento
            departamento.Nombre = updatedDepartamento.Nombre;

            await _appDbContext.SaveChangesAsync();

            return Ok(new { Message = "Departamento actualizado correctamente.", Departamento = departamento });
        }

        #endregion
    }
}
