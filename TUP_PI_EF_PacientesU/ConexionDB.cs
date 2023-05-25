using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_EF_PacientesU
{
    class ConexionDB
    {
        private string conexionString;
        private SqlConnection cnn;
        public ConexionDB()
        {
            conexionString = @"Data Source=PATO\NICOSQLSERVER;Initial Catalog=Clinica_PI;Integrated Security=True";
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

        public int ActualizarDB(string query, Paciente oPaciente)
        {
            int fila = 0;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@numeroHC",oPaciente.NumeroHC);
            cmd.Parameters.AddWithValue("@nombre", oPaciente.Nombre);
            cmd.Parameters.AddWithValue("@obraSocial", oPaciente.ObraSocial);
            cmd.Parameters.AddWithValue("@sexo", oPaciente.Sexo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", oPaciente.FechaNacimiento);
            fila = cmd.ExecuteNonQuery();
            cnn.Close();
            return fila;
        }
    }
}
