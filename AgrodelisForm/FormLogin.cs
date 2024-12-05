using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgrodelisForm.Models;
using AgrodelisForm.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgrodelisForm
{
    public partial class FormLogin : Form
    {
        AuthenticationService authenticationService;

        public FormLogin()
        {
            InitializeComponent();
            authenticationService = new AuthenticationService();

            panelRegistrar.Visible = false;

            //FormVendedor formVendedor = new FormVendedor(31);  // Pasamos el UsuarioId
            //this.Hide(); // Ocultar el formulario actua
            //formVendedor.ShowDialog();

            //Ganancias formGanancias = new Ganancias(32);  // Pasamos el UsuarioId
            //this.Hide(); // Ocultar el formulario actua
            //formGanancias.ShowDialog();

            //GananciasTotales formGananciastotal = new GananciasTotales();  // Pasamos el UsuarioId
            //this.Hide(); // Ocultar el formulario actua
            //formGananciastotal.ShowDialog();

                //FormAdmin FormAdmin = new FormAdmin();  // Pasamos el UsuarioId
                //this.Hide(); // Ocultar el formulario actua
                //FormAdmin.ShowDialog();

            //Inventario Inventario = new Inventario();  // Pasamos el UsuarioId
            //this.Hide(); // Ocultar el formulario actua
            //Inventario.ShowDialog();
        }


        private async void btnLogin_Click_1(object sender, EventArgs e)
        {

            string email = txtEmailLogin.Text.Trim();
            string contraseña = txtContraLogin.Text.Trim();

            try
            {

                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, complete todos los campos", "Campos Vacios");
                    return;
                }
                // Validar formato de correo electrónico
                if (!EsCorreoValido(email))
                {
                    MessageBox.Show("Por favor, ingrese un correo electrónico válido", "Correo Inválido");
                    return;
                }

                // Crear el request para el login
                var loginRequest = new LoginRequest
                {
                    Email = txtEmailLogin.Text.Trim(),
                    Contraseña = txtContraLogin.Text.Trim()
                };

                // Enviar el request al servicio de autenticación
                var respuesta = await authenticationService.Login(loginRequest);



                // Manejar la respuesta
                if (respuesta.Exitoso)
                {
                    // Guardar los datos del usuario logueado en la sesión (variable estática)
                    SesionUsuario.UsuarioId = respuesta.Datos.UsuarioId;  // ID del vendedor
                    string nombreUsuario = respuesta.Datos.Nombre; // Obtener el nombre del vendedor desde la respuesta
                    string rol = respuesta.Datos.Rol;

                    if (!string.IsNullOrEmpty(rol))
                    {
                        // Verificar el rol del usuario
                        if (rol == "Admin")
                        {
                            // Redirigir al formulario de administración
                            MessageBox.Show($"¡Bienvenido, Administrador!", "Login Exitoso");
                            var formAdmin = new FormAdmin();
                            formAdmin.Show();
                            this.Hide(); // Ocultar el formulario actual
                        }
                        else if (rol == "Vendedor")
                        {
                            // Redirigir al formulario del vendedor
                            MessageBox.Show($"¡Bienvenido, Vended@r {nombreUsuario}!", "Login Exitoso");
                            var formVendedor = new FormVendedor(SesionUsuario.UsuarioId);  // Pasamos el UsuarioId
                            formVendedor.Show();
                            this.Hide(); // Ocultar el formulario actual
                        }
                        else
                        {
                            // Manejar roles no reconocidos
                            MessageBox.Show($"Rol '{rol}' no reconocido. Por favor, contacta al soporte.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El rol del usuario no se pudo determinar", "Error");
                    }
                }
                else
                {
                    // Mostrar mensaje de error devuelto por la API
                    MessageBox.Show(respuesta.Mensaje, "Error al iniciar sesión");
                }

            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error Interno");
            }
        }




        // Evento de clic para registrar un usuario


        private async void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtUsuarioRegistrar.Text.Trim();
            string email = txtEmailRegistrar.Text.Trim();
            string contraseña = txtContraRegistrar.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Campos Vacíos");
                return;
            }

            // Validar formato de correo electrónico
            if (!EsCorreoValido(email))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido", "Correo Inválido");
                return;
            }

            // Crear un objeto RegisterRequest con los datos del formulario
            var registerRequest = new RegisterRequest
            {
                Nombre = nombre,
                Email = email,
                Contraseña = contraseña,
                Rol = "Vendedor", // Aquí asignas el rol de "Vendedor" o "Cliente", según el caso
            };

            try
            {
                // Llamar al método Register de AuthenticationService
                var respuesta = await authenticationService.Register(registerRequest);


                if (respuesta.Exitoso)
                {
                    MessageBox.Show("¡Registro exitoso!", "Éxito");
                    panelLogin.Visible = true;
                    panelRegistrar.Visible = false;
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje, "Error");
                    if (respuesta.Mensaje == "El correo electrónico ya está registrado.")
                    {
                        panelLogin.Visible = true;
                        panelRegistrar.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error interno: {ex.Message}", "Error");
            }
        }

        // Método para validar el formato del correo electrónico
        private bool EsCorreoValido(string email)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patronCorreo);
        }


        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }



        private void lblIniciarSesion_Click(object sender, EventArgs e)
        {
            txtUsuarioRegistrar.Clear();
            txtEmailRegistrar.Clear();
            txtContraRegistrar.Clear();
            panelLogin.Visible = true;
            panelRegistrar.Visible = false;


        }

        private void lblRegistrate_Click(object sender, EventArgs e)
        {
            txtEmailLogin.Clear();
            txtContraLogin.Clear();
            panelLogin.Visible = false;
            panelRegistrar.Visible = true;
        }

        private void txtUsuarioRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Permitir que el formulario reciba los eventos de teclado
            this.KeyPreview = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnRegistrar_Enter(object sender, EventArgs e)
        {
            string nombre = txtUsuarioRegistrar.Text.Trim();
            string email = txtEmailRegistrar.Text.Trim();
            string contraseña = txtContraRegistrar.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Campos Vacíos");
                return;
            }

            // Validar formato de correo electrónico
            if (!EsCorreoValido(email))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido", "Correo Inválido");
                return;
            }

            // Crear un objeto RegisterRequest con los datos del formulario
            var registerRequest = new RegisterRequest
            {
                Nombre = nombre,
                Email = email,
                Contraseña = contraseña,
                Rol = "Vendedor", // Aquí asignas el rol de "Vendedor" o "Cliente", según el caso
            };

            try
            {
                // Llamar al método Register de AuthenticationService
                var respuesta = await authenticationService.Register(registerRequest);


                if (respuesta.Exitoso)
                {
                    MessageBox.Show("¡Registro exitoso!", "Éxito");
                    panelLogin.Visible = true;
                    panelRegistrar.Visible = false;
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje, "Error");
                    if (respuesta.Mensaje == "El correo electrónico ya está registrado.")
                    {
                        txtUsuarioRegistrar.Clear();
                        txtEmailRegistrar.Clear();
                        txtContraRegistrar.Clear();
                        panelLogin.Visible = true;
                        panelRegistrar.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error interno: {ex.Message}", "Error");
            }
        }

        private async void btnRegistrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nombre = txtUsuarioRegistrar.Text.Trim();
            string email = txtEmailRegistrar.Text.Trim();
            string contraseña = txtContraRegistrar.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Campos Vacíos");
                return;
            }

            // Validar formato de correo electrónico
            if (!EsCorreoValido(email))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido", "Correo Inválido");
                return;
            }

            // Crear un objeto RegisterRequest con los datos del formulario
            var registerRequest = new RegisterRequest
            {
                Nombre = nombre,
                Email = email,
                Contraseña = contraseña,
                Rol = "Vendedor", // Aquí asignas el rol de "Vendedor" o "Cliente", según el caso
            };

            try
            {
                // Llamar al método Register de AuthenticationService
                var respuesta = await authenticationService.Register(registerRequest);


                if (respuesta.Exitoso)
                {
                    MessageBox.Show("¡Registro exitoso!", "Éxito");
                    panelLogin.Visible = true;
                    panelRegistrar.Visible = false;
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje, "Error");
                    if (respuesta.Mensaje == "El correo electrónico ya está registrado.")
                    {
                        panelLogin.Visible = true;
                        panelRegistrar.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error interno: {ex.Message}", "Error");
            }
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Simular el clic en el botón
                btnRegistrar.PerformClick();
                btnLogin.PerformClick();
            }
        }

    }
}
