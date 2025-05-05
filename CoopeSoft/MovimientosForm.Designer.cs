namespace CoopeSoft
{
    partial class MovimientosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvMovimientos = new ListBox();
            cmbTipo = new ComboBox();
            txtMonto = new TextBox();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.FormattingEnabled = true;
            dgvMovimientos.Location = new Point(46, 65);
            dgvMovimientos.Margin = new Padding(2);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(428, 104);
            dgvMovimientos.TabIndex = 0;
            dgvMovimientos.SelectedIndexChanged += lstMovimientos_SelectedIndexChanged;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Depósito", "Retiro", "Pago de préstamo" });
            cmbTipo.Location = new Point(46, 186);
            cmbTipo.Margin = new Padding(2);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(146, 28);
            cmbTipo.TabIndex = 1;
            cmbTipo.Text = "Seleccione";
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(260, 187);
            txtMonto.Margin = new Padding(2);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Monto";
            txtMonto.Size = new Size(214, 27);
            txtMonto.TabIndex = 2;
            txtMonto.TextChanged += txtMonto_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(46, 236);
            txtDescripcion.Margin = new Padding(2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Descripcion";
            txtDescripcion.Size = new Size(428, 27);
            txtDescripcion.TabIndex = 3;
            txtDescripcion.TextChanged += txtDescripcion_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(46, 298);
            btnAgregar.Margin = new Padding(2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(90, 27);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(322, 298);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(151, 27);
            button1.TabIndex = 5;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MovimientosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(button1);
            Controls.Add(btnAgregar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtMonto);
            Controls.Add(cmbTipo);
            Controls.Add(dgvMovimientos);
            Margin = new Padding(2);
            Name = "MovimientosForm";
            Text = "Movimientos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox dgvMovimientos;
        private ComboBox cmbTipo;
        private TextBox txtMonto;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Button button1;
    }
}