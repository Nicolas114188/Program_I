using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUP_PI_Parcial2_1w3A;

namespace TUP_PI_Parcial2_13A
{
    class ConextionDB
    {
       public string conextionstring;
       public SqlConnection cnn;
       public SqlCommand cmd;
       public ConextionDB()
        {
            conextionstring = @"DataSource = 138.99.7.66, 1433; Initial Catalog = TUPI_Vivero; UserID = tup1_vivero; Password = @tup1_Vive";
            cnn = new SqlConnection(conextionstring);
            cmd = new SqlCommand();
        }

        public DataTable ConsultaSql(string v)
        {
            DataTable table = new DataTable();
            cnn.Open();
            cmd = new SqlCommand(v,cnn);
            table.Rows.Add(cnn);
            cnn.Close();
            return table;
        }

 
    }
}
