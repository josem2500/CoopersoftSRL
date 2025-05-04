namespace CoopeSoft
{
    partial class MainForm
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
            btnSocios = new Button();
            btnPrestamos = new Button();
            btnMovimientos = new Button();
            btnTodosPrestamos = new Button();
            SuspendLayout();
            // 
            // btnSocios
            // 
            btnSocios.Location = new Point(56, 82);
            btnSocios.Name = "btnSocios";
            btnSocios.Size = new Size(112, 34);
            btnSocios.TabIndex = 0;
            btnSocios.Text = "Socio";
            btnSocios.UseVisualStyleBackColor = true;
            btnSocios.Click += btnSocios_Click;
            // 
            // btnPrestamos
            // 
            btnPrestamos.Location = new Point(229, 82);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(112, 34);
            btnPrestamos.TabIndex = 1;
            btnPrestamos.Text = "Prestamos";
            btnPrestamos.UseVisualStyleBackColor = true;
            btnPrestamos.Click += btnPrestamos_Click;
            // 
            // btnMovimientos
            // 
            btnMovimientos.Location = new Point(402, 82);
            btnMovimientos.Name = "btnMovimientos";
            btnMovimientos.Size = new Size(138, 34);
            btnMovimientos.TabIndex = 2;
            btnMovimientos.Text = "Movimientos";
            btnMovimientos.UseVisualStyleBackColor = true;
            btnMovimientos.Click += btnMovimientos_Click;
            // 
            // btnTodosPrestamos
            // 
            btnTodosPrestamos.Location = new Point(605, 82);
            btnTodosPrestamos.Name = "btnTodosPrestamos";
            btnTodosPrestamos.Size = new Size(112, 34);
            btnTodosPrestamos.TabIndex = 3;
            btnTodosPrestamos.Text = "All prestamos";
            btnTodosPrestamos.UseVisualStyleBackColor = true;
            btnTodosPrestamos.Click += btnTodosPrestamos_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTodosPrestamos);
            Controls.Add(btnMovimientos);
            Controls.Add(btnPrestamos);
            Controls.Add(btnSocios);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSocios;
        private Button btnPrestamos;
        private Button btnMovimientos;
        private Button btnTodosPrestamos;
    }
}