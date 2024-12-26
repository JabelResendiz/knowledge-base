
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
    public class MantenimientosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public MantenimientosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region POST
        //agregar un nuevo Mantenimiento
        [HttpPost]
        public async Task<IActionResult> AddMantenimiento(Mantenimiento mantenimiento)
        {
            if (mantenimiento == null)
            {
                return BadRequest("Departamento no proporcionado.");
            }
            _appDbContext.Mantenimientos.Add(mantenimiento);
            await _appDbContext.SaveChangesAsync();// guarda el Mantenimientoo en la base de datos

            return Ok(mantenimiento);// return de que salio bien la operacion
        }

        #endregion
        #region GET
        //obtener todos los Mantenimientos
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var mantenimientos = await _appDbContext.Mantenimientos.ToListAsync();

            return Ok(mantenimientos);
        }


        // leer un mantenimiento por su ID
        [HttpGet("{id}")]

        public async Task<IActionResult> GetMantenimiento(int id)
        {
            var mantenimiento = await _appDbContext.Mantenimientos
                                     .FirstOrDefaultAsync(t => t.Id == id);

            if (mantenimiento == null)
            {
                return NotFound("Mantenimiento no encontrado");
            }

            return Ok(mantenimiento);
        }
        #endregion
        #region DELETE

        //eliminar un Mantenimiento por su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento(int id)
        {
            var mantenimiento = await _appDbContext.Mantenimientos.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound("Advertencia: Mantenimiento no encontrado");
            }

            _appDbContext.Mantenimientos.Remove(mantenimiento);

            await _appDbContext.SaveChangesAsync();

            return Ok($"Mantenimiento con ID {id} ha sido borrado");
        }

        #endregion
        #region PUT
        // actualizar un mantenimiento por su ID

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMantenimiento(int id, Mantenimiento updatedMantenimiento)
        {
            if(updatedMantenimiento.Id!= id)
            {
                return BadRequest("No se puede cambiar el valor del ID del mantenimiento");
            }
            var mantenimiento = await _appDbContext.Mantenimientos.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound("Advertencia: Mantenimiento no encontrado");
            }

            mantenimiento.Tipo = updatedMantenimiento.Tipo;


            await _appDbContext.SaveChangesAsync();

            return Ok(mantenimiento);
        }
        #endregion

    }
}
