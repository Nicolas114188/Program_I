using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPersona
{
    public partial class Form1 : Form
    {
        private ConexionDB helper;
        Accion accion;
        private List<Persona> lst;

        public Form1()
        {
            InitializeComponent();
            helper = new ConexionDB();
            lst = new List<Persona>();
            accion = Accion.Nuevo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Persona oPersona = new Persona();
                oPersona.Apellido = txtApellido.Text;
                oPersona.Nombre = txtNombre.Text;
                oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue.ToString());
                oPersona.Documento = txtDocumento.Text;
                oPersona.EstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue.ToString());
                if (rbFemenino.Checked)
                    oPersona.Sexo = 1;
                else
                    oPersona.Sexo = 2;
                oPersona.Fallecido = Convert.ToBoolean(chFallecido.Checked);
                string query = string.Empty;
                if (accion == Accion.Nuevo)
                {
                    query = "INSERT INTO personas(apellido,nombres,tipo_documento,documento,estado_civil,sexo,fallecio)" +
                        "VALUES(@apellido,@nombres,@tipo_documento,@documento,@estado_civil,@sexo,@fallecio)";
                }
                if (accion == Accion.Editar)
                {
                    query = "UPDATE personas SET apellido= @apellido, nombres= @nombres, tipo_documento= @tipo_documento, estado_civil= @estado_civil, sexo=@sexo, fallecio=@fallecio" +
                        "WHERE documento= @documento";
                }
                int fila = helper.ActualizarBD(query, oPersona);
                if (fila > 0)
                {
                    MessageBox.Show("Se Actualizo los datos correctamente!", "Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Habilitar(true);
                    CargarLista();
                    Limpiar();
                }
                else
                    MessageBox.Show("No se actualizo los datos!", "Infromacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error en cargar los datos!","Infromacion",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private bool Validar()
        {
            bool val = true;
            if (String.IsNullOrEmpty(txtApellido.Text)||String.IsNullOrEmpty(txtNombre.Text)||String.IsNullOrEmpty(txtDocumento.Text))
            {
                val = false;
            }
            if (cboEstadoCivil.SelectedIndex == -1)
                val = false;
            if (cboTipoDocumento.SelectedIndex == -1)
                val = false;
            if (Existe(txtDocumento.Text))
                val = false;

            return val;
        }

        private bool Existe(string text)
        {
            bool result = false;
            foreach (Persona x in lst)
            {
                if (x.Documento == text)
                    result = true;
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;// Lista de selección
            cboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarCombo();
            CargarLista();
            Habilitar(false);
        }

        private void Habilitar(bool v)
        {
            txtApellido.Enabled = v;
            txtNombre.Enabled = v;
            cboTipoDocumento.Enabled = v;
            txtDocumento.Enabled = v;
            cboEstadoCivil.Enabled = v;
            rbFemenino.Enabled = v;
            rbMasculino.Enabled = v;
            chFallecido.Enabled = v;
            btnNuevo.Enabled = !v;
            btnEditar.Enabled = !v;
            btnBorrar.Enabled = !v;
            btnGuardar.Enabled = v;
            btnCancelar.Enabled = v;
            btnSalir.Enabled = !v;
        }

        private void CargarLista()
        {
            Persona oPersona = new Persona();
            DataTable table = helper.ConsultaBD("SELECT * FROM personas");
            listPersona.Items.Clear();
            lst.Clear();
            foreach(DataRow fila in table.Rows)
            {
                oPersona.Apellido = fila["apellido"].ToString();
                oPersona.Nombre = fila["nombres"].ToString();
                oPersona.TipoDocumento = Convert.ToInt32(fila["tipo_documento"].ToString());
                oPersona.Documento = fila["documento"].ToString();
                oPersona.EstadoCivil = Convert.ToInt32(fila["estado_civil"].ToString());
                oPersona.Sexo = Convert.ToInt32(fila["sexo"].ToString());
                oPersona.Fallecido = Convert.ToBoolean(fila["fallecio"].ToString());
                listPersona.Items.Add(oPersona);
                lst.Add(oPersona);
            }
        }

        private void CargarCombo()
        {
            DataTable tableTd= helper.ConsultaBD("SELECT * FROM tipo_documento");
            cboTipoDocumento.DataSource = tableTd;
            cboTipoDocumento.DisplayMember = "n_tipo_documento";
            cboTipoDocumento.ValueMember = "id_tipo_documento";

            DataTable tableEC = helper.ConsultaBD("SELECT * FROM estado_civil");
            cboEstadoCivil.DataSource = tableEC;
            cboEstadoCivil.DisplayMember = "n_estado_civil";
            cboEstadoCivil.ValueMember = "id_estado_civil";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            listPersona.Enabled = false;
            Habilitar(true);
            accion = Accion.Nuevo;
        }

        private void Limpiar()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            cboTipoDocumento.SelectedIndex = -1;
            txtDocumento.Text = "";
            cboEstadoCivil.SelectedIndex = -1;
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
            chFallecido.Checked = false;
        }

        private void listPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
           // listPersona.Enabled = true;
            accion = Accion.Editar;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            accion = Accion.Borrar;
            listPersona.Enabled = true;
            btnGuardar.Enabled = false;
            string query = string.Empty;
            if (Validar())
            {
                if (MessageBox.Show("Desea Eliminar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Persona oPersona = new Persona();
                    oPersona.Apellido = txtApellido.Text;
                    oPersona.Nombre = txtNombre.Text;
                    oPersona.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue.ToString());
                    oPersona.Documento = txtDocumento.Text;
                    oPersona.EstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue.ToString());
                    if (rbFemenino.Checked)
                        oPersona.Sexo = 1;
                    else
                        oPersona.Sexo = 2;
                    oPersona.Fallecido = Convert.ToBoolean(chFallecido.Checked);

                    query = "DELETE Personas Where documento=@documento";
                    int fila = helper.ActualizarBD(query, oPersona);
                    if (fila > 0)
                    {
                        MessageBox.Show("Se a borrado con exito registro!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Habilitar(true);
                        CargarLista();
                        Limpiar();
                    }
                    else
                        MessageBox.Show("No se borró registro!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Error del registro!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
            Limpiar();
        }

        private void listPersona_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listPersona.SelectedIndex != -1)
            {
                Persona oPersona = (Persona)listPersona.SelectedItem;
                txtDocumento.Text = oPersona.Documento;
                txtApellido.Text = oPersona.Apellido;
                txtNombre.Text = oPersona.Nombre;
                cboTipoDocumento.SelectedValue = oPersona.TipoDocumento;
                cboEstadoCivil.SelectedValue = oPersona.EstadoCivil;
                if (oPersona.Sexo == 1)
                    rbFemenino.Checked = true;
                if (oPersona.Sexo == 2)
                    rbMasculino.Checked = true;
                if (oPersona.Fallecido == true)
                    chFallecido.Checked = true;
            }
        }
    }

    enum Accion
    {
        Nuevo,
        Editar,
        Borrar,
    }
}
