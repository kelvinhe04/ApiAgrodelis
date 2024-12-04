using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgrodelisForm.Services;
using AgrodelisForm.Models;
using Newtonsoft.Json;

namespace AgrodelisForm
{
    public partial class Ganancias : Form
    {

        public int UsuarioId { get; private set; }
        public Ganancias(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            CargarVentasDelVendedor(UsuarioId);
        }


        private async void CargarVentasDelVendedor(int vendedorId)
        {
            try
            {
                var ventaService = new VentaService();
                var respuesta = await ventaService.ObtenerVentasPorVendedor(vendedorId);
                


                if (respuesta == null)
                {
                    MessageBox.Show("No se pudo obtener una respuesta válida del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (respuesta.Ventas == null)
                {
                    respuesta.Ventas = new List<Ventas>();
                }

                if (!respuesta.Exitoso)
                {
                    MessageBox.Show(respuesta.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dataGridViewVentas == null)
                {
                    MessageBox.Show("El control DataGridView no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Console.WriteLine(respuesta.Ventas);

                dataGridViewVentas.DataSource = respuesta.Ventas;

                // Ocultar columnas innecesarias
                if (dataGridViewVentas.Columns.Contains("VentaId"))
                    dataGridViewVentas.Columns["VentaId"].Visible = false;

                if (dataGridViewVentas.Columns.Contains("ProductoId"))
                    dataGridViewVentas.Columns["ProductoId"].Visible = false;

                if (dataGridViewVentas.Columns.Contains("VendedorId"))
                    dataGridViewVentas.Columns["VendedorId"].Visible = false;

                if (!respuesta.Ventas.Any())
                {
                    MessageBox.Show("No se encontraron ventas para este vendedor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
