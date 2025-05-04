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
            lstMovimientos = new ListBox();
            cmbTipo = new ComboBox();
            txtMonto = new TextBox();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lstMovimientos
            // 
            lstMovimientos.FormattingEnabled = true;
            lstMovimientos.ItemHeight = 25;
            lstMovimientos.Location = new Point(57, 68);
            lstMovimientos.Name = "lstMovimientos";
            lstMovimientos.Size = new Size(534, 129);
            lstMovimientos.TabIndex = 0;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Depósito", "Retiro", "Pago de préstamo" });
            cmbTipo.Location = new Point(57, 232);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(182, 33);
            cmbTipo.TabIndex = 1;
            cmbTipo.Text = "Seleccione";
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(325, 234);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Monto";
            txtMonto.Size = new Size(266, 31);
            txtMonto.TabIndex = 2;
            txtMonto.TextChanged += txtMonto_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(57, 295);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Descripcion";
            txtDescripcion.Size = new Size(534, 31);
            txtDescripcion.TabIndex = 3;
            txtDescripcion.TextChanged += txtDescripcion_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(57, 373);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 34);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(402, 373);
            button1.Name = "button1";
            button1.Size = new Size(189, 34);
            button1.TabIndex = 5;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MovimientosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnAgregar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtMonto);
            Controls.Add(cmbTipo);
            Controls.Add(lstMovimientos);
            Name = "MovimientosForm";
            Text = "Movimientos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMovimientos;
        private ComboBox cmbTipo;
        private TextBox txtMonto;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Button button1;
    }
}