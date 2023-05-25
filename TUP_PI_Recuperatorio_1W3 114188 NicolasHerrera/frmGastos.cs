using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//CURSO: – LEGAJO: – APELLIDO: – NOMBRE:

//Cadena de Conexión: "Data Source=138.99.7.66,1433;Initial Catalog=Familia;User ID=tup1_familia;Password=5@Tup1"

namespace TUP_PI_Recuperatorio_1W3
{
    public partial class frmGastos : Form
    {
        ConexionDB helper;
        public frmGastos()
        {
            InitializeComponent();
            helper = new ConexionDB();
        }

        private void frmPlantas_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarLista();
            Habilitar(false);
        }

        private void Habilitar(bool v)
        {
            txtDia.Enabled = v;
            txtImporte.Enabled = v;
        }

        private void CargarLista()
        {
            Gasto oGasto = new Gasto();
            lstGastos.Items.Clear();
            DataTable table = helper.ConsultaDB("SELECT * FROM Gastos");
            foreach(DataRow fila in table.Rows)
            {
                oGasto.Codigo = Convert.ToInt32(fila["codigo"].ToString());
                oGasto.Dia = Convert.ToInt32(fila["dia"].ToString());
                oGasto.Categoria = Convert.ToInt32(fila["categoria"].ToString());
                oGasto.MedioPago = Convert.ToInt32(fila["medioPago"].ToString());
                oGasto.Importe = Convert.ToDouble(fila["importe"].ToString());
                lstGastos.Items.Add(oGasto);
            }
        }

        private void CargarCombo()
        {
            DataTable table = helper.ConsultaDB("SELECT * FROM Categorias");
            cboCategoria.DataSource = table;
            cboCategoria.DisplayMember = "nombreCategoria";
            cboCategoria.ValueMember = "idCategoria";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            btnGuardar.Enabled = true;
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtDia.Text = "";
            cboCategoria.SelectedIndex = -1;
            cboMedioPago.SelectedIndex = -1;
            txtImporte.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Gasto oGasto = new Gasto();
                oGasto.Dia = Convert.ToInt32(txtDia.Text);
                oGasto.Categoria = Convert.ToInt32(cboCategoria.SelectedIndex.ToString());
                //oGasto.MedioPago = Convert.ToInt32(cboMedioPago.SelectedIndex.ToString());
                
                string mp = (string)(cboMedioPago.SelectedItem);
                if (mp.Equals("Efectivo"))
                    oGasto.MedioPago=1;
                if (mp.Equals("Tarjeta"))
                    oGasto.MedioPago= 2;
                if (mp.Equals(" Transferencia"))
                    oGasto.MedioPago= 3;
                oGasto.Importe = Convert.ToDouble(txtImporte.Text);
                string query = "INSERT INTO Gastos(dia,categoria, medioPago,importe) " +
                                    "VALUES(@dia,@categoria,@medioPago,@importe)";
                int fila = helper.ActualizacionBD(query, oGasto);
                if (fila > 0)
                { 
                    MessageBox.Show("Sea Cargado los datos correctamente!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Habilitar(false);
                    CargarLista();
                    Limpiar();
                }
                else
                    MessageBox.Show("No se Cargado los datos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Error en los datos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Validar()
        {
            bool val=true;
            if (String.IsNullOrEmpty(txtDia.Text) || String.IsNullOrEmpty(txtImporte.Text))
                val = false;
            if (cboCategoria.SelectedIndex == -1)
                val = false;
            if (cboMedioPago.SelectedIndex == -1)
                val = false;
            return val;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir!","Informacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                this.Close();
        }
    }
}
