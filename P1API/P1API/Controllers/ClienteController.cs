using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P1API.Models;

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly DetailTECContext context;
        public ClienteController(DetailTECContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("getAllClients")]

        public string GetClients()
        {
            List<Cliente> lista = context.Clientes.ToList();
            string output = JsonConvert.SerializeObject(lista.ToArray(), Formatting.Indented);
            return output;
        }

        [HttpPost]
        [Route("saveClient")]
        public ActionResult Post([FromBody] Cliente c)
        {
            try
            {
                context.Clientes.Add(c);
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
