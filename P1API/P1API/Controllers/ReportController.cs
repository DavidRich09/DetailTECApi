using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using P1API.Models;

using System.Data;
using CrystalDecisions.CrystalReports.Engine;







namespace P1API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly DetailTECContext context;

        public ReportController(DetailTECContext context)
        {
            this.context = context;
        }



        [HttpGet]
        [Route("Asistente")]
        /**
         * abre el reporte de asistente
         */
        public dynamic Asistente()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"Execute\setup.exe");

            System.Diagnostics.Process.Start(path);


            return Ok();
        }



    }
}
