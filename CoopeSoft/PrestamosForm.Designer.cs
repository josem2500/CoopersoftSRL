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
            lstPrestamos = new ListBox();
            btnAprobar = new Button();
            btnRechazar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lstPrestamos
            // 
            lstPrestamos.FormattingEnabled = true;
            lstPrestamos.ItemHeight = 25;
            lstPrestamos.Location = new Point(56, 48);
            lstPrestamos.Name = "lstPrestamos";
            lstPrestamos.Size = new Size(587, 179);
            lstPrestamos.TabIndex = 0;
            lstPrestamos.SelectedIndexChanged += lstPrestamos_SelectedIndexChanged;
            // 
            // btnAprobar
            // 
            btnAprobar.Location = new Point(56, 266);
            btnAprobar.Name = "btnAprobar";
            btnAprobar.Size = new Size(112, 34);
            btnAprobar.TabIndex = 1;
            btnAprobar.Text = "Aprobar";
            btnAprobar.UseVisualStyleBackColor = true;
            btnAprobar.Click += btnAprobar_Click;
            // 
            // btnRechazar
            // 
            btnRechazar.Location = new Point(282, 266);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(112, 34);
            btnRechazar.TabIndex = 2;
            btnRechazar.Text = "Rechazar";
            btnRechazar.UseVisualStyleBackColor = true;
            btnRechazar.Click += btnRechazar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(531, 266);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PrestamosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnRechazar);
            Controls.Add(btnAprobar);
            Controls.Add(lstPrestamos);
            Name = "PrestamosForm";
            Text = "Prestamos";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstPrestamos;
        private Button btnAprobar;
        private Button btnRechazar;
        private Button button1;
    }
}