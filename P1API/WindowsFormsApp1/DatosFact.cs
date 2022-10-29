using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CrystalReport;

namespace WindowsFormsApp1
{
    public partial class DatosFact : Form
    {
        public DatosFact()
        {
            InitializeComponent();
        }
        conexion conexiontest = new conexion();


        private void Generar_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine("Generar");
            Console.WriteLine(fecha.Text);
            if (Int32.TryParse(snacks.Text, out int mysnaks) && mysnaks>=0)
            {
                Console.WriteLine("Si se puede parsear");
                //Si el cliente desea pagar con puntos
                if (checkBox1.Checked)
                {
                    Console.WriteLine("pagar con puntos");
                    string tst = "select cl.puntos from (lavacar.cita as c join lavacar.cliente as cl on c.ced_cliente = cl.cedula) join lavacar.lavado as l on l.tipo_lavado = c.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha AND l.puntos_redimir<=cl.puntos;";
                    conexiontest.conectar();
                    SqlCommand cmdAux = new SqlCommand(tst, conexiontest.conectar());
                    cmdAux.Parameters.AddWithValue("@placa", placa.Text);
                    cmdAux.Parameters.AddWithValue("@fecha", fecha.Text);
                    SqlDataAdapter DAux = new SqlDataAdapter(cmdAux);
                    DataSet dstAux = new DataSet();
                    DAux.Fill(dstAux);


                    //Si el cliente posee los puntos necesarios para pagar
                    if (dstAux.Tables[0].Rows.Count > 0)
                    {
                        Console.WriteLine("puede pagar");
                        string puntos = "update lavacar.cliente set puntos = puntos - t1.puntos_redimir from (select cl.cedula, l.puntos_redimir from (lavacar.cita as c join lavacar.cliente as cl on c.ced_cliente = cl.cedula) join lavacar.lavado as l on l.tipo_lavado = c.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha AND l.puntos_redimir<=cl.puntos) as t1 where cliente.cedula = t1.cedula;";
                        string redimidos = "update lavacar.cliente set puntos_redimidos = puntos_redimidos + t1.puntos_redimir from (select cl.cedula, l.puntos_redimir from (lavacar.cita as c join lavacar.cliente as cl on c.ced_cliente = cl.cedula) join lavacar.lavado as l on l.tipo_lavado = c.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha AND l.puntos_redimir<=cl.puntos) as t1 where cliente.cedula = t1.cedula;";

                        SqlCommand SQLpuntos = new SqlCommand(puntos, conexiontest.conectar());
                        SQLpuntos.Parameters.AddWithValue("@placa", placa.Text);
                        SQLpuntos.Parameters.AddWithValue("@fecha", fecha.Text);
                        SqlDataAdapter prueba = new SqlDataAdapter(SQLpuntos);
                        DataSet prueba2 = new DataSet();
                        prueba.Fill(prueba2);

                        SqlCommand SQLredimidos = new SqlCommand(redimidos, conexiontest.conectar());
                        SQLredimidos.Parameters.AddWithValue("@placa", placa.Text);
                        SQLredimidos.Parameters.AddWithValue("@fecha", fecha.Text);
                        SqlDataAdapter prueba3 = new SqlDataAdapter(SQLredimidos);
                        DataSet prueba4 = new DataSet();
                        prueba3.Fill(prueba4);


                        factura();

                    }

                    //Si el cliente NO posee los puntos necesarios para pagar
                    else
                    {
                        Console.WriteLine("no puede pagar");

                        string puntos = "update lavacar.cliente set puntos = puntos + t1.puntos_otorga from (select cl.cedula, l.puntos_otorga from (lavacar.cita as c join lavacar.cliente as cl on c.ced_cliente = cl.cedula) join lavacar.lavado as l on l.tipo_lavado = c.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha AND l.puntos_redimir<=cl.puntos) as t1 where cliente.cedula = t1.cedula;";
                        SqlCommand SQLpuntos = new SqlCommand(puntos, conexiontest.conectar());
                        SQLpuntos.Parameters.AddWithValue("@placa", placa.Text);
                        SQLpuntos.Parameters.AddWithValue("@fecha", fecha.Text);
                        SqlDataAdapter prueba = new SqlDataAdapter(SQLpuntos);
                        DataSet prueba2 = new DataSet();
                        prueba.Fill(prueba2);

                        factura();
                    }

                    conexiontest.desconectar();

                }

                //Si el cliente NO desea pagar con puntos
                else
                {
                    Console.WriteLine("Pagar sin puntos");
                    conexiontest.conectar();
                    string puntos = "update lavacar.cliente set puntos = puntos + t1.puntos_otorga from (select cl.cedula, l.puntos_otorga from (lavacar.cita as c join lavacar.cliente as cl on c.ced_cliente = cl.cedula) join lavacar.lavado as l on l.tipo_lavado = c.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha AND l.puntos_redimir<=cl.puntos) as t1 where cliente.cedula = t1.cedula;";
                    SqlCommand SQLpuntos = new SqlCommand(puntos, conexiontest.conectar());
                    SQLpuntos.Parameters.AddWithValue("@placa", placa.Text);
                    SQLpuntos.Parameters.AddWithValue("@fecha", fecha.Text);
                    SqlDataAdapter prueba = new SqlDataAdapter(SQLpuntos);
                    DataSet prueba2 = new DataSet();
                    prueba.Fill(prueba2);
                    conexiontest.desconectar();
                    factura();

                }
            

            }
            this.Close();


        }

