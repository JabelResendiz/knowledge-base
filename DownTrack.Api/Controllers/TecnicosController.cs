using EntityFrameworkCore.MySQL.Data;
using EntityFrameworkCore.MySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public TecnicosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region POST
        // agregar un tecnico
        [HttpPost]
        public async Task<IActionResult> CreateTecnico([FromBody] Tecnico tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Agregar el técnico al DbSet
                _appDbContext.Tecnicos.Add(tecnico);
                await _appDbContext.SaveChangesAsync();

                // Retornar el técnico creado
                return CreatedAtAction(nameof(GetTecnico), new { id = tecnico.Id }, tecnico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar en la base de datos: {ex.Message}");
            }
        }
        #endregion
        #region GET
        // leer todos los tecnicos
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var tecnicos = await _appDbContext.Tecnicos.ToListAsync();

            return Ok(tecnicos);
        }

        //leer un tecnico por su id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTecnico(int id)
        {
            var tecnico = await _appDbContext.Tecnicos
                                    .Include(t=> t.MantenimientosRealizados)
                                    .FirstOrDefaultAsync(t => t.Id == id);

            if (tecnico == null)
            {
                return NotFound("Tecnico no encontrado");
            }

            return Ok(tecnico);
        }
        #endregion
        #region DELETE
        // borrar un tecnico por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnico(int id)
        {
            var tecnico = await _appDbContext.Tecnicos.FindAsync(id);

            if (tecnico == null)
            {
                return NotFound("Advertencia: Tecnico no encontrado");
            }

            try
            {
                _appDbContext.Tecnicos.Remove(tecnico);
                await _appDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el técnico: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        #endregion

        #region PUT
        //actualizar los campos dado el ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTecnico(int id, [FromBody] Tecnico updatedTecnico)
        {
            if (id != updatedTecnico.Id)
            {
                return BadRequest("El ID del técnico no coincide.");
            }

            try
            {
                _appDbContext.Tecnicos.Update(updatedTecnico);
                await _appDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el técnico: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        #endregion
    }
}
