using Microsoft.AspNetCore.Mvc;
using P1API.Extras;
using P1API.Models;

namespace P1API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ExcelController : Controller
    {

        private readonly DetailTECContext context;

        public ExcelController(DetailTECContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("importClients")]

        public dynamic ImportClients()
        {
            try
            {
                ImpExcel.GetInstance().SetContext(context);
                ImpExcel.GetInstance().Begin();
                return new
                {
                    message = "Success"
                };
            } catch (Exception ex)
            {
                return new
                {
                    message = "Error"
                };
            }
        }
    }
}
