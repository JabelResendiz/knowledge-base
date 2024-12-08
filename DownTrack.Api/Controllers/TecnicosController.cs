using EntityFrameworkCore.MySQL.Data;
using EntityFrameworkCore.MySQL.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> AddTecnico(Tecnico tecnico)
        {

            if (tecnico == null)
            {
                return BadRequest("Técnico no proporcionado.");
            }

            if (tecnico.Salario < 0 || tecnico.AñosExp < 0)
            {
                return BadRequest("Salario y años de experiencia no pueden ser nulos o cero.");
            }

            Usuario user = new Usuario
            {
                Id = tecnico.Id,
                Nombre = tecnico.Nombre,
                Rol = "Tecnico"
            };


            _appDbContext.Usuarios.Add(user);
            await _appDbContext.SaveChangesAsync();

            _appDbContext.Tecnicos.Add(tecnico);
            await _appDbContext.SaveChangesAsync();


            return Ok(tecnico);
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var tecnicos = await _appDbContext.Tecnicos.ToListAsync();

            return Ok(tecnicos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnico(int id)
        {
            var tecnico = await _appDbContext.Tecnicos.FindAsync(id);

            if (tecnico == null)
            {
                return NotFound("Advertencia: Tecnico no encontrado");
            }

            _appDbContext.Tecnicos.Remove(tecnico);

            await _appDbContext.SaveChangesAsync();

            // borramos en la tabla 

            var usuario = await _appDbContext.Usuarios.FindAsync(id);

            _appDbContext.Usuarios.Remove(usuario);

            await _appDbContext.SaveChangesAsync();

            return Ok($"Tecnico con ID {id} ha sido borrado");
        }

        //  [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateTecnico(int id,Tecnico updatedTecnico)
        // {
        //     var tecnico = await _appDbContext.Tecnicos.FindAsync(id);

        //     if (tecnico == null)
        //     {
        //         return NotFound("Advertencia: Usuario no encontrado");
        //     }

        //     tecnico.Nombre = updatedTecnico.Nombre;
        //     usuario.Rol = updatedUsuario.Rol;

        //     await _appDbContext.SaveChangesAsync();

        //     return Ok(usuario);
        // }
    }
}
