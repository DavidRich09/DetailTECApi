using Microsoft.AspNetCore.Mvc;
using P1API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LavadoProductoController : ControllerBase
    {
        
        private readonly DetailTECContext context;

        public LavadoProductoController(DetailTECContext context)
        {
            this.context = context;

        }
        
        
        [HttpPost]
        [Route("saveLavadoProducto")]
        public dynamic saveLavadoProducto([FromBody] LavadoProducto lavadoProducto)
        {
            try
            {
                context.Add(lavadoProducto);
                context.SaveChanges();
                return new { status = "ok" };
            }
            catch (Exception ex)
            {
                return new { status = "error", message = ex.Message };
            }
        }


    }
}
