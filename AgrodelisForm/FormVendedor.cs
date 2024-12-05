using AgrodelisForm.Models;
using AgrodelisForm.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;




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
            AplicarEstiloLabel();
            btnClose.Focus();
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;





        }
        private void FormVendedor_Load(object sender, EventArgs e)
        {
            ofdProducto.FileName = string.Empty;
            RevisarStockBajoPorVendedor(UsuarioId);


        }

        private async void CargarProductosDelVendedor(int vendedorId)
        {
            try
            {
                var productoService = new ProductoService();
                var respuesta = await productoService.ObtenerProductosPorVendedor(vendedorId);



                dataGridViewProductos.DataSource = respuesta.Productos;


                if (dataGridViewProductos.Columns.Contains("ProductoId"))
                    dataGridViewProductos.Columns["ProductoId"].Visible = false;

                if (dataGridViewProductos.Columns.Contains("VendedorId"))
                    dataGridViewProductos.Columns["VendedorId"].Visible = false;

                if (dataGridViewProductos.Columns.Contains("NombreVendedor"))
                    dataGridViewProductos.Columns["NombreVendedor"].Visible = false;

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
            ofdProducto.FileName = string.Empty;
            cmbCategoria.SelectedIndex = 0;  // Desmarcar la categoría seleccionada

            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
            }
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "Precio de Compra";
            }
            if (txtStock.Text == "")
            {
                txtStock.Text = "Stock";
            }


            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripcion";
            }

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

        string rutaImagenOriginal = string.Empty; // Variable global para almacenar la ruta original

        private void dataGridViewProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridViewProductos.SelectedRows[0];

                // Asignar valores a los controles
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                txtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value?.ToString() ?? string.Empty;
                txtPrecio.Text = filaSeleccionada.Cells["Precio"].Value?.ToString() ?? string.Empty;
                txtStock.Text = filaSeleccionada.Cells["Stock"].Value?.ToString() ?? string.Empty;

                // Asignar categoría al ComboBox
                if (filaSeleccionada.Cells["CategoriaNombre"] != null)
                {
                    cmbCategoria.Text = filaSeleccionada.Cells["CategoriaNombre"].Value?.ToString() ?? string.Empty;
                }

                // Obtener la ruta relativa de la imagen
                rutaImagenOriginal = filaSeleccionada.Cells["RutaImagen"].Value?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(rutaImagenOriginal) && File.Exists(rutaImagenOriginal))
                {
                    picBoxProducto.Image = Image.FromFile(rutaImagenOriginal); // Cargar directamente la ruta relativa
                    ofdProducto.FileName = rutaImagenOriginal; // Mantener la ruta original en el OpenFileDialog
                }
                else
                {
                    picBoxProducto.Image = null; // O usar una imagen por defecto
                    ofdProducto.FileName = string.Empty;
                }
            }
        }




        private void btnVaciar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private string ValidarCamposProducto()
        {
            // Validación de campos vacíos o inválidos
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                return "El nombre del producto no puede estar vacío.";
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                return "La descripción del producto no puede estar vacía.";
            }

            if (string.IsNullOrEmpty(txtPrecio.Text.Trim()) || !decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio))
            {
                return "El precio del producto debe ser un valor válido.";
            }

            // Validación de que el precio no sea menor que 0
            if (precio <= 0)
            {
                return "El precio del producto no puede ser menor o igual que 0.";
            }

            if (string.IsNullOrEmpty(txtStock.Text.Trim()) || !int.TryParse(txtStock.Text.Trim(), out int stock))
            {
                return "El stock del producto debe ser un número válido.";
            }

            // Validación de que el stock no sea menor que 0
            if (stock <= 0)
            {
                return "El stock del producto no puede ser menor o igual que 0.";
            }

            // Validación de la imagen
            if (ofdProducto.FileName == string.Empty)
            {
                return "Por favor, selecciona una imagen para el producto.";
            }

            // Validación de categoría
            var categoriaId = (int)cmbCategoria.SelectedValue;
            if (categoriaId == 0)
            {
                return "Por favor, selecciona una categoría.";
            }

            // Si todo está correcto, retornar null
            return null;
        }

            private async void btnRegistrar_Click(object sender, EventArgs e)
            {
                try
                {
                    // Validar campos antes de registrar el producto
                    string mensajeError = ValidarCamposProducto();
                    if (mensajeError != null)
                    {
                        MessageBox.Show(mensajeError, "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

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

                    if (categoriaId == 0) // Verificar si no se ha seleccionado una categoría válida
                    {
                        MessageBox.Show("Por favor, selecciona una categoría.", "Categoría no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verificar si ya existe un producto con el mismo nombre y la misma imagen
                    var productoService = new ProductoService();
                    

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

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProductos.SelectedRows.Count > 0)
                {
                    

                    // Obtener el ProductoId
                    int productoId = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ProductoId"].Value);
                    // Validar campos
                    string mensajeError = ValidarCamposProducto();
                    if (mensajeError != null)
                    {
                        MessageBox.Show(mensajeError, "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Usar la ruta de la imagen original si no se cambió
                    string rutaImagen = rutaImagenOriginal;

                        // Si se seleccionó una nueva imagen
                        if (!string.IsNullOrEmpty(ofdProducto.FileName) && ofdProducto.FileName != rutaImagenOriginal)
                        {
                            // Convertir la ruta absoluta del OpenFileDialog a relativa
                            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            rutaImagen = GetRelativePath(appDirectory, ofdProducto.FileName);
                        }

                        var producto = new ModificarProductoRequest()
                        {
                            ProductoId = productoId,
                            Nombre = txtNombre.Text,
                            Descripcion = txtDescripcion.Text,
                            Precio = Convert.ToDecimal(txtPrecio.Text),
                            Stock = Convert.ToInt32(txtStock.Text),
                            RutaImagen = rutaImagen, // Guardar ruta relativa
                            CategoriaId = (int)cmbCategoria.SelectedValue
                        };

                        var productoService = new ProductoService();
                        var respuesta = await productoService.ModificarProducto(producto);

                        if (respuesta.Exitoso)
                        {
                            CargarProductosDelVendedor(UsuarioId); // Refrescar
                            MessageBox.Show("Producto modificado correctamente.");
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar el producto.");
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



        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProductos.SelectedRows.Count > 0)
                {

                    // Obtén el ProductoId de la fila seleccionada
                    int productoId = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ProductoId"].Value);

                    var confirmacion = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este producto?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmacion == DialogResult.Yes)
                    {
                        var productoService = new ProductoService();
                        var respuesta = await productoService.EliminarProducto(productoId);

                        if (respuesta.Exitoso)
                        {
                            CargarProductosDelVendedor(UsuarioId);
                            MessageBox.Show($"{respuesta.Mensaje}");
                            // Refrescar el DataGridView después de la eliminación
                            
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show($"Error al eliminar el producto: {respuesta.Mensaje}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un producto de la tabla para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al eliminar el producto: {ex.Message}");
            }
        }



            private async void RevisarStockBajoPorVendedor(int UsuarioId)
            {
                // Obtener la respuesta completa
                var respuesta = await new ProductoService().ObtenerProductosConStockBajoPorVendedorAsync(UsuarioId);


                if (respuesta.Exitoso && respuesta.Productos != null && respuesta.Productos.Any())
                {
                    foreach (var producto in respuesta.Productos)
                    {

                        MostrarNotificacion($"Stock bajo: {producto.NombreProducto}", $"Quedan {producto.Stock} unidades.");
                    }
                }
                else
                {
                    Console.WriteLine($"No hay productos con stock bajo o hubo un problema: {respuesta.Mensaje}");
                }
            }


            private void MostrarNotificacion(string titulo, string mensaje)
            {
                NotifyIcon notifyIcon = new NotifyIcon
                {
                    Icon = SystemIcons.Warning, // Cambia el icono si lo prefieres
                    Visible = true,
                    BalloonTipTitle = titulo,
                    BalloonTipText = mensaje
                };

                notifyIcon.ShowBalloonTip(3000); // Mostrar la notificación durante 3 segundos
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
            label2.BackColor = Color.Transparent;
            label2.Parent = panel4;
            label2.Invalidate(); // Redibuja el control
            label3.BackColor = Color.Transparent;
            label3.Parent = panel4;
            label3.Invalidate(); // Redibuja el control
            label4.BackColor = Color.Transparent;
            label4.Parent = panel4;
            label4.Invalidate(); // Redibuja el control
            label6.BackColor = Color.Transparent;
            label6.Parent = panel4;
            label6.Invalidate(); // Redibuja el control
            label5.BackColor = Color.Transparent;
            label5.Parent = panel4;
            label5.Invalidate(); // Redibuja el control



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

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "Precio de Compra")
            {
                txtPrecio.Text = "";

            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "Precio de Compra";
            }
        }

        private void txtStock_Enter(object sender, EventArgs e)
        {
            if (txtStock.Text == "Stock")
            {
                txtStock.Text = "";
            }
        }

        private void txtStock_Leave(object sender, EventArgs e)
        {
            if (txtStock.Text == "")
            {
                txtStock.Text = "Stock";
            }
        }





        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripcion")
            {
                txtDescripcion.Text = "";
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripcion";
            }
        }

        private void toolStripGananciasForm_Click(object sender, EventArgs e)
        {
            Ganancias formGanancias = new Ganancias(UsuarioId);  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            formGanancias.ShowDialog();
        }
    }

}
