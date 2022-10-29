using Microsoft.AspNetCore.Mvc;
using P1API.Models;
using Newtonsoft.Json;

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientPhonesController : Controller
    {
        private readonly DetailTECContext context;

        public ClientPhonesController(DetailTECContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("getClientPhones/{ced}")]
        /**
         * Retorna los telefonos de un cliente
         */
        public string GetPhones(string ced)
        {
            List<Cliente> listaTotal = context.Clientes.ToList();
            List<Cliente> listaF = new List<Cliente>();
            int cedula = Int16.Parse(ced);

            for (int i = 0; i < listaTotal.Count; i++)
            {
                if (listaTotal[i].Cedula == cedula)
                {
                    listaF.Add(listaTotal[i]);
                }
            }
            if (listaF.Count > 0)
            {
                string output = JsonConvert.SerializeObject(listaF.ToArray(), Formatting.Indented);
                return output;
            } else
            {
                return "";
            }
        }

        [HttpPost]
        [Route("saveClientPhone")]
        
        public ActionResult SavePhone([FromBody] TelCliente tel)
        {
            try
            {
                context.Add(tel);
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
