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
    public partial class MainForm : Form
    {
        private bool esAdministrador;
        private string nombreUsuario;
       

       
        
        public MainForm(bool esAdmin, string nombreUsuario)
        {
            InitializeComponent();
            this.esAdministrador = esAdmin;
            this.nombreUsuario = nombreUsuario;

            ConfigurarVistasSegunRol();
            MostrarBienvenida();
        }
        private void ConfigurarVistasSegunRol()
        {
            btnSocios.Visible = esAdministrador;
            btnMovimientos.Visible = esAdministrador;
            btnTodosPrestamos.Visible = esAdministrador;
        }

        private void MostrarBienvenida()
        {
            Text = $"Cooperativa App - Bienvenido {nombreUsuario}";
            if (esAdministrador)
            {
                Text += " (Administrador)";
            }
        }
        private void btnSocios_Click(object sender, EventArgs e)
        {
            SociosForm sociosForm = new SociosForm();
            sociosForm.ShowDialog();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            SolicitarPrestamoForm prestamoForm = new SolicitarPrestamoForm();
            prestamoForm.ShowDialog();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            MovimientosForm movimientosForm = new MovimientosForm();
            movimientosForm.ShowDialog();
        }

        private void btnTodosPrestamos_Click(object sender, EventArgs e)
        {
            PrestamosForm prestamosForm = new PrestamosForm();
            prestamosForm.ShowDialog();
        }
    }
}
