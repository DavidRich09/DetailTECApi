using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        [HttpGet]
        [Route("getAllOffices")]

        public string GetOffices()
        {
            List<Sucursal> lista = context.Sucursals.ToList();
            string output = JsonConvert.SerializeObject(lista.ToArray(), Formatting.Indented);
            return output;
        }

        [HttpPost]
        [Route("saveOffice")]
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
