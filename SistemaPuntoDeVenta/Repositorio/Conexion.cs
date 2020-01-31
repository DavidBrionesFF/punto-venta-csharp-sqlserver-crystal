using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaPuntoDeVenta.Repositorio
{
    class Conexion
    {
        private SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
        private static Conexion instance = new Conexion();
        private Conexion()
        {
            conexion.Open();
        }

        public static Conexion getInstance()
        {
            return instance;
        }

        public bool ejecutarQuery(String query)
        {

            bool ret = false;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                ret = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        public SqlDataReader ejecutarQueryLeer(String query)
        {
            SqlDataReader dataReader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                dataReader = cmd.ExecuteReader();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return dataReader;
        }

    }
}
