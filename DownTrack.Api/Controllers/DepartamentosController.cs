






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
    public class DepartamentosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public DepartamentosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



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

        

        //eliminar un Departamento por su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var Departamento = await _appDbContext.Departamentos.FindAsync(id);

            if (Departamento == null)
            {
                return NotFound("Advertencia: Departamento no encontrado");
            }


            //usar bloque try and catch por si hay restricciones en la base de dato (integridad referencial)
            try
            {

                _appDbContext.Departamentos.Remove(Departamento);// Eliminar la sección
                await _appDbContext.SaveChangesAsync();


                return Ok(new { Message = $"La sección con ID {id} fue eliminada correctamente." }); // Retornar confirmación de eliminación
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de restricciones de base de datos
                return BadRequest(new { Message = $"No se pudo eliminar la sección con ID {id}.", Error = ex.Message });
            }

        }


        // actualizar una Departamento dada
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, Departamento updatedDepartamento)
        {
            if (id != updatedDepartamento.Id)
            {
                return BadRequest("El ID de la sección no coincide.");
            }


            var Departamento = await _appDbContext.Departamentos.FindAsync(id);

            if (Departamento == null)
            {
                return NotFound("Advertencia: Departamento no encontrado");
            }

            
            //actualizar el campo del nombre de la Departamento
            Departamento.Nombre = updatedDepartamento.Nombre;
            
            await _appDbContext.SaveChangesAsync();

            return Ok(new { Message = "Sección actualizada correctamente.", Departamento = Departamento });
        }

    }
}
