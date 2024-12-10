


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
    public class TrasladosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public TrasladosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region  POST
        //agregar un nuevo traslado
        [HttpPost]
        public async Task<IActionResult> AddTraslado([FromBody] Traslado traslado)
        {
            if (traslado == null)
            {
                return BadRequest("Traslado no proporcionado.");
            }

            // Verificar que la solicitud existe y no tiene un traslado asociado
            var solicitud = await _appDbContext.Solicitudes.FindAsync(traslado.SolicitudId);
            if (solicitud == null || solicitud.TrasladoId.HasValue)
            {
                return BadRequest("Solicitud inválida o ya tiene un traslado asociado");
            }

            // Verificar que los departamentos y secciones existen
            var departamentoSalida = await _appDbContext.Departamentos.FindAsync(traslado.DepartamentoSalidaId);
            var departamentoReceptor = await _appDbContext.Departamentos.FindAsync(traslado.DepartamentoReceptorId);
            var seccionSalida = await _appDbContext.Secciones.FindAsync(traslado.SeccionSalidaId);
            var seccionReceptor = await _appDbContext.Secciones.FindAsync(traslado.SeccionReceptorId);


            if (departamentoSalida == null || departamentoReceptor == null || seccionSalida == null || seccionReceptor == null)
            {
                return BadRequest("Departamentos o secciones inválidos");
            }

            if (departamentoSalida.SeccionId != seccionSalida.Id || departamentoReceptor.SeccionId != seccionReceptor.Id)
            {
                return BadRequest("Departamento no pertenece a esa Seccion");
            }

            // Verificar que el ReceptorEquipo y ResponsableEnvio existen
            var receptorEquipo = await _appDbContext.ReceptoresEquipos.FindAsync(traslado.ReceptorEquipoId);
            var responsableEnvio = await _appDbContext.Usuarios.FindAsync(traslado.ResponsableEnvioId);
            if (receptorEquipo == null || responsableEnvio == null || responsableEnvio.Rol != "ResponsableEnvio")
            {
                return BadRequest("ReceptorEquipo o ResponsableEnvio inválidos");
            }

            if (receptorEquipo.SeccionId != seccionReceptor.Id || receptorEquipo.DepartamentoId != departamentoReceptor.Id)
            {
                return BadRequest("ReceptorEquipo no pertenece a esa ubicacion que diste");
            }

            _appDbContext.Traslados.Add(traslado);
            solicitud.TrasladoId = traslado.Id;
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTraslado), new { id = traslado.Id }, traslado);


        }
        #endregion
        #region GET

        //obtener todos los traslados
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var solicitudes = await _appDbContext.Traslados
                                   .ToListAsync();

            return Ok(solicitudes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Traslado>> GetTraslado(int id)
        {
            var traslado = await _appDbContext.Traslados
                .Include(t => t.Solicitud)
                .Include(t => t.DepartamentoSalida)
                .Include(t => t.DepartamentoReceptor)
                .Include(t => t.SeccionSalida)
                .Include(t => t.SeccionReceptor)
                .Include(t => t.receptorEquipo)
                .Include(t => t.ResponsableEnvio)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (traslado == null)
            {
                return NotFound();
            }

            return traslado;
        }


        #endregion

        #region DELETE
        //eliminar un traslado  dado su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int id)
        {
            var traslados = await _appDbContext.Traslados.FindAsync(id);
            if (traslados == null)
            {
                return NotFound("Traslado no encontrado.");
            }

            _appDbContext.Traslados.Remove(traslados);
            await _appDbContext.SaveChangesAsync();

            return Ok("Traslado eliminado correctamente.");
        }
        #endregion

        #region PUT
        //actualizar un traslado dado su ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraslado(int id, Traslado updatedTraslado)
        {
            if (id != updatedTraslado.Id)
            {
                return BadRequest("El ID del traslado no coincide con el proporcionado en la URL.");
            }
            var existingTraslado = await _appDbContext.Traslados.FindAsync(id);

            if (existingTraslado == null)
            {
                return NotFound("Traslado no encontrado.");
            }
            try
            {
                var departamentoSalida = await _appDbContext.Departamentos.FindAsync(updatedTraslado.DepartamentoSalidaId);
                var departamentoReceptor = await _appDbContext.Departamentos.FindAsync(updatedTraslado.DepartamentoReceptorId);
                var seccionSalida = await _appDbContext.Secciones.FindAsync(updatedTraslado.SeccionSalidaId);
                var seccionReceptor = await _appDbContext.Secciones.FindAsync(updatedTraslado.SeccionReceptorId);

                if (departamentoSalida == null || departamentoReceptor == null || seccionSalida == null || seccionReceptor == null)
                {
                    return BadRequest("Departamentos o secciones inválidos");
                }

                // Verificar que los departamentos pertenecen a las secciones especificadas
                if (departamentoSalida.SeccionId != seccionSalida.Id || departamentoReceptor.SeccionId != seccionReceptor.Id)
                {
                    return BadRequest("Los departamentos no pertenecen a las secciones especificadas");
                }

                // Verificar que el ReceptorEquipo y ResponsableEnvio existen y son válidos
                var receptorEquipo = await _appDbContext.ReceptoresEquipos.FindAsync(updatedTraslado.ReceptorEquipoId);
                var responsableEnvio = await _appDbContext.Usuarios.FindAsync(updatedTraslado.ResponsableEnvioId);

                if (receptorEquipo == null || responsableEnvio == null || responsableEnvio.Rol != "ResponsableEnvio")
                {
                    return BadRequest("ReceptorEquipo o ResponsableEnvio inválidos");
                }

                // Verificar que el ReceptorEquipo pertenece al departamento y sección de destino
                if (receptorEquipo.SeccionId != seccionReceptor.Id || receptorEquipo.DepartamentoId != departamentoReceptor.Id)
                {
                    return BadRequest("El ReceptorEquipo no pertenece a la ubicación de destino especificada");
                }

                // Actualizar los campos del traslado existente
                existingTraslado.DepartamentoSalidaId = updatedTraslado.DepartamentoSalidaId;
                existingTraslado.SeccionSalidaId = updatedTraslado.SeccionSalidaId;
                existingTraslado.DepartamentoReceptorId = updatedTraslado.DepartamentoReceptorId;
                existingTraslado.SeccionReceptorId = updatedTraslado.SeccionReceptorId;
                existingTraslado.FechaTraslado = updatedTraslado.FechaTraslado;
                existingTraslado.ReceptorEquipoId = updatedTraslado.ReceptorEquipoId;
                existingTraslado.ResponsableEnvioId = updatedTraslado.ResponsableEnvioId;

                await _appDbContext.SaveChangesAsync();
                return Ok("Actualizacion efectuada");


            }
            catch(Exception ex)
            {
                return BadRequest($"Debes rellenar todos los campos . {ex}");
            }


        }

        #endregion

    }
}
