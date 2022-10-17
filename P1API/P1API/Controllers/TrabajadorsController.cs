using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using P1API.Models;

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

        // GET: Trabajadors
        [HttpGet]
        public string GetTrabajadores()
        {
            List<Trabajador> lista = context.Trabajadors.ToList();
            string output = JsonConvert.SerializeObject(lista.ToArray(),Formatting.Indented);
            return output;
        }

        // GET: Trabajadors/Create
        [HttpPost]
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
