namespace CoopeSoft
{
    partial class SolicitarPrestamoForm
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
            numMonto = new NumericUpDown();
            txtMotivo = new TextBox();
            btnSolicitar = new Button();
            button1 = new Button();
            cmbTipoPrestamo = new ComboBox();
            numPlazo = new NumericUpDown();
            lblTasaInteres = new Label();
            lblCuotaEstimada = new Label();
            lblTotalPagar = new Label();
            dtpFechaSolicitud = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlazo).BeginInit();
            SuspendLayout();
            // 
            // numMonto
            // 
            numMonto.Location = new Point(35, 80);
            numMonto.Margin = new Padding(2);
            numMonto.Name = "numMonto";
            numMonto.Size = new Size(189, 27);
            numMonto.TabIndex = 0;
            numMonto.ValueChanged += numMonto_ValueChanged;
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(35, 207);
            txtMotivo.Margin = new Padding(2);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.PlaceholderText = "Motivo";
            txtMotivo.Size = new Size(597, 27);
            txtMotivo.TabIndex = 1;
            txtMotivo.TextChanged += txtMotivo_TextChanged;
            // 
            // btnSolicitar
            // 
            btnSolicitar.Location = new Point(49, 298);
            btnSolicitar.Margin = new Padding(2);
            btnSolicitar.Name = "btnSolicitar";
            btnSolicitar.Size = new Size(90, 27);
            btnSolicitar.TabIndex = 2;
            btnSolicitar.Text = "Solicitar";
            btnSolicitar.UseVisualStyleBackColor = true;
            btnSolicitar.Click += btnSolicitar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(480, 298);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(90, 27);
            button1.TabIndex = 3;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cmbTipoPrestamo
            // 
            cmbTipoPrestamo.FormattingEnabled = true;
            cmbTipoPrestamo.Items.AddRange(new object[] { "Nombre", "TipoPrestamoID" });
            cmbTipoPrestamo.Location = new Point(35, 29);
            cmbTipoPrestamo.Name = "cmbTipoPrestamo";
            cmbTipoPrestamo.Size = new Size(189, 28);
            cmbTipoPrestamo.TabIndex = 4;
            cmbTipoPrestamo.SelectedIndexChanged += cmbTipoPrestamo_SelectedIndexChanged;
            // 
            // numPlazo
            // 
            numPlazo.Location = new Point(35, 143);
            numPlazo.Name = "numPlazo";
            numPlazo.Size = new Size(195, 27);
            numPlazo.TabIndex = 5;
            numPlazo.ValueChanged += numPlazo_ValueChanged;
            // 
            // lblTasaInteres
            // 
            lblTasaInteres.AutoSize = true;
            lblTasaInteres.Location = new Point(447, 32);
            lblTasaInteres.Name = "lblTasaInteres";
            lblTasaInteres.Size = new Size(50, 20);
            lblTasaInteres.TabIndex = 6;
            lblTasaInteres.Text = "label1";
            lblTasaInteres.Click += lblTasaInteres_Click;
            // 
            // lblCuotaEstimada
            // 
            lblCuotaEstimada.AutoSize = true;
            lblCuotaEstimada.Location = new Point(447, 80);
            lblCuotaEstimada.Name = "lblCuotaEstimada";
            lblCuotaEstimada.Size = new Size(50, 20);
            lblCuotaEstimada.TabIndex = 7;
            lblCuotaEstimada.Text = "label2";
            lblCuotaEstimada.Click += lblCuotaEstimada_Click;
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Location = new Point(447, 120);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(50, 20);
            lblTotalPagar.TabIndex = 8;
            lblTotalPagar.Text = "label3";
            lblTotalPagar.Click += lblTotalPagar_Click;
            // 
            // dtpFechaSolicitud
            // 
            dtpFechaSolicitud.Location = new Point(587, 32);
            dtpFechaSolicitud.Name = "dtpFechaSolicitud";
            dtpFechaSolicitud.Size = new Size(299, 27);
            dtpFechaSolicitud.TabIndex = 9;
            dtpFechaSolicitud.ValueChanged += dtpFechaSolicitud_ValueChanged;
            // 
            // SolicitarPrestamoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 450);
            Controls.Add(dtpFechaSolicitud);
            Controls.Add(lblTotalPagar);
            Controls.Add(lblCuotaEstimada);
            Controls.Add(lblTasaInteres);
            Controls.Add(numPlazo);
            Controls.Add(cmbTipoPrestamo);
            Controls.Add(button1);
            Controls.Add(btnSolicitar);
            Controls.Add(txtMotivo);
            Controls.Add(numMonto);
            Margin = new Padding(2);
            Name = "SolicitarPrestamoForm";
            Text = "SolicitarPrestamoForm";
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlazo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numMonto;
        private TextBox txtMotivo;
        private Button btnSolicitar;
        private Button button1;
        private ComboBox cmbTipoPrestamo;
        private NumericUpDown numPlazo;
        private Label lblTasaInteres;
        private Label lblCuotaEstimada;
        private Label lblTotalPagar;
        private DateTimePicker dtpFechaSolicitud;
    }
}