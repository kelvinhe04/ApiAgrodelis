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
    public partial class FormLogin : Form
    {
        AuthenticationService authenticationService;

        public FormLogin()
        {
            InitializeComponent();
            authenticationService = new AuthenticationService();

        }


        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Crear el request para el login
                var loginRequest = new LoginRequest
                {
                    Email = txtNombre.Text.Trim(),
                    Contraseña = txtContrasena.Text.Trim()
                };

                // Enviar el request al servicio de autenticación
                var respuesta = await authenticationService.Login(loginRequest);

                // Manejar la respuesta
                if (respuesta.Exitoso)
                {
                    // Login exitoso: ahora obtenemos el rol del usuario
                    var rol = await authenticationService.ObtenerRol(loginRequest.Email);

                    if (!string.IsNullOrEmpty(rol))
                    {
                        // Verificar el rol del usuario
                        if (rol == "Admin")
                        {
                            // Redirigir al formulario de administración
                            MessageBox.Show("¡Bienvenido, Administrador!", "Login Exitoso");
                            var formAdmin = new FormAdmin();
                            formAdmin.Show();
                            this.Hide(); // Ocultar el formulario actual
                        }
                        else if (rol == "Vendedor")
                        {
                            // Redirigir al formulario del vendedor
                            MessageBox.Show("¡Bienvenido, Vendedor!", "Login Exitoso");
                            var formVendedor = new FormVendedor();
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
                        MessageBox.Show("Error: El rol del usuario no se pudo determinar. Contacta al soporte.", "Error");
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
                lblMensajeRegistro.Text = "Por favor, complete todos los campos.";
                return;
            }

            // Crear un objeto RegisterRequest con los datos del formulario
            var registerRequest = new RegisterRequest
            {
                Nombre = nombre,
                Email = email,
                Contraseña = contraseña,
                Rol = "Vendedor",  // Aquí asignas el rol de "Vendedor" o "Cliente", según el caso
            };

            try
            {
                // Llamar al método Register de AuthenticationService
                var respuesta = await authenticationService.Register(registerRequest);

                if (respuesta.Exitoso)
                {
                    lblMensajeRegistro.Text = "¡Registro exitoso!";
                }
                else
                {
                    lblMensajeRegistro.Text = $"Error: {respuesta.Mensaje}";
                }
            }
            catch (Exception ex)
            {
                lblMensajeRegistro.Text = $"Error interno: {ex.Message}";
            }

        }
    }
}
