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
        [Route("saveLavadoProductoList")]
        
        /**
         * Metodo que recibe una lista de lavadoProducto y los guarda en la base de datos
         */
        
        public dynamic saveLavadoProductoList([FromBody] List<LavadoProductoAux> lavadoProductos)
        {
            try
            {
                //recorrer la lista de lavadoProductos
                foreach (LavadoProductoAux lavadoProducto in lavadoProductos)
                {
                    context.LavadoProductos.Add(new LavadoProducto
                    {
                        Nombre = lavadoProducto.Nombre,
                        Marca = lavadoProducto.Marca,
                        TipoLavado = lavadoProducto.TipoLavado,
                        Cantidad = lavadoProducto.Cantidad
                    });
                }
                context.SaveChanges();
                return new {status = "ok"};
            } catch (Exception ex)
            {
                return new { status = "error" };
            }
            
        }
        
        
    }
    

}
