using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUP_PI_Parcial2_13A;

//CURSO: 1w3 – LEGAJO: 114188 – APELLIDO: Herrera – NOMBRE: Nicolàs
//Cadena de Conexión: "Data Source=138.99.7.66,1433;Initial Catalog=TUPI_Vivero;User ID=tup1_vivero;Password=@tup1_Vive"

namespace TUP_PI_Parcial2_1w3A
{
    public partial class frmPlantas : Form
    {
        ConextionDB helper;
        List<Planta> list;
        public frmPlantas()
        {
            InitializeComponent();
            helper = new ConextionDB();
            list = new List<Planta>();
            CargarCombo();
            CargarLista();
            Habilitar(true);
        }

        private void Habilitar(bool v)
        {
            
        }

        private void CargarLista()
        {
            foreach ()
            {
                Planta oPlanta = new Planta();
                oPlanta.pCodigo = Convert.ToInt32(txtCodigo.Text);
                oPlanta.pNombre = txtNombre.Text;
                oPlanta.pEspecie = Convert.ToInt32(cboEspecie.SelectedIndex);
                oPlanta.pPrecio = Convert.ToInt32(txtPrecio.Text);
                oPlanta.pFecha = Convert.ToDateTime(dtpFecha);
                list.Add(oPlanta);
                lstPlantas.Items.Add(oPlanta);
            }

        }

        private void CargarCombo()
        {
            DataTable data = helper.ConsultaSql("SELECT * FROM Especies");
            cboEspecie.SelectedValue = "nombreEspecie";
            cboEspecie.ValueMember = "idEspecie";
        }

        private void frmPlantas_Load(object sender, EventArgs e)
        {
      
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir del Programa!", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }
    }
}
