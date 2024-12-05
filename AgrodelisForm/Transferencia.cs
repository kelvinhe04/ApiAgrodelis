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
using AgrodelisForm.Services;

namespace AgrodelisForm
{
    public partial class Transferencia : Form
    {
        public int UsuarioId { get; private set; }

        // Constructor
        public Transferencia(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            CargarProductosDelVendedor(UsuarioId);  // Cargar productos del vendedor
            CargarTodosVendedores();
        }

        // Método para cargar los productos del vendedor
        private async void CargarProductosDelVendedor(int vendedorId)
        {
            try
            {
                var productoService = new ProductoService();
                var respuesta = await productoService.ObtenerProductosPorVendedor(vendedorId);



                dataGridViewProductos.DataSource = respuesta.Productos;


                if (dataGridViewProductos.Columns.Contains("ProductoId"))
                    dataGridViewProductos.Columns["ProductoId"].Visible = false;

                if (!respuesta.Exitoso)
                {
                    // Mostrar mensaje si no se encontraron productos
                    MessageBox.Show("No se encontraron productos para este vendedor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y mostrar un mensaje
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los usuarios (vendedores)
        private async void CargarTodosVendedores()
        {
            try
            {
                var vendedorService = new VendedorService(); // Instancia del servicio
                var respuesta = await vendedorService.ObtenerTodosVendedores(); // Llamada al servicio para obtener los vendedores

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

                // Asignar los vendedores al DataGridView, con las columnas adecuadas
                dataGridViewVendedores.DataSource = vendedores.Select(v => new
                {
                    v.VendedorId,
                    v.Nombre,
                    v.Email,
                    v.Activo
                }).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó un producto y un vendedor
            if (dataGridViewProductos.SelectedRows.Count == 0 || dataGridViewVendedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto y un vendedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que se haya ingresado una cantidad válida
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el producto seleccionado
            var productoSeleccionado = dataGridViewProductos.SelectedRows[0].DataBoundItem as Producto;
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Error al obtener el producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el vendedor seleccionado
            var vendedorSeleccionado = dataGridViewVendedores.SelectedRows[0].DataBoundItem as dynamic;
            if (vendedorSeleccionado == null)
            {
                MessageBox.Show("Error al obtener el vendedor seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Aquí podrías enviar la cantidad del producto al vendedor, por ejemplo:
            var transferencia = new TransferenciaProducto
            {
                ProductoId = productoSeleccionado.ProductoId,
                VendedorId = vendedorSeleccionado.VendedorId,
                Cantidad = cantidad
            };

            // Llamar al servicio para realizar la transferencia
            var transferenciaService = new TransferenciaService();
            var respuesta = await transferenciaService.RealizarTransferencia(transferencia);

            if (respuesta.Exitoso)
            {
                MessageBox.Show("Transferencia realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
