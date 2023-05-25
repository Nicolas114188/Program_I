using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WinPersona
{
    class ConexionDB
    {
        private SqlConnection cnn;
        private string conexionString;
        public ConexionDB()
        {
            conexionString = @"Data Source=PATO\NICOSQLSERVER;Initial Catalog=TUPPI;Integrated Security=True";
            cnn = new SqlConnection(conexionString);
        }

        public DataTable ConsultaBD(string v)
        {
            DataTable table= new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(v,cnn);
            table.Load(cmd.ExecuteReader());
            cnn.Close();
            return table;
        }

        internal int ActualizarBD(string query, Persona oPersona)
        {
            int fila = 0;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@apellido",oPersona.Apellido);
            cmd.Parameters.AddWithValue("@nombres",oPersona.Nombre);
            cmd.Parameters.AddWithValue("@tipo_documento",oPersona.TipoDocumento);
            cmd.Parameters.AddWithValue("@documento",oPersona.Documento);
            cmd.Parameters.AddWithValue("@estado_civil", oPersona.EstadoCivil);
            cmd.Parameters.AddWithValue("@sexo", oPersona.Sexo);
            cmd.Parameters.AddWithValue("@fallecio", oPersona.Fallecido);
            fila = cmd.ExecuteNonQuery();
            cnn.Close();
            return fila;
        }
    }
}
