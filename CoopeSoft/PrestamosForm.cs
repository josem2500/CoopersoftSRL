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
    public partial class PrestamosForm : Form
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        public class Prestamo
        {
            public int Id { get; set; }
            public int SocioId { get; set; }
            public decimal Monto { get; set; }
            public DateTime FechaSolicitud { get; set; }
            public string Estado { get; set; } // Pendiente, Aprobado, Rechazado
        }
        public PrestamosForm()
        {
            InitializeComponent();
            //CargarPrestamos();
            //CargarSociosCombo();
            //CargarPrestamosEjemplo();
            //ActualizarListaPrestamos();
        }



        private void CargarPrestamosEjemplo()
        {
            prestamos.Add(new Prestamo { Id = 1, SocioId = 1, Monto = 5000, FechaSolicitud = DateTime.Now, Estado = "Aprobado" });
            prestamos.Add(new Prestamo { Id = 2, SocioId = 2, Monto = 3000, FechaSolicitud = DateTime.Now, Estado = "Pendiente" });
        }

        private void ActualizarListaPrestamos()
        {
            lstPrestamos.Items.Clear();
            foreach (var prestamo in prestamos)
            {
                lstPrestamos.Items.Add($"Préstamo #{prestamo.Id} - Socio: {prestamo.SocioId} - Monto: {prestamo.Monto:C} - Estado: {prestamo.Estado}");
            }
        }

        private void lstPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (lstPrestamos.SelectedIndex != -1)
            {
                prestamos[lstPrestamos.SelectedIndex].Estado = "Aprobado";
                ActualizarListaPrestamos();
            }
            else
            {
                MessageBox.Show("Seleccione un préstamo para aprobar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {

            if (lstPrestamos.SelectedIndex != -1)
            {
                prestamos[lstPrestamos.SelectedIndex].Estado = "Rechazado";
                ActualizarListaPrestamos();
            }
            else
            {
                MessageBox.Show("Seleccione un préstamo para rechazar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
