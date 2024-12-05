using AgrodelisForm.Models;
using AgrodelisForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgrodelisForm
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            comboBoxVendedores.DropDownStyle = ComboBoxStyle.DropDownList;
            AplicarEstiloLabel();
            CargarVendedores();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            CargarInventarioDeTodosLosVendedores();
        }

        private async void CargarInventarioDeTodosLosVendedores()
        {
            try
            {
                var productoService = new ProductoService();
                var respuesta = await productoService.ObtenerInventarioDeTodosLosVendedores();

                if (respuesta == null)
                {
                    MessageBox.Show("No se pudo obtener una respuesta válida del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (respuesta.Productos == null)
                {
                    respuesta.Productos = new List<Producto>();
                }

                if (!respuesta.Exitoso)
                {
                    MessageBox.Show(respuesta.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dataGridViewInventario == null)
                {
                    MessageBox.Show("El control DataGridView no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridViewInventario.DataSource = respuesta.Productos;

                if (dataGridViewInventario.Columns.Contains("RutaImagen"))
                    dataGridViewInventario.Columns["RutaImagen"].Visible = false;



                if (!respuesta.Productos.Any())
                {
                    MessageBox.Show("No se encontraron productos para ningún vendedor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Opcionalmente, puedes mostrar un mensaje de confirmación
            MessageBox.Show("Sesión cerrada correctamente.", "Cierre de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormLogin formLogin = new FormLogin();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            formLogin.ShowDialog();
        }

        private async void CargarVendedores()
        {
            try
            {
                var vendedorService = new VendedorService(); // Instancia del servicio.
                var respuesta = await vendedorService.ObtenerVendedores();

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

                // Crear una opción por defecto
                var opcionPorDefecto = new Vendedor { VendedorId = 0, Nombre = "Vendedores disponibles" };

                // Insertar la opción al inicio de la lista
                vendedores.Insert(0, opcionPorDefecto);

                // Asignar la lista al ComboBox
                comboBoxVendedores.DataSource = vendedores;
                comboBoxVendedores.DisplayMember = "Nombre";
                comboBoxVendedores.ValueMember = "VendedorId";

                // Seleccionar la opción por defecto
                comboBoxVendedores.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxVendedores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var vendedorSeleccionado = (Vendedor)comboBoxVendedores.SelectedItem;

            if (vendedorSeleccionado == null || vendedorSeleccionado.VendedorId == 0)
            {
                // Si no se selecciona un vendedor válido, limpiar el DataGridView.
                dataGridViewInventario.DataSource = null;
                return;
            }

            // Cargar los productos del vendedor seleccionado.
            CargarInventarioPorVendedor(vendedorSeleccionado.VendedorId);
        }

        private async void CargarInventarioPorVendedor(int vendedorId)
        {
            try
            {
                var productoService = new ProductoService(); // Instancia del servicio.
                var respuesta = await productoService.ObtenerInventarioPorVendedor(vendedorId);

                if (!respuesta.Exitoso)
                {
                    MessageBox.Show(respuesta.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (respuesta.Productos == null || !respuesta.Productos.Any())
                {
                    MessageBox.Show("No se encontraron productos para este vendedor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewInventario.DataSource = null;
                    return;
                }

                // Asignar los datos al DataGridView
                dataGridViewInventario.DataSource = respuesta.Productos;

                // Configurar columnas (opcional)
                if (dataGridViewInventario.Columns.Contains("RutaImagen"))
                    dataGridViewInventario.Columns["RutaImagen"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodoVendedores_Click(object sender, EventArgs e)
        {
            CargarInventarioDeTodosLosVendedores();
        }

        private void AplicarEstiloLabel()
        {


            label1.BackColor = Color.Transparent;
            label1.Parent = panel4;
            label1.Invalidate(); // Redibuja el control
            label2.BackColor = Color.Transparent;
            label2.Parent = panel4;
            label2.Invalidate(); // Redibuja el control
            



        }

        private void toolStripMenuInventario_Click(object sender, EventArgs e)
        {
            GananciasTotales formGananciastotal = new GananciasTotales();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            formGananciastotal.ShowDialog();
        }

        private void toolStripMenuAdminForm_Click(object sender, EventArgs e)
        {
            FormAdmin FormAdmin = new FormAdmin();  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            FormAdmin.ShowDialog();
        }
    }
}
