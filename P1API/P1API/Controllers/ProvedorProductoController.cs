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
        public dynamic saveProduct()
        {

            try
            {
                context.ProveedorProductos.Add(new ProveedorProducto
                {
                    
                    Nombre = "vv",
                    Marca =  "vv",
                    CedProveedor = 12312312

                });
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("saveProvedorProductoList")]
        public dynamic saveProductList([FromBody] List<ProveedorProductoAux> provedorProucto)
        {
            try
            {
                foreach (ProveedorProductoAux productoAux in provedorProucto)
                {
                    context.ProveedorProductos.Add(new ProveedorProducto
                    {
                        Nombre = productoAux.Nombre,
                        Marca = productoAux.Marca,
                        CedProveedor = productoAux.CedProveedor
                    });
                    
                }
                context.SaveChanges();
                return new { status = "ok" };
            }
            catch (Exception ex)
            {
                return new { status = "error" };
            }
        }
        
    }

        
        
    
}
