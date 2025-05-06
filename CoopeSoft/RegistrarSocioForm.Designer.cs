namespace CoopeSoft
{
    partial class RegistrarSocioForm
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
            txtDNI = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(56, 44);
            txtDNI.Name = "txtDNI";
            txtDNI.PlaceholderText = "DNI";
            txtDNI.Size = new Size(201, 27);
            txtDNI.TabIndex = 0;
            txtDNI.TextChanged += txtDNI_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(56, 106);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(227, 27);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(56, 165);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(227, 27);
            txtApellido.TabIndex = 2;
            txtApellido.TextChanged += txtApellido_TextChanged;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(56, 226);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.PlaceholderText = "Direccion";
            txtDireccion.Size = new Size(596, 27);
            txtDireccion.TabIndex = 3;
            txtDireccion.TextChanged += txtDireccion_TextChanged;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(56, 292);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Telefono";
            txtTelefono.Size = new Size(227, 27);
            txtTelefono.TabIndex = 4;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(56, 346);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(227, 27);
            txtEmail.TabIndex = 5;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(446, 48);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(206, 27);
            txtUsername.TabIndex = 6;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(446, 106);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(206, 27);
            txtPassword.TabIndex = 7;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(56, 426);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(134, 42);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(446, 426);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(123, 42);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RegistrarSocioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 538);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistrar);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtDNI);
            Name = "RegistrarSocioForm";
            Text = "RegistrarSocioForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDNI;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnRegistrar;
        private Button btnCancelar;
    }
}