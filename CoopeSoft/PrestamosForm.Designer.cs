namespace CoopeSoft
{
    partial class PrestamosForm
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
            btnAprobar = new Button();
            btnRechazar = new Button();
            button1 = new Button();
            dgvPrestamos = new DataGridView();
            btnGenerarPlanPagos = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // btnAprobar
            // 
            btnAprobar.Location = new Point(42, 392);
            btnAprobar.Margin = new Padding(2);
            btnAprobar.Name = "btnAprobar";
            btnAprobar.Size = new Size(90, 27);
            btnAprobar.TabIndex = 1;
            btnAprobar.Text = "Aprobar";
            btnAprobar.UseVisualStyleBackColor = true;
            btnAprobar.Click += btnAprobar_Click;
            // 
            // btnRechazar
            // 
            btnRechazar.Location = new Point(191, 392);
            btnRechazar.Margin = new Padding(2);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(90, 27);
            btnRechazar.TabIndex = 2;
            btnRechazar.Text = "Rechazar";
            btnRechazar.UseVisualStyleBackColor = true;
            btnRechazar.Click += btnRechazar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(400, 392);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(90, 27);
            button1.TabIndex = 3;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Location = new Point(42, 12);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.RowHeadersWidth = 51;
            dgvPrestamos.Size = new Size(838, 360);
            dgvPrestamos.TabIndex = 4;
            dgvPrestamos.CellContentClick += dgvPrestamos_CellContentClick;
            // 
            // btnGenerarPlanPagos
            // 
            btnGenerarPlanPagos.Location = new Point(621, 392);
            btnGenerarPlanPagos.Name = "btnGenerarPlanPagos";
            btnGenerarPlanPagos.Size = new Size(172, 29);
            btnGenerarPlanPagos.TabIndex = 5;
            btnGenerarPlanPagos.Text = "General pagos";
            btnGenerarPlanPagos.UseVisualStyleBackColor = true;
            btnGenerarPlanPagos.Click += btnGenerarPlanPagos_Click;
            // 
            // PrestamosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 498);
            Controls.Add(btnGenerarPlanPagos);
            Controls.Add(dgvPrestamos);
            Controls.Add(button1);
            Controls.Add(btnRechazar);
            Controls.Add(btnAprobar);
            Margin = new Padding(2);
            Name = "PrestamosForm";
            Text = "Prestamos";
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAprobar;
        private Button btnRechazar;
        private Button button1;
        private DataGridView dgvPrestamos;
        private Button btnGenerarPlanPagos;
    }
}