        //Factura 
        private void factura()
        {
            Console.WriteLine("Generar factura");
            int mysnaks = Int32.Parse(snacks.Text);

            string str;
            conexiontest.conectar();
            SqlCommand cmd;


            switch (mysnaks)
            {
                case 0:
                    Console.WriteLine("Caso 0");
                    str = "select c.placa_vehiculo as 'Placa', @fecha as 'Fecha', c.tipo_lavado as 'Servicio', l.precio as 'Precio',0 as 'Snacks',0.13 * l.precio as 'IVA' from lavacar.cita as c join lavacar.lavado as l on c.tipo_lavado = l.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha;";
                    cmd = new SqlCommand(str, conexiontest.conectar());
                    cmd.Parameters.AddWithValue("@placa", placa.Text);
                    cmd.Parameters.AddWithValue("@fecha", fecha.Text);
                    break;

                case 1:
                    Console.WriteLine("Caso 1");
                    str = "select c.placa_vehiculo as 'Placa', @fecha as 'Fecha', c.tipo_lavado as 'Servicio', l.precio as 'Precio',0 as 'Snacks',0.13 * l.precio as 'IVA' from lavacar.cita as c join lavacar.lavado as l on c.tipo_lavado = l.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha;";
                    cmd = new SqlCommand(str, conexiontest.conectar());
                    cmd.Parameters.AddWithValue("@placa", placa.Text);
                    cmd.Parameters.AddWithValue("@fecha", fecha.Text);
                    break;

                case 2:
                    Console.WriteLine("2");
                    str = "select c.placa_vehiculo as 'Placa', @fecha as 'Fecha', c.tipo_lavado as 'Servicio', l.precio as 'Precio',0 as 'Snacks',0.13 * l.precio as 'IVA' from lavacar.cita as c join lavacar.lavado as l on c.tipo_lavado = l.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha;";
                    cmd = new SqlCommand(str, conexiontest.conectar());
                    cmd.Parameters.AddWithValue("@placa", placa.Text);
                    cmd.Parameters.AddWithValue("@fecha", fecha.Text);

                    break;
                default:
                    Console.WriteLine("Default");
                    str = "select c.placa_vehiculo as 'Placa', @fecha as 'Fecha', c.tipo_lavado as 'Servicio', l.precio as 'Precio',@snack*1000 as 'Snacks',0.13 * l.precio as 'IVA' from lavacar.cita as c join lavacar.lavado as l on c.tipo_lavado = l.tipo_lavado where c.placa_vehiculo = @placa AND c.fecha = @fecha;";
                    cmd = new SqlCommand(str, conexiontest.conectar());
                    cmd.Parameters.AddWithValue("@placa", placa.Text);
                    cmd.Parameters.AddWithValue("@fecha", fecha.Text);
                    cmd.Parameters.AddWithValue("@snack", mysnaks);
                    break;

            }
            
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet dst = new DataSet();
            DA.Fill(dst);

            conexiontest.desconectar();

            if (dst.Tables[0].Rows.Count > 0)
            {
                CRFact objImprimir = new CRFact();
                objImprimir.SetDataSource(dst.Tables[0]);
                Fact form = new Fact();
                form.crystalReportViewer1.ReportSource = objImprimir;
                form.Show();
            }

        }

      
    }
}
