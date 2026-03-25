using MySqlConnector;
using System;
using System.Data;

namespace Programables
{
    public class Datos2
    {
        // Reemplaza con tu cadena de conexión real
        string cadena = @"Data Source=TU_SERVIDOR;Initial Catalog=TU_BD;Integrated Security=True";

        public DataTable EjecutarConsulta(string query)
        {
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool ejecutar(string query)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cadena))
                {
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch { return false; }
        }

        public int EjecutarEscalar(string query)
        {
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}