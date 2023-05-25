namespace TUP_PI_Recu_Viajes
{
    partial class frmViaje
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblTransporte = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.cboTransporte = new System.Windows.Forms.ComboBox();
            this.rbtNacional = new System.Windows.Forms.RadioButton();
            this.rbtInternacional = new System.Windows.Forms.RadioButton();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lstViajes = new System.Windows.Forms.ListBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(78, 36);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(75, 81);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(43, 13);
            this.lblDestino.TabIndex = 1;
            this.lblDestino.Text = "Destino";
            // 
            // lblTransporte
            // 
            this.lblTransporte.AutoSize = true;
            this.lblTransporte.Location = new System.Drawing.Point(60, 126);
            this.lblTransporte.Name = "lblTransporte";
            this.lblTransporte.Size = new System.Drawing.Size(58, 13);
            this.lblTransporte.TabIndex = 2;
            this.lblTransporte.Text = "Transporte";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(90, 171);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(81, 216);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(160, 35);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(57, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(160, 79);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(163, 20);
            this.txtDestino.TabIndex = 3;
            // 
            // cboTransporte
            // 
            this.cboTransporte.FormattingEnabled = true;
            this.cboTransporte.Location = new System.Drawing.Point(160, 123);
            this.cboTransporte.Name = "cboTransporte";
            this.cboTransporte.Size = new System.Drawing.Size(163, 21);
            this.cboTransporte.TabIndex = 1;
            // 
            // rbtNacional
            // 
            this.rbtNacional.AutoSize = true;
            this.rbtNacional.Location = new System.Drawing.Point(160, 169);
            this.rbtNacional.Name = "rbtNacional";
            this.rbtNacional.Size = new System.Drawing.Size(82, 17);
            this.rbtNacional.TabIndex = 4;
            this.rbtNacional.TabStop = true;
            this.rbtNacional.Text = "1 - Nacional";
            this.rbtNacional.UseVisualStyleBackColor = true;
            // 
            // rbtInternacional
            // 
            this.rbtInternacional.AutoSize = true;
            this.rbtInternacional.Location = new System.Drawing.Point(248, 169);
            this.rbtInternacional.Name = "rbtInternacional";
            this.rbtInternacional.Size = new System.Drawing.Size(101, 17);
            this.rbtInternacional.TabIndex = 5;
            this.rbtInternacional.TabStop = true;
            this.rbtInternacional.Text = "2 - Internacional";
            this.rbtInternacional.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(160, 210);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(97, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // lstViajes
            // 
            this.lstViajes.FormattingEnabled = true;
            this.lstViajes.Location = new System.Drawing.Point(370, 30);
            this.lstViajes.Name = "lstViajes";
            this.lstViajes.Size = new System.Drawing.Size(166, 199);
            this.lstViajes.TabIndex = 10;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(42, 262);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(248, 262);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(459, 262);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 312);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lstViajes);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.rbtInternacional);
            this.Controls.Add(this.rbtNacional);
            this.Controls.Add(this.cboTransporte);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblTransporte);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmViaje";
            this.Text = "Viajes";
            this.Load += new System.EventHandler(this.frmViaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblTransporte;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.ComboBox cboTransporte;
        private System.Windows.Forms.RadioButton rbtNacional;
        private System.Windows.Forms.RadioButton rbtInternacional;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ListBox lstViajes;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
    }
}

