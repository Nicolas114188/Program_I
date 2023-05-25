using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//CURSO – LEGAJO – APELLIDO – NOMBRE

namespace TUP_PI_Recu_Viajes
{
    public partial class frmViaje : Form
    {
        ConexionDB helper;
        public frmViaje()
        {
            InitializeComponent();
            helper = new ConexionDB();
        }

        private void frmViaje_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarLista();
        }

        private void CargarLista()
        {
            Viaje oViaje = new Viaje();
            lstViajes.Items.Clear();
            DataTable table = helper.ConsultaBD("SELECT * FROM Viajes");
            foreach (DataRow fila in table.Rows)
            {
                oViaje.pCodigo = Convert.ToInt32(fila["codigo"].ToString());
                oViaje.pDestino = fila["destino"].ToString();
                oViaje.pTransporte = Convert.ToInt32(fila["transporte"].ToString());
                oViaje.pTipo = Convert.ToInt32(fila["tipo"].ToString());
                oViaje.pFecha = Convert.ToDateTime(fila["fecha"].ToString());
                lstViajes.Items.Add(oViaje);
            }
        }

        private void CargarCombo()
        {
            DataTable table = helper.ConsultaBD("SELECT * FROM Transportes");
            cboTransporte.DataSource = table;
            cboTransporte.DisplayMember = "nombreTransporte";
            cboTransporte.ValueMember = "idTransporte";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = true;
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtDestino.Text = "";
            cboTransporte.SelectedIndex = -1;
            rbtInternacional.Checked = false;
            rbtNacional.Checked = false;
            dtpFecha.Value= DateTime.Today;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Preguntar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                Viaje oViaje = new Viaje();

            }
        }

        private bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
