namespace CoopeSoft
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            label1 = new Label();
            btnRegistrar = new Button();
            lnkOlvidoClave = new LinkLabel();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(70, 226);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(241, 27);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(70, 71);
            txtUsuario.Margin = new Padding(2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario";
            txtUsuario.Size = new Size(241, 27);
            txtUsuario.TabIndex = 1;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(71, 125);
            txtContrasena.Margin = new Padding(2);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PlaceholderText = "Contraseña";
            txtContrasena.Size = new Size(240, 27);
            txtContrasena.TabIndex = 2;
            txtContrasena.TextChanged += txtContrasena_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 32);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 3;
            label1.Text = "Login";
            label1.Click += label1_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(71, 326);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(240, 29);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lnkOlvidoClave
            // 
            lnkOlvidoClave.AutoSize = true;
            lnkOlvidoClave.Location = new Point(188, 166);
            lnkOlvidoClave.Name = "lnkOlvidoClave";
            lnkOlvidoClave.Size = new Size(123, 20);
            lnkOlvidoClave.TabIndex = 5;
            lnkOlvidoClave.TabStop = true;
            lnkOlvidoClave.Text = "¿Olvidó su clave?";
            lnkOlvidoClave.LinkClicked += lnkOlvidoClave_LinkClicked;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 415);
            Controls.Add(lnkOlvidoClave);
            Controls.Add(btnRegistrar);
            Controls.Add(label1);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(btnLogin);
            Margin = new Padding(2);
            Name = "LoginPage";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Label label1;
        private Button btnRegistrar;
        private LinkLabel lnkOlvidoClave;
    }
}
