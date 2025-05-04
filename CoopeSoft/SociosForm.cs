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

namespace CoopeSoft
{
    public partial class SociosForm : Form
    {

        private string connectionString = @"Server=DEVT470P;Database=CooperativaDB;
                                         Integrated Security=True;
                                         TrustServerCertificate=True;";

        public class Socio
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Estado { get; set; }
    public DateTime FechaRegistro { get; set; }
}
        public SociosForm()
        {
            InitializeComponent();         
            CargarSocios();
        }

        private void CargarSocios()
        {
            lstSocios.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, DNI, Nombre, Apellido, Estado FROM Socios";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string socioInfo = $"{reader["Id"]} - {reader["Nombre"]} {reader["Apellido"]} (DNI: {reader["DNI"]}) - {reader["Estado"]}";
                                lstSocios.Items.Add(socioInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar socios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (ValidarCampos())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = @"INSERT INTO Socios (DNI, Nombre, Apellido, Direccion, Telefono, Email) 
                                        VALUES (@DNI, @Nombre, @Apellido, @Direccion, @Telefono, @Email)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DNI", txtDNI.Text);
                            command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                            command.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                            command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                            command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                            command.Parameters.AddWithValue("@Email", txtEmail.Text);

                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Socio agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarCampos();
                                CargarSocios();
                            }
                        }
                    }
                }
                catch (SqlException ex) when (ex.Number == 2627) // Violación de UNIQUE KEY
                {
                    MessageBox.Show("Ya existe un socio con este DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar socio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /* if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtDNI.Text))
                 {
                     int nuevoId = socios.Count > 0 ? socios[socios.Count - 1].Id + 1 : 1;
                     socios.Add(new Socio
                     {
                         Id = nuevoId,
                         Nombre = txtNombre.Text,
                         DNI = txtDNI.Text,
                         FechaRegistro = DateTime.Now
                     });

                     ActualizarListaSocios();
                     LimpiarCampos();
                 }
                 else
                 {
                     MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }*/
            }
        }


        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("DNI, Nombre y Apellido son campos obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (lstSocios.SelectedIndex != -1)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este socio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int selectedId = ObtenerIdSeleccionado();

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "UPDATE Socios SET Estado = 'Inactivo' WHERE Id = @Id";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", selectedId);
                                int result = command.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    MessageBox.Show("Socio marcado como inactivo", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargarSocios();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar socio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un socio para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            /*if (lstSocios.SelectedIndex != -1)
            {
                socios.RemoveAt(lstSocios.SelectedIndex);
                ActualizarListaSocios();
            }
            else
            {
                MessageBox.Show("Seleccione un socio para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private int ObtenerIdSeleccionado()
        {
            string selectedItem = lstSocios.SelectedItem.ToString();
            return int.Parse(selectedItem.Split('-')[0].Trim());
        }

        private void lstSocios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
