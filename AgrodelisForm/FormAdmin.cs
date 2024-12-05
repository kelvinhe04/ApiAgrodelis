using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgrodelisForm
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
















        //Nombres dentro del txt
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
            }
        }



        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Email")
            {
                txtNombre.Text = "";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Email";
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Contraseña")
            {
                txtNombre.Text = "";
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Contraseña";
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Opcionalmente, puedes mostrar un mensaje de confirmación
            MessageBox.Show("Sesión cerrada correctamente.", "Cierre de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormLogin formLogin = new FormLogin();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            formLogin.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuInventario_Click(object sender, EventArgs e)
        {
            Inventario Inventario = new Inventario();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            Inventario.ShowDialog();
        }

        private void toolStripMenuGananciasTotales_Click(object sender, EventArgs e)
        {
            GananciasTotales GananciasTotales = new GananciasTotales();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            GananciasTotales.ShowDialog();
        }
    }
}
