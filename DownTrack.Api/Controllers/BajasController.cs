
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
    public class BajasEquiposController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public BajasEquiposController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //agregar una nueva baja
        [HttpPost]
        public async Task<IActionResult> AddBaja(BajaEquipo baja)
        {
            if (baja == null)
            {
                return BadRequest("Datos no proporcionados.");
            }
            
            // Validar que las llaves foráneas existen en la base de datos
            var tecnico = await _appDbContext.Tecnicos.FindAsync(baja.TecnicoId);
            if (tecnico ==null)
            {
                return NotFound("El Técnico no existe.");
            }


            // Validar que el equipo exista
            var equipo = await _appDbContext.Equipos.FindAsync(baja.EquipoId);
            if (equipo == null)
            {
                return NotFound("El Equipo no existe.");
            }
            //validar que el equipo no haya estado de baja

            if(equipo.Estado == "baja")
            {
                return BadRequest("El equipo ya está en estado de baja.");
            }


            equipo.Estado = "baja"; // actualizar el estado del equipo

            //agregamo la baja  realizada
            _appDbContext.BajasEquipos.Add(baja);
            await _appDbContext.SaveChangesAsync();// guarda el bajao en la base de datos

            return Ok(baja);// return de que salio bien la operacion
        }


        //obtener todos los bajas
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var bajas = await _appDbContext.BajasEquipos
                                   .Include(b => b.Tecnico)
                                   .Include(b => b.Equipo)
                                   .ToListAsync();
            if (!bajas.Any())
            {
                return NotFound("No hay bajas registradas.");
            }

            return Ok(bajas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaja(int id)
        {
            var baja = await _appDbContext.BajasEquipos.FindAsync(id);
            if (baja == null)
            {
                return NotFound("Baja no encontrada.");
            }

            _appDbContext.BajasEquipos.Remove(baja);
            await _appDbContext.SaveChangesAsync();

            return Ok("Baja eliminada correctamente.");
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBaja(int id, BajaEquipo updatedBaja)
        {
            if (id != updatedBaja.Id)
            {
                return BadRequest("El ID del baja no coincide con el proporcionado en la URL.");
            }
            var existingBaja = await _appDbContext.BajasEquipos.FindAsync(id);

            if (existingBaja == null)
            {
                return NotFound("Baja no encontrada.");
            }

            // Si cambian los IDs relacionados, validar que existan antes de actualizar
            if (existingBaja.TecnicoId != updatedBaja.TecnicoId)
            {
                var tecnicoExists = await _appDbContext.Tecnicos.AnyAsync(t => t.Id == updatedBaja.TecnicoId);
                if (!tecnicoExists)
                {
                    return BadRequest("El técnico proporcionado no existe.");
                }
                existingBaja.TecnicoId = updatedBaja.TecnicoId;
            }


            if (existingBaja.EquipoId != updatedBaja.EquipoId)
            {
                var equipoExists = await _appDbContext.Equipos.AnyAsync(e => e.Id == updatedBaja.EquipoId);
                if (!equipoExists)
                {
                    return BadRequest("El equipo proporcionado no existe.");
                }
                existingBaja.EquipoId = updatedBaja.EquipoId;
            }

            existingBaja.FechaBaja = updatedBaja.FechaBaja;
            existingBaja.CausaBaja = updatedBaja.CausaBaja;
            // Guardar cambios
            _appDbContext.BajasEquipos.Update(existingBaja);
            await _appDbContext.SaveChangesAsync();

            return Ok("baja  actualizado correctamente.");
        }

    }
}
