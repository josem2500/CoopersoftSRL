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
        private List<Movimiento> movimientos = new List<Movimiento>();

        public class Movimiento
        {
            public int Id { get; set; }
            public string Tipo { get; set; } // Depósito, Retiro, Pago de préstamo, etc.
            public decimal Monto { get; set; }
            public DateTime Fecha { get; set; }
            public string Descripcion { get; set; }
        }
        public MovimientosForm()
        {
            InitializeComponent();
            CargarMovimientosEjemplo();
            ActualizarListaMovimientos();
        }

        private void LimpiarCampos()
        {
            cmbTipo.SelectedIndex = -1;
            txtMonto.Text = "";
            txtDescripcion.Text = "";
        }

        private void CargarMovimientosEjemplo()
        {
            movimientos.Add(new Movimiento { Id = 1, Tipo = "Depósito", Monto = 1000, Fecha = DateTime.Now, Descripcion = "Ahorro mensual" });
            movimientos.Add(new Movimiento { Id = 2, Tipo = "Retiro", Monto = 500, Fecha = DateTime.Now, Descripcion = "Retiro para gastos" });
        }

        private void ActualizarListaMovimientos()
        {
            lstMovimientos.Items.Clear();
            foreach (var movimiento in movimientos)
            {
                lstMovimientos.Items.Add($"{movimiento.Fecha:dd/MM/yyyy} - {movimiento.Tipo} - {movimiento.Monto:C} - {movimiento.Descripcion}");
            }
        }

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
            if (cmbTipo.SelectedItem != null && !string.IsNullOrWhiteSpace(txtMonto.Text) && !string.IsNullOrWhiteSpace(txtDescripcion.Text))
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
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
