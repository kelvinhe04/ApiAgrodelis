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
using System.Net.Http;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgrodelisForm
{
    public partial class FormAdmin : Form
    {

        private int vendedorIdSeleccionado;

        public FormAdmin()
        {
            InitializeComponent();
            CargarTodosVendedores();
            AplicarEstiloLabel();
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
                dgvVendedores.DataSource = vendedores; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }












        //Nombres dentro del txt
        
        private void txtNombre_Enter_1(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave_1(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
            }
        }
        private void txtEmail_Enter_1(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
            }
        }
        private void txtEmail_Leave_1(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
            }
        }


        private void txtContraseña_Leave_1(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
            }
        }
        private void txtContraseña_Enter_1(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
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
        private string ValidarCamposVendedor()
        {
            // Verificar si los campos requeridos están vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                return "El nombre es obligatorio.";
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
                return "La contraseña es obligatoria.";
            if (cmbRol.SelectedIndex == -1) // Verificar si no se ha seleccionado un rol
                return "El rol es obligatorio.";

            // Validar que el objetivo de venta sea un número entero
            if (string.IsNullOrWhiteSpace(txtObjetivoDeVenta.Text) || !int.TryParse(txtObjetivoDeVenta.Text.Trim(), out _))
                return "El objetivo de venta debe ser un número entero válido.";

            // Validar que el lugar de venta sea un número entero
            if (string.IsNullOrWhiteSpace(txtLugarDeVenta.Text) || !int.TryParse(txtLugarDeVenta.Text.Trim(), out _))
                return "El lugar de ventas debe ser un número entero válido.";

            
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return "El email es obligatorio.";

            return null; // Si no hay errores
        }

        private void LimpiarCampos()
        {
            // Limpiar los TextBox
            txtNombre.Clear();
            txtContraseña.Clear();
            txtObjetivoDeVenta.Clear();
            txtLugarDeVenta.Clear();
            textMotivo.Clear();
            textDuracion.Clear();
            txtEmail.Clear();

            // Desmarcar el CheckBox de activo
            checkBoxActivo.Checked = false;

            // Restablecer el ComboBox de rol (si aplica)
            cmbRol.SelectedIndex = -1; // Resetea la selección (deja el ComboBox vacío)
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
            }
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
            }

            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
            }
        }
        private void CargarRoles()
        {
            // Llenar el ComboBox solo con un rol: "Vendedor"
            cmbRol.Items.Clear();  // Limpiar cualquier valor previo
            cmbRol.Items.Add("Vendedor");  // Solo un valor posible
            cmbRol.SelectedIndex = 0;  // Establecer "Vendedor" como valor seleccionado por defecto
        }

        
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos antes de registrar el vendedor
                string mensajeError = ValidarCamposVendedor();
                if (mensajeError != null)
                {
                    MessageBox.Show(mensajeError, "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Leer los datos del vendedor desde los TextBox
                var nombre = txtNombre.Text.Trim();
                var contrasena = txtContraseña.Text.Trim();

                // Verificar que el rol esté seleccionado y sea "Vendedor"
                var rol = cmbRol.SelectedItem?.ToString().Trim();
                if (rol != "Vendedor")
                {
                    MessageBox.Show("El rol seleccionado debe ser 'Vendedor'.", "Rol incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var activo = checkBoxActivo.Checked;
                var objetivoVenta = int.Parse(txtObjetivoDeVenta.Text.Trim());
                var lugarDeVentas = int.Parse(txtLugarDeVenta.Text.Trim());
                var motivo = textMotivo.Text.Trim();
                var duracion = textDuracion.Text.Trim();
                var email = txtEmail.Text.Trim();
                // Validar formato de correo electrónico
                if (!EsCorreoValido(email))
                {
                    MessageBox.Show("Por favor, ingrese un correo electrónico válido", "Correo Inválido");
                    return;
                }
                // Verificar si ya existe un vendedor con el mismo email (opcional)
                var vendedorService = new VendedorService();

                // Crear el objeto de solicitud para registrar el vendedor
                var vendedorRequest = new VendedorRequest
                {
                    Nombre = nombre,
                    Contrasena = contrasena,
                    Rol = rol,  // El rol ahora es "Vendedor"
                    Activo = activo,
                    ObjetivoVenta = objetivoVenta,
                    LugarDeVentas = lugarDeVentas,
                    Motivo = motivo,
                    Duracion = duracion,
                    Email = email,
                };

                // Llamar al servicio para registrar el vendedor
                var respuesta = await vendedorService.RegistrarVendedor(vendedorRequest);

                if (respuesta.Exitoso)
                {
                    CargarTodosVendedores();
                    MessageBox.Show("Vendedor registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"Error al registrar el vendedor: {respuesta.Mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensajeError = ValidarCamposVendedor();
                if (mensajeError != null)
                {
                    MessageBox.Show(mensajeError, "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validar formato de correo electrónico
                if (!EsCorreoValido(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Por favor, ingrese un correo electrónico válido", "Correo Inválido");
                    return;
                }
                var vendedorRequest = new VendedorRequest
                {
                    VendedorId = vendedorIdSeleccionado, // Utiliza la variable de clase para el ID
                    Nombre = txtNombre.Text.Trim(),
                    Contrasena = txtContraseña.Text.Trim(),
                    Rol = cmbRol.SelectedItem.ToString().Trim(),
                    Activo = checkBoxActivo.Checked,
                    ObjetivoVenta = int.Parse(txtObjetivoDeVenta.Text.Trim()),
                    LugarDeVentas = int.Parse(txtLugarDeVenta.Text.Trim()),
                    Motivo = textMotivo.Text.Trim(),
                    Duracion = textDuracion.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                var vendedorService = new VendedorService();
                var respuesta = await vendedorService.ModificarVendedor(vendedorRequest);

                if (respuesta != null && respuesta.Exitoso)
                {
                    CargarTodosVendedores();
                    MessageBox.Show("Vendedor modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else if (respuesta == null)
                {
                    MessageBox.Show("No se recibió respuesta del servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error al modificar el vendedor: {respuesta.Mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVendedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVendedores.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvVendedores.SelectedRows[0];

                // Asignar el ID del vendedor para futuras operaciones
                vendedorIdSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["VendedorId"].Value);


                // Asignar valores a los controles
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                txtContraseña.Text = filaSeleccionada.Cells["Contraseña"].Value?.ToString() ?? string.Empty; // Si la contraseña se muestra
                cmbRol.Text = filaSeleccionada.Cells["Rol"].Value?.ToString() ?? string.Empty;
                checkBoxActivo.Checked = filaSeleccionada.Cells["Activo"].Value != null && Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);
                txtObjetivoDeVenta.Text = filaSeleccionada.Cells["ObjetivoVenta"].Value?.ToString() ?? string.Empty;
                txtLugarDeVenta.Text = filaSeleccionada.Cells["LugarDeVentas"].Value?.ToString() ?? string.Empty;
                textMotivo.Text = filaSeleccionada.Cells["Motivo"].Value?.ToString() ?? string.Empty;
                textDuracion.Text = filaSeleccionada.Cells["Duracion"].Value?.ToString() ?? string.Empty;
                txtEmail.Text = filaSeleccionada.Cells["Email"].Value?.ToString() ?? string.Empty;
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendedores.SelectedRows.Count > 0)
                {
                    // Obtén el VendedorId de la fila seleccionada
                    int vendedorId = Convert.ToInt32(dgvVendedores.SelectedRows[0].Cells["VendedorId"].Value);

                    var confirmacion = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este vendedor?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmacion == DialogResult.Yes)
                    {
                        var vendedorService = new VendedorService();
                        var respuesta = await vendedorService.EliminarVendedor(vendedorId);

                        if (respuesta.Exitoso)
                        {
                            CargarTodosVendedores(); // Refrescar la lista de vendedores
                            MessageBox.Show($"{respuesta.Mensaje}");
                            LimpiarCampos(); // Limpiar los campos de entrada
                        }
                        else
                        {
                            MessageBox.Show($"Error al eliminar el vendedor: {respuesta.Mensaje}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un vendedor de la tabla para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al eliminar el vendedor: {ex.Message}");
            }
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

            label11.BackColor = Color.Transparent;
            label11.Parent = panel4;
            label11.Invalidate(); // Redibuja el control

            label12.BackColor = Color.Transparent;
            label12.Parent = panel4;
            label12.Invalidate(); // Redibuja el control

            label16.BackColor = Color.Transparent;
            label16.Parent = panel4;
            label16.Invalidate(); // Redibuja el control



        }
        // Método para validar el formato del correo electrónico
        private bool EsCorreoValido(string email)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patronCorreo);
        }


    }
}
