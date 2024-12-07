using EntityFrameworkCore.MySQL.Data;
using EntityFrameworkCore.MySQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// controladores de API que se utiliza para interactuar con la base de datos
// cada controlador maneja operaciones CRUD  para una entidad especifica
// todos deben heredar de ControllerBase que es la base para los controladores




namespace EntityFrameworkCore.MySQL.Controllers
{
    [Route("api/[controller]")] // define una ruta base , lo que significa que las rutas comenzaran con "api/" seguido del nombre del controlador
    [ApiController] // atributo especifico para habilitra comportamientos de API
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // sigue el principio de inyeccion de  dependencias, donde el contexto de la base de dato se "inyecta" en el controlador a traves de su constructor 
        public ProductsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //dos endpoints
        // POST : Agregar un nuevo tecnico a la base de dato
        // GET: obtener todos los tecnicos de la base de datos
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();// guarda el producto en la base de datos

            return Ok(product);// return de que salio bien la operacion
        }

        [HttpGet]

        public async Task<IActionResult> GetAll(){
            var products=await _appDbContext.Products.ToListAsync();

            return Ok(products);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteProduct(int id){
            var product=await _appDbContext.Products.FindAsync(id);

            if (product == null){
                return NotFound("Advertencia: Producto no encontrado");
            }

            _appDbContext.Products.Remove(product);

            await _appDbContext.SaveChangesAsync();

            return Ok($"Producto con ID {id} ha sido borrado");
        }
    }
}
