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

//CURSO – LEGAJO – APELLIDO – NOMBRE
//1W3 - 114188- Herrera - Nicólas
//Cadena de Conexión: "Data Source=138.99.7.66,1433;Initial Catalog=Consultorio;User ID=tup1_consultorio;Password=5@tUp1"

namespace TUP_PI_EF_PacientesU
{
    public partial class frmPacientes : Form
    {
        private ConexionDB helper;
       
        public frmPacientes()
        {
            InitializeComponent();
            helper = new ConexionDB();  

        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            CargrarCombo();
            ListarCombo();
        }


        private void ListarCombo()
        {
            DataTable table = helper.ConsultaDB("SELECT * FROM Pacientes");
            lstPacientes.Items.Clear();
            foreach(DataRow fila in table.Rows)
            {
                Paciente oPaciente = new Paciente();
                oPaciente.NumeroHC = Convert.ToInt32(fila["numeroHC"].ToString());
                oPaciente.Nombre = fila["nombre"].ToString();
                oPaciente.ObraSocial = Convert.ToInt32(fila["obraSocial"].ToString());
                oPaciente.Sexo = Convert.ToInt32(fila["sexo"].ToString());
                oPaciente.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"].ToString());
                lstPacientes.Items.Add(oPaciente);
            }
        }

        private void CargrarCombo()
        {
            DataTable table = helper.ConsultaDB("SELECT * FROM ObrasSociales");
            cboObraSocial.DataSource = table;
            cboObraSocial.DisplayMember = "nombreObraSocial";
            cboObraSocial.ValueMember = "idObraSocial";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void lstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstPacientes.SelectedIndex !=-1)
            {
                Paciente oPaciente = (Paciente)lstPacientes.SelectedItem;
                txtNroHC.Text = oPaciente.NumeroHC.ToString();
                txtNombre.Text = oPaciente.Nombre.ToString();
                chkObraSocial.Checked = true;    
                cboObraSocial.SelectedValue = oPaciente.ObraSocial.ToString();
                if (oPaciente.Sexo == 1)
                    rbtFemenino.Checked = true;
                else
                    rbtMasculino.Checked = true;
                dtpFechaNacimiento.Value=oPaciente.FechaNacimiento;


            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                Paciente oPaciente = new Paciente();
                oPaciente.NumeroHC =Convert.ToInt32 (txtNroHC.Text);
                oPaciente.Nombre = txtNombre.Text;
                if (chkObraSocial.Checked)
                    oPaciente.ObraSocial = Convert.ToInt32(cboObraSocial.SelectedValue);
                if (rbtFemenino.Checked)
                    oPaciente.Sexo = 1;
                else
                    oPaciente.Sexo = 2;
                oPaciente.FechaNacimiento = dtpFechaNacimiento.Value;

                string query = "UPDATE Pacientes SET  nombre=@nombre, obraSocial=@obraSocial, sexo=@sexo, fechaNacimiento=@fechaNacimiento WHERE numeroHC=@numeroHC";
                int fila = helper.ActualizarDB(query,oPaciente);
                if(fila>0)
                {
                    MessageBox.Show("Se actualizó correctamente los datos","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    ListarCombo();
                }
                else
                    MessageBox.Show("Error al actualizar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error de Validar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool Validar()
        {
            bool val=true;
            if (String.IsNullOrEmpty(txtNombre.Text))
                val = false;
            if (dtpFechaNacimiento.Value<DateTime.Now.AddYears(-21))
            {
                val = false;
            }

            return val;
        }
    }
}
