using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_Recu_Viajes
{
    class ConexionDB
    {
        private string conexionString;
        private SqlConnection cnn;
        public ConexionDB()
        {
            conexionString = @"Data Source=PATO\NICOSQLSERVER;Initial Catalog=AgenciaViaje;Integrated Security=True";
            cnn = new SqlConnection(conexionString);
        }

        internal DataTable ConsultaBD(string v)
        {
            DataTable table = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(v,cnn);
            table.Load(cmd.ExecuteReader());
            cnn.Close();
            return table;

        }
    }
}
