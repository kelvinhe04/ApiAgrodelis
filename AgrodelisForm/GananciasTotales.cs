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

namespace AgrodelisForm
{
    public partial class GananciasTotales : Form
    {
        public GananciasTotales()
        {
            InitializeComponent();
            CargarTodasLasVentas();
            AplicarEstiloLabel();
        }
        private async void CargarTodasLasVentas()
        {
            try
            {
                var ventaService = new VentaService();
                var respuesta = await ventaService.ObtenerTodasLasVentas();

                if (respuesta == null || !respuesta.Exitoso)
                {
                    MessageBox.Show(respuesta?.Mensaje ?? "Error al obtener las ventas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblTotalVentas.Text = ($"${respuesta.TotalVentas.ToString()}");
                dataGridViewVentasTotales.DataSource = respuesta.Ventas;

               

                if (!respuesta.Ventas.Any())
                {
                    MessageBox.Show("No se encontraron ventas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void AplicarEstiloLabel()
        {


            label1.BackColor = Color.Transparent;
            label1.Parent = panel4;
            label1.Invalidate(); // Redibuja el control
            lblTotalVentas.BackColor = Color.Transparent;
            lblTotalVentas.Parent = panel4;
            lblTotalVentas.Invalidate(); // Redibuja el control




        }

        private void toolStripGestiónVendedoresForm_Click(object sender, EventArgs e)
        {
            FormAdmin FormAdmin = new FormAdmin();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            FormAdmin.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Opcionalmente, puedes mostrar un mensaje de confirmación
            MessageBox.Show("Sesión cerrada correctamente.", "Cierre de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormLogin formLogin = new FormLogin();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            formLogin.ShowDialog();
        }

        private void toolStripMenuInventarioForm_Click(object sender, EventArgs e)
        {
            Inventario Inventario = new Inventario();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            Inventario.ShowDialog();
        }
    }
}
