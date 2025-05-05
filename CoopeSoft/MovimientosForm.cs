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
    public partial class MovimientosForm : Form
    {
        //private List<Movimiento> movimientos = new List<Movimiento>();
        /*
        public class Movimiento
        {
            public int Id { get; set; }
            public string Tipo { get; set; } // Depósito, Retiro, Pago de préstamo, etc.
            public decimal Monto { get; set; }
            public DateTime Fecha { get; set; }
            public string Descripcion { get; set; }
        }*/
        public MovimientosForm()
        {
            InitializeComponent();
            CargarTiposMovimiento(); // Cargar comboBox al iniciar
            CargarMovimientos();
            // CargarMovimientosEjemplo();
            //ActualizarListaMovimientos();
           

            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close(); // Cierra el formulario si no hay conexión
                return;
            }        
        }

        /*private void CargarTiposMovimiento()
        {
            try
            {
                string query = "SELECT TipoMovimientoID, Nombre FROM TiposMovimiento";
                cmbTipo.DataSource = DatabaseHelper.ExecuteQuery(query);
                cmbTipo.DisplayMember = "Nombre";
                cmbTipo.ValueMember = "TipoMovimientoID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
        private void CargarTiposMovimiento()
        {
            try
            {
                string query = "SELECT TipoMovimientoID, Nombre FROM TiposMovimiento";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                // Configurar DisplayMember y ValueMember antes de asignar DataSource
                cmbTipo.DisplayMember = "Nombre";
                cmbTipo.ValueMember = "TipoMovimientoID";
                cmbTipo.DataSource = dt;

                // No seleccionar nada por defecto
                cmbTipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarMovimientos()
        {
            try
            {
                string query = @"SELECT 
                                m.Fecha, 
                                tm.Nombre AS Tipo, 
                                m.Monto, 
                                m.Descripcion 
                               FROM Movimientos m
                               INNER JOIN TiposMovimiento tm ON m.TipoMovimientoID = tm.TipoMovimientoID
                               ORDER BY m.Fecha DESC";

                dgvMovimientos.DataSource = DatabaseHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar movimientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void LimpiarCampos()
        {
            cmbTipo.SelectedIndex = -1;
            txtMonto.Text = "";
            txtDescripcion.Text = "";
        }

        /*private void CargarMovimientosEjemplo()
        {
            movimientos.Add(new Movimiento { Id = 1, Tipo = "Depósito", Monto = 1000, Fecha = DateTime.Now, Descripcion = "Ahorro mensual" });
            movimientos.Add(new Movimiento { Id = 2, Tipo = "Retiro", Monto = 500, Fecha = DateTime.Now, Descripcion = "Retiro para gastos" });
        }*/
        /*
        private void ActualizarListaMovimientos()
        {
            dgvMovimientos.Items.Clear();
            foreach (var movimiento in movimientos)
            {
                dgvMovimientos.Items.Add($"{movimiento.Fecha:dd/MM/yyyy} - {movimiento.Tipo} - {movimiento.Monto:C} - {movimiento.Descripcion}");
            }
        }*/

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1 || !decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Complete todos los campos correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO Movimientos (TipoMovimientoID, Monto, Descripcion, Fecha)
                                VALUES (@TipoID, @Monto, @Descripcion, GETDATE())";

                var parametros = new[]
                {
                    new SqlParameter("@TipoID", cmbTipo.SelectedValue),
                    new SqlParameter("@Monto", monto),
                    new SqlParameter("@Descripcion", txtDescripcion.Text)
                };

                DatabaseHelper.ExecuteNonQuery(query, parametros);
                MessageBox.Show("Movimiento registrado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar y refrescar
                txtMonto.Text = "";
                txtDescripcion.Text = "";
                //CargarMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*if (cmbTipo.SelectedItem != null && !string.IsNullOrWhiteSpace(txtMonto.Text) && !string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                int nuevoId = movimientos.Count > 0 ? movimientos[movimientos.Count - 1].Id + 1 : 1;
                decimal monto;
                if (decimal.TryParse(txtMonto.Text, out monto))
                {
                    movimientos.Add(new Movimiento
                    {
                        Id = nuevoId,
                        Tipo = cmbTipo.SelectedItem.ToString(),
                        Monto = monto,
                        Fecha = DateTime.Now,
                        Descripcion = txtDescripcion.Text
                    });

                    ActualizarListaMovimientos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
           

        }

      
        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}
