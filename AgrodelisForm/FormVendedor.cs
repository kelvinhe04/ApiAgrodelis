using AgrodelisForm.Models;
using AgrodelisForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    


namespace AgrodelisForm
{
    public partial class FormVendedor : Form
    {
        public int UsuarioId { get; private set; }

        public FormVendedor(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            CargarProductosDelVendedor(UsuarioId);
            // Llamar al método para cargar las categorías en el ComboBox
            CargarCategorias();
        }
        private async void CargarProductosDelVendedor(int vendedorId)
        {
            try
            {
                var productoService = new ProductoService();
                var respuesta = await productoService.ObtenerProductosPorVendedor(vendedorId);

                // Verifica si la respuesta es válida y si la propiedad Productos no es null
                if (respuesta != null && respuesta.Exitoso && respuesta.Productos != null && respuesta.Productos.Any())
                {
                    
                    dataGridViewProductos.DataSource = respuesta.Productos;


                    if (dataGridViewProductos.Columns.Contains("ProductoId"))
                        dataGridViewProductos.Columns["ProductoId"].Visible = false;

                }
                else
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


        private async void CargarCategorias()
        {
            try
            {
                // Llamar al servicio para obtener las categorías
                var categoriaService = new CategoriaService();
                var respuesta = await categoriaService.ObtenerCategorias();

                if (respuesta.Exitoso)
                {
                    // Crear una lista nueva con una opción predeterminada
                    var categoriasConOpcionDefault = new List<Categoria>
            {
                new Categoria { CategoriaId = 0, Nombre = "Seleccione una categoría" } // Opción por defecto
            };

                    // Agregar las categorías reales a la lista
                    categoriasConOpcionDefault.AddRange(respuesta.Categorias);

                    // Configurar el ComboBox
                    cmbCategoria.DataSource = categoriasConOpcionDefault;
                    cmbCategoria.DisplayMember = "Nombre";
                    cmbCategoria.ValueMember = "CategoriaId";

                    // Establecer la selección inicial en el elemento "Seleccione una categoría"
                    cmbCategoria.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Error al cargar las categorías", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public static string GetRelativePath(string basePath, string fullPath)
        {
            Uri baseUri = new Uri(basePath);
            Uri fullUri = new Uri(fullPath);
            Uri relativeUri = baseUri.MakeRelativeUri(fullUri);
            return Uri.UnescapeDataString(relativeUri.ToString());
        }
        

        // Método para limpiar los campos del formulario después de registrar el producto
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            picBoxProducto.Image = null;
            cmbCategoria.SelectedIndex = -1;  // Desmarcar la categoría seleccionada
        }

        private void picBoxProducto_Click(object sender, EventArgs e)
        {
            // Mostrar el diálogo para seleccionar un archivo de imagen
            if (ofdProducto.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtener la extensión del archivo seleccionado y convertirla a minúsculas
                    var extension = Path.GetExtension(ofdProducto.FileName).ToLower();

                    // Verificar si el archivo seleccionado tiene una extensión válida
                    if (extension != ".avif" && extension != ".jpg" && extension != ".jpeg" && extension != ".jfif" && extension != ".png")
                    {
                        MessageBox.Show("Por favor, selecciona una imagen en formato válido (AVIF, JPG, JPEG, JFIF, PNG).", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Termina el proceso si no es un formato válido
                    }

                    // Intentar cargar la imagen en el PictureBox
                    picBoxProducto.Image = Image.FromFile(ofdProducto.FileName);
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje si ocurre un error al cargar la imagen
                    MessageBox.Show($"Hubo un error al cargar la imagen: {ex.Message}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void dataGridViewProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridViewProductos.SelectedRows[0];

                // Asigna los valores de las celdas a los controles correspondientes
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                txtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value?.ToString() ?? string.Empty;
                txtPrecio.Text = filaSeleccionada.Cells["Precio"].Value?.ToString() ?? string.Empty;
                txtStock.Text = filaSeleccionada.Cells["Stock"].Value?.ToString() ?? string.Empty;

                // Asignar la categoría al combo box si está disponible
                if (filaSeleccionada.Cells["CategoriaNombre"] != null)
                {
                    cmbCategoria.Text = filaSeleccionada.Cells["CategoriaNombre"].Value?.ToString() ?? string.Empty;
                }
                string rutaImagen = filaSeleccionada.Cells["RutaImagen"].Value?.ToString() ?? string.Empty;

                if (File.Exists(rutaImagen))
                {
                    picBoxProducto.Image = Image.FromFile(rutaImagen);
                }
                else
                {
                    picBoxProducto.Image = null;  // O poner una imagen por defecto si no existe
                }
            }
        }
        private async void toolStripMenuRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                string fullPath = ofdProducto.FileName; // Ruta completa de la imagen seleccionada

                string appDirectory = AppDomain.CurrentDomain.BaseDirectory; // Directorio de la aplicación

                // Obtener la ruta relativa
                string relativePath = GetRelativePath(appDirectory, fullPath);


                // Leer los datos del producto desde los TextBox y ComboBox
                var nombre = txtNombre.Text.Trim();
                var descripcion = txtDescripcion.Text.Trim();
                var precio = decimal.Parse(txtPrecio.Text.Trim());
                var stock = int.Parse(txtStock.Text.Trim());
                var rutaImagen = relativePath;
                var categoriaId = (int)cmbCategoria.SelectedValue;  // Obtener el ID de la categoría seleccionada
                Console.WriteLine(categoriaId);
                if (categoriaId == 0) // Verificar si no se ha seleccionado una categoría válida
                {
                    MessageBox.Show("Por favor, selecciona una categoría.", "Categoría no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el objeto de solicitud para registrar el producto
                var productoRequest = new RegistrarProductoRequest
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Precio = precio,
                    Stock = stock,
                    RutaImagen = rutaImagen,
                    CategoriaId = categoriaId,
                    VendedorId = UsuarioId,

                };

                // Llamar al servicio para registrar el producto
                var productoService = new ProductoService();
                var respuesta = await productoService.RegistrarProducto(productoRequest);

                if (respuesta.Exitoso)
                {
                    CargarProductosDelVendedor(UsuarioId);
                    MessageBox.Show("Producto registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"Error al registrar el producto: {respuesta.Mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void toolStripMenuModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProductos.SelectedRows.Count > 0)
                {
                    // Obtén el ProductoId de la fila seleccionada
                    int productoId = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ProductoId"].Value);
                    int cantidadRestante = Convert.ToInt32(txtStock.Text);

                    // Asegúrate de que la cantidad restante sea mayor a 0
                    if (cantidadRestante > 0)
                    {
                        var producto = new ModificarProductoRequest()
                        {
                            ProductoId = productoId,
                            Nombre = txtNombre.Text,
                            Descripcion = txtDescripcion.Text,
                            Precio = Convert.ToDecimal(txtPrecio.Text),
                            Stock = cantidadRestante,
                            RutaImagen = ofdProducto.FileName,
                            CategoriaId = (int)cmbCategoria.SelectedValue
                        };

                        var productoService = new ProductoService();
                        var respuesta = await productoService.ModificarProducto(producto);

                        if (respuesta.Exitoso)
                        {
                            // Refrescar el DataGridView después de la actualización
                            CargarProductosDelVendedor(UsuarioId);
                            MessageBox.Show("Producto modificado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar el producto.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad restante debe ser mayor que 0.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un producto de la tabla para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al modificar el producto: {ex.Message}");
            }
        }
    }

}
