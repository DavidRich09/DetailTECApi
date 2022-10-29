using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1.CrystalReport;


namespace WindowsFormsApp1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }


        conexion conexiontest = new conexion();

        DataSet mostrar(string str)
        {
            /*conexiontest.conectar();
            string sql = "select c.nombre, c.puntos_redimidos from DetailTEC.lavacar.cliente as c order by c.puntos_redimidos desc;";
            SqlDataAdapter DA = new SqlDataAdapter(sql, conexiontest.conectar());
            DataSet dst = new DataSet();
            DA.Fill(dst, "DetailTEC");
            conexiontest.desconectar();
            return dst;*/

            //SqlConnection cnn = new SqlConnection("server=LAPTOP-U8CJQJON;database=DetailTEC;uid=siap;pwd=cccc;Pooling=true;Application Name=siapsep;Max Pool Size=200;Min Pool Size=0;Connection Lifetime=0;");
            conexiontest.conectar();
            SqlCommand cmd = new SqlCommand(str, conexiontest.conectar());
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet dst = new DataSet();
            DA.Fill(dst);
            conexiontest.desconectar();
            return dst;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnClientePts_Click(object sender, EventArgs e)
        {
            string str = "select TOP 15 c.nombre, c.puntos_redimidos from DetailTEC.lavacar.cliente as c order by c.puntos_redimidos desc;";
            DataSet dst = mostrar(str);
            if (dst.Tables[0].Rows.Count > 0)
            {
                CRClientesPuntos objImprimir = new CRClientesPuntos();
                objImprimir.SetDataSource(dst.Tables[0]);
                ClientesPuntos form = new ClientesPuntos();
                form.crystalReportViewer1.ReportSource = objImprimir;
                form.Show();
            }
        }


        private void BtnLavado_Click(object sender, EventArgs e)
        {
            string str = "select c.ced_cliente, c.tipo_lavado , count(c.tipo_lavado) as 'Cantidad' from DetailTEC.lavacar.cita as c where c.ced_cliente = @cliente group by c.tipo_lavado, c.ced_cliente order by count(c.tipo_lavado) desc;";
            conexiontest.conectar();
            SqlCommand cmd = new SqlCommand(str, conexiontest.conectar());
            cmd.Parameters.AddWithValue("@cliente", TBCliente.Text);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet dst = new DataSet();
            DA.Fill(dst);
            conexiontest.desconectar();

            if (dst.Tables[0].Rows.Count > 0)
            {
                CRLavadoClientes objImprimir = new CRLavadoClientes();
                objImprimir.SetDataSource(dst.Tables[0]);
                Lavado form = new Lavado();
                form.crystalReportViewer1.ReportSource = objImprimir;
                form.Show();
            }


        }

        private void Planilla_Click(object sender, EventArgs e)
        {
            string str = "select t.cedula, t.t_pago, t.nombre, t.apellidos, l.tipo_lavado, count(l.tipo_lavado) as 'Cantidad', sum(l.costo) as 'Costo', sum(l.precio) as 'Total' from lavacar.Trabajador as t join (lavacar.cita as c join lavacar.lavado as l on c.tipo_lavado = l.tipo_lavado) on t.cedula = c.ced_empleado where c.fecha >= GETDATE() - 8 group by l.tipo_lavado, t.nombre, t.apellidos, t.t_pago, t.cedula;";
            DataSet dst = mostrar(str);
            if (dst.Tables[0].Rows.Count > 0)
            {
                CRPlanilla objImprimir = new CRPlanilla();
                objImprimir.SetDataSource(dst.Tables[0]);
                Planilla form = new Planilla();
                form.crystalReportViewer1.ReportSource = objImprimir;
                form.Show();
            }

        }

        private void Factura_Click(object sender, EventArgs e)
        {
            DatosFact generar = new DatosFact();
            generar.Show();

        }
    }
}
