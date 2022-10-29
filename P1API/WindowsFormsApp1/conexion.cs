using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    public class conexion
    {

        SqlConnection conexionConnection;

        public SqlConnection conectar()
        {
            try
            {
                conexionConnection = new SqlConnection("Server=localhost\\SQLEXPRESS01;database=DetailTEC;Integrated Security=True;");
                conexionConnection.Open();
            }
            catch (Exception)
            {
                conexionConnection = null;
            }
            return conexionConnection;
        }

        public void desconectar()
        {
            try
            {
                if(conexionConnection.State == ConnectionState.Open) { conexionConnection.Close(); }
            }
            catch (Exception)
            {

            }
        }
    }
}
