namespace CoopeSoft
{
    partial class SociosForm
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
            btnAgregar = new Button();
            btnEliminar = new Button();
            txtNombre = new TextBox();
            txtDNI = new TextBox();
            lstSocios = new ListBox();
            button1 = new Button();
            txtApellido = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(48, 322);
            btnAgregar.Margin = new Padding(2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(90, 27);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(243, 322);
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 27);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(48, 166);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(222, 27);
            txtNombre.TabIndex = 2;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(388, 198);
            txtDNI.Margin = new Padding(2);
            txtDNI.Name = "txtDNI";
            txtDNI.PlaceholderText = "DNI";
            txtDNI.Size = new Size(114, 27);
            txtDNI.TabIndex = 3;
            txtDNI.TextChanged += txtDNI_TextChanged;
            // 
            // lstSocios
            // 
            lstSocios.FormattingEnabled = true;
            lstSocios.Location = new Point(48, 18);
            lstSocios.Margin = new Padding(2);
            lstSocios.Name = "lstSocios";
            lstSocios.Size = new Size(494, 144);
            lstSocios.TabIndex = 4;
            lstSocios.SelectedIndexChanged += lstSocios_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(472, 322);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(90, 27);
            button1.TabIndex = 5;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(48, 198);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellidos";
            txtApellido.Size = new Size(222, 27);
            txtApellido.TabIndex = 6;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(48, 231);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.PlaceholderText = "Direccion";
            txtDireccion.Size = new Size(580, 27);
            txtDireccion.TabIndex = 7;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(388, 166);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Telefono";
            txtTelefono.Size = new Size(154, 27);
            txtTelefono.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(48, 264);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(331, 27);
            txtEmail.TabIndex = 9;
            // 
            // SociosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtApellido);
            Controls.Add(button1);
            Controls.Add(lstSocios);
            Controls.Add(txtDNI);
            Controls.Add(txtNombre);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Margin = new Padding(2);
            Name = "SociosForm";
            Text = "Formularios de Socios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnEliminar;
        private TextBox txtNombre;
        private TextBox txtDNI;
        private ListBox lstSocios;
        private Button button1;
        private TextBox txtApellido;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtEmail;
    }
}