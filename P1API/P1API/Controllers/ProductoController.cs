using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P1API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        
        private readonly DetailTECContext context;

        public ProductoController(DetailTECContext context)
        {
            this.context = context;

        }
        
        [HttpPost]
        [Route("saveProduct")]
        public ActionResult saveProduct([FromBody] Producto producto)
        {
            try
            {
                context.Add(producto);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        
        [HttpGet]
        [Route("GetNamesProducts")]
        public dynamic GetNamesProducts()
        {
            var products = context.Productos.Select(x => x.Nombre).ToList();
            return new
            {
                data = products
            };
        }
        
    }
}
