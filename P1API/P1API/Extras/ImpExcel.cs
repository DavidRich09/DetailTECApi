using IronXL;
using Microsoft.AspNetCore.Mvc;
using P1API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace P1API.Extras
{
    public class ImpExcel
    {

        private DetailTECContext context;
        static ImpExcel instance;

        private ImpExcel()
        {
            
        }

        public void SetContext(DetailTECContext context)
        {
            this.context = context;
        }

        public static ImpExcel GetInstance()
        {
            if (instance == null)
            {
                instance = new ImpExcel();
            }
            return instance;
        }

        public void Begin()
        {

            WorkBook workBook = new WorkBook(@"Extras\Clientes.xls");
            WorkSheet sheet = workBook.GetWorkSheet("Worksheet");
            var names = sheet.GetRange("A2:A352");
            var ids = sheet.GetRange("B2:B352");
            var phone1 = sheet.GetRange("E2:E352");
            var phone2 = sheet.GetRange("F2:F352");
            var email_user = sheet.GetRange("G2:G352");

            

            for (int i = 0; i < names.Count(); i++ )
            {

                Cliente temp = new Cliente();
                temp.Nombre = (string?)names.ElementAt(i).Value;
                temp.Cedula = FixInt((string?)ids.ElementAt(i).Value);
                temp.Correo = (string?)email_user.ElementAt(i).Value;
                temp.Usuario = (string?)email_user.ElementAt(i).Value;
                temp.CPassword = "";
                temp.Puntos = 0;
                temp.PuntosRedimidos = 0;

                TelCliente tel1 = new TelCliente();

                tel1.CedCliente = temp.Cedula;
                tel1.Telefono = FixInt((string?)phone1.ElementAt(i).Value);

                TelCliente tel2 = new TelCliente();

                tel2.CedCliente = temp.Cedula;
                tel2.Telefono = i;
                //tel2.Telefono = (int)(long)phone2.ElementAt(i).Value; //FixInt((string?)phone2.ElementAt(i).Value);

                try
                {
                    context.Clientes.Add(temp);
                    context.TelClientes.Add(tel1);
                    context.TelClientes.Add(tel2);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar cliente: " + (string?)names.ElementAt(i).Value);
                }

            }

        }

        public int FixInt(string? tofix)
        {
            tofix = tofix.Replace(" ","");
            tofix = tofix.Replace("-", "");
            Console.WriteLine(tofix);
            int fix = (int)Int64.Parse(tofix);
            return Math.Abs(fix);
        }

    }
}
