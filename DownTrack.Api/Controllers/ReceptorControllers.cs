
using EntityFrameworkCore.MySQL.Data;
using EntityFrameworkCore.MySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptoresEquiposController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ReceptoresEquiposController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region POST
        //agregar un receptor de equipo
        [HttpPost]
        public async Task<IActionResult> AddReceptorEquipo([FromBody] ReceptorEquipo receptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var departamento = await _appDbContext.Departamentos
                                                    .Where(d => d.Id == receptor.DepartamentoId && d.SeccionId == receptor.SeccionId)
                                                    .FirstOrDefaultAsync();
                if (departamento == null)
                {
                    return NotFound("El departamento no pertenece a esta sección.");

                }
                // Agregar el receptor al DbSet
                _appDbContext.ReceptoresEquipos.Add(receptor);
                await _appDbContext.SaveChangesAsync();

                // Retornar el receptor creado
                return CreatedAtAction(nameof(GetReceptor), new { id = receptor.Id }, receptor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar en la base de datos: {ex.Message}");
            }
        }
        #endregion
        #region GET
        // leer todos los receptores
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var receptores = await _appDbContext.ReceptoresEquipos.ToListAsync();

            return Ok(receptores);
        }

        //leer un receptor por su id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceptor(int id)
        {
            var receptor = await _appDbContext.ReceptoresEquipos
                                    .FirstOrDefaultAsync(t => t.Id == id);

            if (receptor == null)
            {
                return NotFound("Receptor de equipo no encontrado");
            }

            return Ok(receptor);
        }
        #endregion
        // borrar un tecnico por su ID
        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceptor(int id)
        {
            var receptor = await _appDbContext.ReceptoresEquipos.FindAsync(id);

            if (receptor == null)
            {
                return NotFound("Advertencia: Receptor no encontrado");
            }

            try
            {
                _appDbContext.ReceptoresEquipos.Remove(receptor);
                await _appDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el receptor : {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        #endregion

        #region PUT
        //actualizar los campos dado el ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceptor(int id, [FromBody] ReceptorEquipo updatedReceptor)
        {
            if (id != updatedReceptor.Id)
            {
                return BadRequest("El ID del receptor no coincide.");
            }

            try
            {
                var departamento = await _appDbContext.Departamentos
                                                   .Where(d => d.Id == updatedReceptor.DepartamentoId && d.SeccionId == updatedReceptor.SeccionId)
                                                   .FirstOrDefaultAsync();
                if (departamento == null)
                {
                    return NotFound("El departamento no pertenece a esta sección.");

                }
                _appDbContext.ReceptoresEquipos.Update(updatedReceptor);
                await _appDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el receptor: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        #endregion
    }
}
