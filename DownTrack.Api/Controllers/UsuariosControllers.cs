using EntityFrameworkCore.MySQL.Data;
using EntityFrameworkCore.MySQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MySqlConnector;

namespace EntityFrameworkCore.MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public UsuariosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #region POST
        [HttpPost]

        // agregar un nuevo usuario
        public async Task<IActionResult> AddUsuarios(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            if (usuario.Rol == "Tecnico" || usuario.Rol == "ReceptorDeEquipo")
            {
                return BadRequest($"No es posible agregar un {usuario.Rol}  desde esta seccion");
            }
            _appDbContext.Usuarios.Add(usuario);
            await _appDbContext.SaveChangesAsync();

            return Ok(usuario);
        }
        #endregion
        #region GET
        [HttpGet]
        // obtner todos los usuarios
        public async Task<IActionResult> GetAll()
        {
            var directores = await _appDbContext.Usuarios.ToListAsync();

            return Ok(directores);
        }


        [HttpGet("{id}")]
        // obtener el usuario dado un ID
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var director = await _appDbContext.Usuarios.FindAsync(id);

            if (director == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(director);
        }
        #endregion
        #region DELETE
        // eliminar un usuario
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Advertencia: Usuario no encontrado");
            }
            if (usuario.Rol == "Tecnico" || usuario.Rol == "ReceptorDeEquipo")
            {
                return BadRequest($"Solo se puede eliminar {usuario.Rol} en la tabla correspondiente ");
            }

            try
            {
                _appDbContext.Usuarios.Remove(usuario);

                await _appDbContext.SaveChangesAsync();

                return Ok($"Usuario con ID {id} ha sido borrado");

            }
            catch (DbUpdateException ex) when (ex.InnerException is MySqlException mysqlEx && mysqlEx.Number == 1451)
            {
                // Número 1451 es el código de error para "Cannot delete or update a parent row: a foreign key constraint fails"
                return BadRequest("No se puede eliminar el usuario porque tiene secciones asociadas. Por favor, reasigna o elimina las secciones antes de intentar eliminar este usuario.");
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                return StatusCode(500, "Ocurrió un error inesperado. Por favor, inténtalo de nuevo más tarde.");
            }
        }
        #endregion
        #region PUT
        //actualizar un usuario , nombre o rol
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario updatedUsuario)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Advertencia: Usuario no encontrado");
            }

            usuario.Nombre = updatedUsuario.Nombre;

            await _appDbContext.SaveChangesAsync();

            return Ok(usuario);
        }


        [HttpPut("cambiar-rol/{id}")]
        public async Task<IActionResult> CambiarRol(int id, [FromBody] CambiarRolRequest request)
        {
            // Buscar al usuario
            var usuario = await _appDbContext.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }


            // Si el rol actual es Tecnico, eliminar los datos de Tecnico
            if (usuario.Rol == "Tecnico")
            {
                var tecnico = await _appDbContext.Tecnicos.FindAsync(id);
                if (tecnico != null)
                {
                    _appDbContext.Tecnicos.Remove(tecnico);

                }
            }

            // Si el rol actual es Receptor, eliminar los datos de Receptor
            if (usuario.Rol == "Receptor")
            {
                var receptor = await _appDbContext.ReceptoresEquipos.FindAsync(id);
                if (receptor != null)
                {
                    _appDbContext.ReceptoresEquipos.Remove(receptor);
                }
            }

            // Cambiar el rol del usuario
            usuario.Rol = request.RolNuevo;

            // Crear el nuevo registro dependiendo del rol
            if (request.RolNuevo == "Tecnico")
            {
                var tecnico = new Tecnico
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Especialidad = request.Especialidad,
                    Salario = request.Salario,
                    AñosExp = request.AñosExp,
                    Rol = "Tecnico"
                };
                _appDbContext.Usuarios.Remove(usuario);
                _appDbContext.Tecnicos.Add(tecnico);
            }
            else if (request.RolNuevo == "Receptor")
            {
                var receptor = new ReceptorEquipo
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    DepartamentoId = request.DepartamentoId,
                    SeccionId = request.SeccionId,
                    Rol = "ReceptorDeEquipo"
                };
                _appDbContext.Usuarios.Remove(usuario);
                _appDbContext.ReceptoresEquipos.Add(receptor);
            }


            // Guardar los cambios en la base de datos
            await _appDbContext.SaveChangesAsync();

            return Ok(usuario);
        }
        #endregion
    }
}
