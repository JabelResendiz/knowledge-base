using EntityFrameworkCore.MySQL.Data;
using EntityFrameworkCore.MySQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<IActionResult> AddUsuario(Usuario usuario)
        {
            _appDbContext.Usuarios.Add(usuario);
            await _appDbContext.SaveChangesAsync();

            
            return Ok(usuario);
        }

        [HttpGet]

        public async Task<IActionResult> GetAll(){
            var usuarios=await _appDbContext.Usuarios.ToListAsync();

            return Ok(usuarios);
        }


        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id){
            var usuario=await _appDbContext.Usuarios.FindAsync(id);

            if (usuario == null){
                return NotFound("Advertencia: Usuario no encontrado");
            }

            _appDbContext.Usuarios.Remove(usuario);

            await _appDbContext.SaveChangesAsync();

            return Ok($"Usuario con ID {id} ha sido borrado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario updatedUsuario)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Advertencia: Usuario no encontrado");
            }

            usuario.Nombre = updatedUsuario.Nombre;
            usuario.Rol = updatedUsuario.Rol;
            
            await _appDbContext.SaveChangesAsync();

            return Ok(usuario);
        }
    }
}
