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
        /**
         * This method returns all the appointments in the database
         */
        public string GetAppointments()
        {
            List<Citum> lista = context.Cita.ToList();
            string output = JsonConvert.SerializeObject(lista.ToArray(), Formatting.Indented);
            return output;
        }

        [HttpPost]
        [Route("saveAppointment")]
        /*
         * Metodo para guardar una cita
         */
        public ActionResult Post([FromBody] Citum citum)
        {
            try
            {
                //hacer un select de la Cedula de los trabajadores y escoger uno al azar
                
                var trabajador = context.Trabajadors.Select(x => x.Cedula).ToList();
                Random rnd = new Random();
                int index = rnd.Next(trabajador.Count);
                
                citum.CedEmpleado = trabajador[index];
                
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
