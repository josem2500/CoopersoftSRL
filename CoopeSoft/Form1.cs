using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace CoopeSoft
{
    public partial class LoginPage : Form
    {
        private readonly bool _modoPrueba = true;
        private string connectionString = @"Server=DEVT470P;Database=CooperativaDB;
                                 Integrated Security=True;
                                 TrustServerCertificate=True;";
        public LoginPage()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
             if (_modoPrueba)
            {
                try
                {
                    MainForm mainForm = new MainForm(true, "Administrador (Prueba)", 0);
                    Hide();
                    mainForm.ShowDialog();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir el formulario principal: {ex.Message}",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            /*string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = @"SELECT u.Rol, u.NombreCompleto, u.IdSocio 
                               FROM Usuarios u
                               LEFT JOIN Socios s ON u.IdSocio = s.Id
                               WHERE u.Username = @Usuario 
                               AND u.Password = @Contrasena 
                               AND (u.IdSocio IS NULL OR s.Estado = 'Activo')";
                var parameters = new[]
                {
                    new SqlParameter("@Usuario", usuario),
                    new SqlParameter("@Contrasena", HashPassword(contrasena))
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    string rol = row["Rol"].ToString();
                    string nombreCompleto = row["NombreCompleto"].ToString();
                    int idSocio = row["IdSocio"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdSocio"]);

                    MainForm mainForm = new MainForm(rol == "admin", nombreCompleto, idSocio);
                    Hide();
                    mainForm.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            /*string rol = "admin";
            string nombreCompleto = "Administrador (Prueba)";

            MainForm mainForm = new MainForm(rol == "admin", nombreCompleto);
            mainForm.Show();
            this.Hide();

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = @"SELECT u.Rol, u.NombreCompleto, u.IdSocio 
                               FROM Usuarios u
                               LEFT JOIN Socios s ON u.IdSocio = s.Id
                               WHERE u.Username = @Usuario 
                               AND u.Password = @Contrasena 
                               AND (u.IdSocio IS NULL OR s.Estado = 'Activo')";
                var parameters = new[]
                {
                    new SqlParameter("@Usuario", usuario),
                    new SqlParameter("@Contrasena", HashPassword(contrasena))
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    string rol = row["Rol"].ToString();
                    string nombreCompleto = row["NombreCompleto"].ToString();
                    int idSocio = row["IdSocio"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdSocio"]);

                    MainForm mainForm = new MainForm(rol == "admin", nombreCompleto, idSocio);
                    Hide();
                    mainForm.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/


            //////////////////////////////Viejo trabajando
            /*string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Rol, NombreCompleto FROM Usuarios WHERE Username = @Usuario AND Password = @Contrasena";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Contrasena", contrasena); // En producción usa hash

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string rol = reader["Rol"].ToString();
                                string nombreCompleto = reader["NombreCompleto"].ToString();

                                MainForm mainForm = new MainForm(rol == "admin", nombreCompleto);
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
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




        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lnkOlvidoClave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*using (var recuperarForm = new RecuperarClaveForm())
            {
                recuperarForm.ShowDialog();
            }*/

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var registrarForm = new RegistrarSocioForm())
            {
                if (registrarForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Socio registrado exitosamente. Ahora puede iniciar sesión.",
                                   "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
