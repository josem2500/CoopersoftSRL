using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CoopeSoft
{
    public partial class RegistrarSocioForm : Form
    {
        public RegistrarSocioForm()
        {
            InitializeComponent();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                // Insertar en Socios
                string querySocio = @"INSERT INTO Socios (DNI, Nombre, Apellido, Direccion, Telefono, Email, Estado) 
                                    OUTPUT INSERTED.Id
                                    VALUES (@DNI, @Nombre, @Apellido, @Direccion, @Telefono, @Email, 'Activo')";
                var socioParams = new[]
                {
                    new SqlParameter("@DNI", txtDNI.Text),
                    new SqlParameter("@Nombre", txtNombre.Text),
                    new SqlParameter("@Apellido", txtApellido.Text),
                    new SqlParameter("@Direccion", txtDireccion.Text ?? (object)DBNull.Value),
                    new SqlParameter("@Telefono", txtTelefono.Text ?? (object)DBNull.Value),
                    new SqlParameter("@Email", txtEmail.Text ?? (object)DBNull.Value)
                };

                int nuevoSocioId = (int)DatabaseHelper.ExecuteScalar(querySocio, socioParams);

                // Insertar en Usuarios
                string queryUsuario = @"INSERT INTO Usuarios (Username, Password, Rol, NombreCompleto, IdSocio, Email) 
                                      VALUES (@Username, @Password, 'socio', @NombreCompleto, @IdSocio, @Email)";
                var usuarioParams = new[]
                {
                    new SqlParameter("@Username", txtUsername.Text),
                    new SqlParameter("@Password", HashPassword(txtPassword.Text)),
                    new SqlParameter("@NombreCompleto", $"{txtNombre.Text} {txtApellido.Text}"),
                    new SqlParameter("@IdSocio", nuevoSocioId),
                    new SqlParameter("@Email", txtEmail.Text ?? (object)DBNull.Value)
                };

                DatabaseHelper.ExecuteNonQuery(queryUsuario, usuarioParams);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("El DNI o nombre de usuario ya está registrado.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar socio: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("DNI, Nombre, Apellido, Username y Password son obligatorios.",
                               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtDNI.Text, @"^\d{8,20}$"))
            {
                MessageBox.Show("El DNI debe contener entre 8 y 20 dígitos.",
                               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El email no tiene un formato válido.",
                               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.",
                               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
