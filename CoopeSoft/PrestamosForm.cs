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
    public partial class PrestamosForm : Form
    {
        //private List<Prestamo> prestamos = new List<Prestamo>();

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
            ConfigurarDataGridView();
            CargarPrestamos();
            
            //CargarPrestamos();
            //CargarSociosCombo();
            //CargarPrestamosEjemplo();
            //ActualizarListaPrestamos();
        }


        private void ConfigurarDataGridView()
        {
            dgvPrestamos.AutoGenerateColumns = false;
            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configurar columnas manualmente para mejor control
            dgvPrestamos.Columns.Add("PrestamoID", "ID");
            dgvPrestamos.Columns.Add("SocioInfo", "Socio");
            dgvPrestamos.Columns.Add("Monto", "Monto");
            dgvPrestamos.Columns.Add("TipoPrestamo", "Tipo");
            dgvPrestamos.Columns.Add("FechaSolicitud", "Solicitud");
            dgvPrestamos.Columns.Add("Estado", "Estado");

            // Formato de columnas
            dgvPrestamos.Columns["Monto"].DefaultCellStyle.Format = "C2";
            dgvPrestamos.Columns["FechaSolicitud"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void CargarPrestamos()
        {
            try
            {
                string query = @"SELECT 
                                p.PrestamoID,
                                CONCAT(s.Nombre, ' ', s.Apellido) AS SocioInfo,
                                p.Monto,
                                tp.Nombre AS TipoPrestamo,
                                p.FechaSolicitud,
                                p.Estado
                               FROM Prestamos p
                               INNER JOIN Socios s ON p.SocioID = s.Id
                               INNER JOIN TiposPrestamo tp ON p.TipoPrestamoID = tp.TipoPrestamoID
                               ORDER BY p.FechaSolicitud DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvPrestamos.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvPrestamos.Rows.Add(
                        row["PrestamoID"],
                        row["SocioInfo"],
                        row["Monto"],
                        row["TipoPrestamo"],
                        row["FechaSolicitud"],
                        row["Estado"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /*private void CargarPrestamosEjemplo()
        {
            prestamos.Add(new Prestamo { Id = 1, SocioId = 1, Monto = 5000, FechaSolicitud = DateTime.Now, Estado = "Aprobado" });
            prestamos.Add(new Prestamo { Id = 2, SocioId = 2, Monto = 3000, FechaSolicitud = DateTime.Now, Estado = "Pendiente" });
        }*/
        /*
        private void ActualizarListaPrestamos()
        {
            lstPrestamos.Items.Clear();
            foreach (var prestamo in prestamos)
            {
                lstPrestamos.Items.Add($"Préstamo #{prestamo.Id} - Socio: {prestamo.SocioId} - Monto: {prestamo.Monto:C} - Estado: {prestamo.Estado}");
            }
        }*/

        private void lstPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int prestamoId = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["PrestamoID"].Value);
            CambiarEstadoPrestamo(prestamoId, "Aprobado");
            /*if (lstPrestamos.SelectedIndex != -1)
            {
                prestamos[lstPrestamos.SelectedIndex].Estado = "Aprobado";
                ActualizarListaPrestamos();
            }
            else
            {
                MessageBox.Show("Seleccione un préstamo para aprobar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int prestamoId = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["PrestamoID"].Value);
            CambiarEstadoPrestamo(prestamoId, "Rechazado");
            /*if (lstPrestamos.SelectedIndex != -1)
            {
                prestamos[lstPrestamos.SelectedIndex].Estado = "Rechazado";
                ActualizarListaPrestamos();
            }
            else
            {
                MessageBox.Show("Seleccione un préstamo para rechazar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void CambiarEstadoPrestamo(int prestamoId, string nuevoEstado)
        {
            try
            {
                string query = @"UPDATE Prestamos 
                               SET Estado = @Estado,
                                   FechaAprobacion = CASE WHEN @Estado = 'Aprobado' THEN GETDATE() ELSE FechaAprobacion END
                               WHERE PrestamoID = @PrestamoID";

                var parametros = new[]
                {
                    new SqlParameter("@PrestamoID", prestamoId),
                    new SqlParameter("@Estado", nuevoEstado)
                };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parametros);

                if (affectedRows > 0)
                {
                    MessageBox.Show($"Préstamo {nuevoEstado.ToLower()} correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPrestamos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar estado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerarPlanPagos_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0) return;

            int prestamoId = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["PrestamoID"].Value);
            var planPagosForm = new PlanPagosForm(prestamoId);
            planPagosForm.ShowDialog();
        }

        private void dgvPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
