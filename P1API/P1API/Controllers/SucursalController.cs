using Microsoft.AspNetCore.Mvc;
using P1API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {

        private readonly DetailTECContext context;

        public SucursalController(DetailTECContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("saveOffice")]
        /**
         * Guarda una sucursal en la base de datos
         */
        public ActionResult Post([FromBody] Sucursal value)
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
        [Route("getNamesOffices")]
        /**
         * Obtiene los nombres de las sucursales
         */
        public dynamic GetNames()
        {
            
            var names = context.Sucursals.Select(x => x.Nombre).ToList();
            return new
            {
                data = names
            };

        }



    }

}
