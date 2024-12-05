using AgrodelisForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgrodelisForm.Models;

namespace AgrodelisForm
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            CargarTodosVendedores();
        }




        private async void CargarTodosVendedores()
        {
            try
            {
                var vendedorService = new VendedorService(); // Instancia del servicio.
                var respuesta = await vendedorService.ObtenerTodosVendedores();

                if (!respuesta.Exitoso)
                {
                    MessageBox.Show(respuesta.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var vendedores = respuesta.Vendedores as List<Vendedor>;
                if (vendedores == null || !vendedores.Any())
                {
                    MessageBox.Show("No se encontraron vendedores.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Asignar los vendedores al DataGridView
                dataGridViewVendedores.DataSource = vendedores; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
