using Microsoft.AspNetCore.Mvc;
using P1API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProvedorProductoController : ControllerBase
    {

        private readonly DetailTECContext context;

        public ProvedorProductoController(DetailTECContext context)
        {
            this.context = context;

        }
        
        [HttpPost]
        [Route("saveProvedorProducto")]
        public ActionResult saveProduct([FromBody] ProveedorProducto value)
        {

            try
            {
                context.Add(value);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
