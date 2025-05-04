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
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
            SuspendLayout();
            // 
            // numMonto
            // 
            numMonto.Location = new Point(63, 56);
            numMonto.Name = "numMonto";
            numMonto.Size = new Size(236, 31);
            numMonto.TabIndex = 0;
            numMonto.ValueChanged += numMonto_ValueChanged;
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(63, 137);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.PlaceholderText = "Motivo";
            txtMotivo.Size = new Size(649, 31);
            txtMotivo.TabIndex = 1;
            txtMotivo.TextChanged += txtMotivo_TextChanged;
            // 
            // btnSolicitar
            // 
            btnSolicitar.Location = new Point(63, 241);
            btnSolicitar.Name = "btnSolicitar";
            btnSolicitar.Size = new Size(112, 34);
            btnSolicitar.TabIndex = 2;
            btnSolicitar.Text = "Solicitar";
            btnSolicitar.UseVisualStyleBackColor = true;
            btnSolicitar.Click += btnSolicitar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(600, 372);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SolicitarPrestamoForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnSolicitar);
            Controls.Add(txtMotivo);
            Controls.Add(numMonto);
            Name = "SolicitarPrestamoForm";
            Text = "SolicitarPrestamoForm";
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numMonto;
        private TextBox txtMotivo;
        private Button btnSolicitar;
        private Button button1;
    }
}