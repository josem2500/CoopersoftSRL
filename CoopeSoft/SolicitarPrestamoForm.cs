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
    public partial class SolicitarPrestamoForm : Form
    {
        public SolicitarPrestamoForm()
        {
            InitializeComponent();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (numMonto.Value > 0 && !string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                // En una aplicación real, aquí se guardaría en una base de datos
                MessageBox.Show($"Préstamo solicitado por {numMonto.Value:C}\nMotivo: {txtMotivo.Text}", "Solicitud Enviada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Complete todos los campos correctamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
    }
}
