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

            FormVendedor formVendedor = new FormVendedor(31);  // Pasamos el UsuarioId
            this.Hide(); // Ocultar el formulario actua
            formVendedor.ShowDialog();
            

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
                            MessageBox.Show($"¡Bienvenido, Vendedor {nombreUsuario}!", "Login Exitoso");
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
                MessageBox.Show("Por favor, complete todos los campos", "Campos Vacios");
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
                    MessageBox.Show("¡Registro exitoso!", "Exito");
                    
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje, "Error");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error interno: {ex.Message}", "Error");
               
            }

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        
       
        private void lblIniciarSesion_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelRegistrar.Visible = false;

        }

        private void lblRegistrate_Click(object sender, EventArgs e)
        {
            
            panelLogin.Visible = false;
            panelRegistrar.Visible = true;
        }
    }
}
