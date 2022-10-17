using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using P1API.Models;

//Crear un controlador para cada tabla, no para operaciones especificas.

namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrabajadorsController : Controller
    {

        private readonly DetailTECContext context;

        public TrabajadorsController(DetailTECContext context)
        {
            this.context = context;
        }

        
        [HttpGet]
        [Route("getAllWorkers")]
        public string GetTrabajadores()
        {
            List<Trabajador> lista = context.Trabajadors.ToList();
            string output = JsonConvert.SerializeObject(lista.ToArray(),Formatting.Indented);
            return output;
        }

        [HttpPost]
        [Route("saveWorker")]
        public ActionResult Post([FromBody] Trabajador value)
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
    }
}
