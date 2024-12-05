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

            if (string.IsNullOrWhiteSpace(textMotivo.Text))
                return "El motivo es obligatorio.";
            if (string.IsNullOrWhiteSpace(textDuracion.Text))
                return "La duración es obligatoria.";
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

            // Si el formulario tiene más controles que desees limpiar, añádelos aquí.
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

                // Verificar si ya existe un vendedor con el mismo email (opcional)
                var vendedorService = new VendedorService();

                // Crear el objeto de solicitud para registrar el vendedor
                var vendedorRequest = new RegistrarVendedorRequest
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
    }
}
