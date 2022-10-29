using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P1API.Models;

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WashController : Controller
    {
        private readonly DetailTECContext context;

        public WashController(DetailTECContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("getAllWashes")]

        public string GetWashes()
        {
            List<Lavado> lista = context.Lavados.ToList();
            string output = JsonConvert.SerializeObject(lista.ToArray(), Formatting.Indented);
            return output;
        }

        [HttpPost]
        [Route("getAllWashT")]

        public string WashTypes()
        {
            List<Lavado> lista = context.Lavados.ToList();
            string output = JsonConvert.SerializeObject(lista.ToArray(), Formatting.Indented);
            return output;
        }

        [HttpPost]
        [Route("saveWash")]
        /**
         * Guarda un lavado
         */
        public ActionResult SaveWash([FromBody] Lavado lavado)
        {
            try
            {
                context.Add(lavado);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }
        
        [HttpGet]
        [Route("getNamesWash")]
        /**
         * Retorna los nombres de los lavados
         */
        public dynamic getNamesWash()
        {
            var names = context.Lavados.Select(x => x.TipoLavado).ToList();
            return new
            {
                data = names
            };
        }
        
    }
}
