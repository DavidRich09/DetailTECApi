using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P1API.Models;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

using System.IO;
using System.Net;
using System.Net.Mail;

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
        [Route("saveClientAdmin")]
        /**
         * Este metodo es para guardar un cliente desde el admin y enviar un correo
         */
        public ActionResult PostAdmin([FromBody] Cliente c)
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
                SendEmail(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /**
         * Envia un correo con la contraseña del cliente
         */
        protected void SendEmail(Cliente c)
        {
            string txtEmail = "mooncake1231231231231@gmail.com";

            using (MailMessage mm = new MailMessage(txtEmail, c.Correo))
            {
                mm.Subject = "Creación de nuevo cliente en TallerTEC";
                mm.Body = "Le damos la bienvenida a nuestro taller de reparación de vehículos. Su usuario es: " + c.Cedula + " y su contraseña es: " + c.CPassword;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                NetworkCredential NetworkCred = new NetworkCredential(txtEmail, "xsahonojzqxfziof");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(mm);
                
            }
        }
        
        
        [HttpPost]
        [Route("saveClienteTelList")]
        /**
         * Metodo para guardar los telefonos de un cliente
         */
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
                return new { data = "ok" };
                
            }
            catch (Exception ex)
            {
                return new { data = "error" };
            }
        }
        
        [HttpPost]
        [Route("saveClienteDirList")]
        
        /**
         * Metodo para guardar las dirreciones de un cliente
         */
        
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
        
        
        /**
         * Retorna un cliente por su cedula
         */

        [HttpGet]
        [Route("getClient/{usuario}")]
        public string GetClient(string usuario)
        {
            List<Cliente> listaTotal = context.Clientes.ToList();
            Cliente cliente = null;

            for (int i = 0; i < listaTotal.Count; i++)
            {
                if (listaTotal[i].Usuario == usuario)
                {
                    cliente = listaTotal[i];
                    break;
                }
            }

            if (cliente == null)
            {
                return null;
            } else
            {
                string output = JsonConvert.SerializeObject(cliente, Formatting.Indented);
                return output;
            }
        }

    }
}
