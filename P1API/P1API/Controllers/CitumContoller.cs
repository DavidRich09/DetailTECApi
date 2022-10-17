using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P1API.Models;

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CitumContoller : Controller
    {
        private readonly DetailTECContext context;

        public CitumContoller(DetailTECContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("getAllAppointments")]
        public string GetAppointments()
        {
            List<Citum> lista = context.Cita.ToList();
            string output = JsonConvert.SerializeObject(lista.ToArray(), Formatting.Indented);
            return output;
        }

        [HttpPost]
        [Route("saveAppointment")]
        public ActionResult Post([FromBody] Citum citum)
        {
            try
            {
                context.Cita.Add(citum);
                context.SaveChanges();
                return Ok();
            } 
            catch ( Exception exc)
            {
                return BadRequest(exc.Message);
            }

        }
    }
}
