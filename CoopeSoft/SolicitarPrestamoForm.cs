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
using static CoopeSoft.SociosForm;

namespace CoopeSoft
{
    public partial class SolicitarPrestamoForm : Form
    {
        //private readonly int _idSocio;
        private readonly int _socioId;
        private decimal _tasaInteres;

        public SolicitarPrestamoForm(int socioId)
        {
            InitializeComponent();
            _socioId = socioId;
            ConfigurarControles();
            CargarTiposPrestamo();

        }

        private void ConfigurarControles()
        {
            // Configuración de rangos
            numMonto.Minimum = 1000;
            numMonto.Maximum = 1000000; // RD$1,000,000 como máximo
            numPlazo.Minimum = 3;       // 3 meses mínimo
            numPlazo.Maximum = 120;     // 10 años (120 meses) máximo

            // Configuración de fechas
            dtpFechaSolicitud.Value = DateTime.Today;
            dtpFechaSolicitud.Enabled = false;
        }

        private void CargarTiposPrestamo()
        {
            try
            {
                // Elimina el filtro WHERE Estado = 1 ya que la columna no existe
                string query = "SELECT TipoPrestamoID, Nombre, TasaInteres FROM TiposPrestamo";
                cmbTipoPrestamo.DataSource = DatabaseHelper.ExecuteQuery(query);
                cmbTipoPrestamo.DisplayMember = "Nombre";
                cmbTipoPrestamo.ValueMember = "TipoPrestamoID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de préstamo: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }



        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            try
            {
                string query = @"INSERT INTO Prestamos (
                                SocioID, 
                                TipoPrestamoID, 
                                Monto, 
                                SaldoPendiente, 
                                TasaInteres, 
                                PlazoMeses,
                                Observaciones
                               ) VALUES (
                                @SocioID, 
                                @TipoPrestamoID, 
                                @Monto, 
                                @Monto,  -- SaldoPendiente inicial igual al Monto
                                @TasaInteres, 
                                @PlazoMeses,
                                @Observaciones
                               )";

                var parametros = new[]
                {
                    new SqlParameter("@SocioID", _socioId),
                    new SqlParameter("@TipoPrestamoID", cmbTipoPrestamo.SelectedValue),
                    new SqlParameter("@Monto", numMonto.Value),
                    new SqlParameter("@TasaInteres", _tasaInteres),
                    new SqlParameter("@PlazoMeses", (int)numPlazo.Value),
                    new SqlParameter("@Observaciones", txtMotivo.Text.Trim())
                };

                DatabaseHelper.ExecuteNonQuery(query, parametros);
                MessageBox.Show("Solicitud de préstamo registrada exitosamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar préstamo: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*if (numMonto.Value > 0 && !string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                // En una aplicación real, aquí se guardaría en una base de datos
                MessageBox.Show($"Préstamo solicitado por {numMonto.Value:C}\nMotivo: {txtMotivo.Text}", "Solicitud Enviada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Complete todos los campos correctamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private bool ValidarDatos()
        {
            if (cmbTipoPrestamo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de préstamo", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numMonto.Value < numMonto.Minimum)
            {
                MessageBox.Show($"El monto mínimo es {numMonto.Minimum:C}", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Ingrese el motivo del préstamo", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        private void numMonto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipoPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoPrestamo.SelectedItem != null)
            {
                DataRowView row = (DataRowView)cmbTipoPrestamo.SelectedItem;
                _tasaInteres = Convert.ToDecimal(row["TasaInteres"]);
                lblTasaInteres.Text = $"{_tasaInteres}%";
                CalcularCuota();
            }
        }

        private void CalcularCuota()
        {
            if (cmbTipoPrestamo.SelectedIndex == -1) return;

            decimal monto = numMonto.Value;
            int plazo = (int)numPlazo.Value;
            decimal tasaMensual = _tasaInteres / 100 / 12;

            // Fórmula de cálculo de cuota mensual
            decimal factor = (decimal)Math.Pow(1 + (double)tasaMensual, plazo);
            decimal cuota = monto * (tasaMensual * factor) / (factor - 1);

            lblCuotaEstimada.Text = cuota.ToString("C2");
            lblTotalPagar.Text = (cuota * plazo).ToString("C2");
        }

        private void numPlazo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTasaInteres_Click(object sender, EventArgs e)
        {

        }

        private void lblCuotaEstimada_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPagar_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaSolicitud_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
