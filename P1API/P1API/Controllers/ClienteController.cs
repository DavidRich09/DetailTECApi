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

            if (c.CPassword == "")
            {
                //generar contraseña aleatoria
                string password = "";
                Random rnd = new Random();
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                for (int i = 0; i < 8; i++)
                {
                    password += chars[rnd.Next(chars.Length)];
                }
                c.CPassword = password;
            }

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
        
        
        [HttpPost]
        [Route("saveClienteTelList")]
        public dynamic Post([FromBody] List<TelClienteAux> listTelClient)
        {
            try
            {
                foreach (TelClienteAux tel in listTelClient)
                {
                    context.TelClientes.Add(new TelCliente
                    {
                        Telefono = tel.Telefono,
                        CedCliente = tel.CedCliente
                    });
                }
                
                context.SaveChanges();
                return new { error = "ok" };
                
            }
            catch (Exception ex)
            {
                return new { error = "error" };
            }
        }
        
        [HttpPost]
        [Route("saveClienteDirList")]
        public dynamic Post([FromBody] List<DirClienteAux> listDirClient)
        {
            try
            {
                foreach (DirClienteAux dir in listDirClient)
                {
                    context.DirClientes.Add(new DirCliente()
                    {
                        Direccion = dir.Direccion,
                        CedCliente = dir.CedCliente
                    });
                }
                
                context.SaveChanges();
                return new { data = "ok" };
                
            }
            catch (Exception ex)
            {
                return new { data = "error" };
            }
        }
        

    }
}
