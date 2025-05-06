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
    public partial class MainForm : Form
    {
        private bool esAdministrador;
        private string nombreUsuario;

        private readonly bool _esAdmin;
        private readonly string _nombreUsuario;
        private int _idSocioActual;

        /*bool esAdmin, string nombreUsuario*/
        public MainForm(bool esAdmin, string nombreUsuario, int idSocioActual = 0)
        {
            InitializeComponent();
            this.esAdministrador = esAdmin;
            this.nombreUsuario = nombreUsuario;

            ConfigurarVistasSegunRol();
            MostrarBienvenida();
            _esAdmin = esAdmin;
            _nombreUsuario = nombreUsuario;
            _idSocioActual = idSocioActual;

            // Configurar UI según el rol
            //lblBienvenida.Text = $"Bienvenido, {_nombreUsuario}";
            btnSocios.Visible = _esAdmin;
            btnTodosPrestamos.Visible = _esAdmin;
            btnPrestamos.Text = _esAdmin ? "Gestionar Préstamos" : "Solicitar Préstamo";
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
            

            int idSocioActual = 1;
            SolicitarPrestamoForm prestamoForm = new SolicitarPrestamoForm(idSocioActual);
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
