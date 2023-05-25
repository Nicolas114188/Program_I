using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_Recuperatorio_1W3
{
    class ConexionDB
    {
        private string conexionString;
        private SqlConnection cnn;
        public ConexionDB()
        {
            conexionString = @"Data Source=138.99.7.66,1433;Initial Catalog=Familia;User ID=tup1_familia;Password=5@Tup1";
            cnn = new SqlConnection(conexionString);
        }

        public DataTable ConsultaDB(string v)
        {
            DataTable table = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(v,cnn);
            table.Load(cmd.ExecuteReader());
            cnn.Close();
            return table;
        }

        internal int ActualizacionBD(string query, Gasto oGasto)
        {
            int fila = 0;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@dia",oGasto.Dia);
            cmd.Parameters.AddWithValue("@categoria",oGasto.Categoria);
            cmd.Parameters.AddWithValue("@medioPago", oGasto.MedioPago);
            cmd.Parameters.AddWithValue("@importe",oGasto.Importe);
            fila = cmd.ExecuteNonQuery();
            cnn.Close();
            return fila;
        }
    }
}
