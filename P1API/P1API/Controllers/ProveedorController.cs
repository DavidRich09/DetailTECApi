using Microsoft.AspNetCore.Mvc;
using P1API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly DetailTECContext context;

        public ProveedorController(DetailTECContext context)
        {
            this.context = context;
        }


        [HttpPost]
        [Route("saveSupplier")]
        public ActionResult Post([FromBody] Proveedor value)
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
        
        [HttpGet]
        [Route("getSupplerisNames")]
        public dynamic GetNames()
        {
            //hacer un select del nombre de la sucursal
            var sucursales = context.Proveedors.Select(x =>  x.Nombre ).ToList();
            return new
            {
                data = sucursales
            };
        }
        
        
                
        [HttpGet]
        [Route("getSupplerisId")]
        public dynamic GetIds()
        {
            //hacer un select del nombre de la sucursal
            var sucursales = context.Proveedors.Select(x =>  x.CedJuridica ).ToList();
            return new
            {
                data = sucursales
            };
        }

        
        

    }
}
