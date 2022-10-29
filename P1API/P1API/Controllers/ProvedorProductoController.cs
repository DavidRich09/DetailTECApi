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
        [Route("saveProvedorProductoList")]
        
        /**
         * Metodo que permite guardar una lista de productos de un proveedor
         */
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
