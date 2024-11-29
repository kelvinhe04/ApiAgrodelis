using ApiAgrodelis.Datos;
using Microsoft.AspNetCore.Mvc;
using ApiAgrodelis.Models;
using Newtonsoft.Json;


namespace ApiAgrodelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {



        [HttpPost("login")]
        public object Login([FromBody] LoginRequest loginRequest)
        {
            var db = new Db();
            try
            {
                // Validar las credenciales
                if (db.ValidarUsuario(loginRequest.Email, loginRequest.Contraseña))
                {
                    // Obtener el rol si las credenciales son válidas
                    var rol = db.ObtenerRolPorEmail(loginRequest.Email);

                    if (!string.IsNullOrEmpty(rol))
                    {
                        return new
                        {
                            Exitoso = true,
                            Mensaje = "Usuario autenticado correctamente",
                            Code = 200, // Código de éxito
                            usuario = new
                            {
                                email = loginRequest.Email,
                                rol = rol
                            }
                        };
                    }
                    else
                    {
                        // Si el rol no se encuentra, devolver error
                        return new
                        {
                            Exitoso = false,
                            Mensaje = "El rol del usuario no fue encontrado.",
                            Code = 401 // Unauthorized
                        };
                    }
                }
                else
                {
                    // Si las credenciales son incorrectas
                    return new
                    {
                        Exitoso = false,
                        Mensaje = "El correo o la contraseña son incorrectos",
                        Code = 401 // Unauthorized
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores internos
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",
                    Code = 500 // Internal Server Error
                };
            }
        }

        [HttpGet("rol")]
        public IActionResult ObtenerRol(string email)
        {
            var rol = new Db().ObtenerRolPorEmail(email);

            if (!string.IsNullOrEmpty(rol))
            {
                return Ok(rol); // Retorna el rol como string
            }

            return NotFound("Rol no encontrado");
        }







        // Endpoint de Registro
        [HttpPost("register")]
        public object Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                // Verificar si el email ya está registrado
                var emailExistente = new Db().ValidarEmail(registerRequest.Email);
                if (emailExistente)
                {
                    return new
                    {
                        Exitoso = false,
                        Mensaje = "El correo electrónico ya está registrado.",
                        Code = 409  // Conflict, ya que el email ya está registrado
                    };
                }

                // Verificar si el nombre de usuario ya está registrado
                var nombreExistente = new Db().ValidarNombreUsuario(registerRequest.Nombre);
                if (nombreExistente)
                {
                    return new
                    {
                        Exitoso = false,
                        Mensaje = "El nombre de usuario ya está en uso.",
                        Code = 409  // Conflict, ya que el nombre de usuario ya está registrado
                    };
                }

                // Si no existe, registrar el nuevo usuario
                var usuarioCreado = new Db().RegistrarUsuario(registerRequest.Nombre, registerRequest.Email, registerRequest.Contraseña, registerRequest.Rol);
                if (usuarioCreado > 0)
                {
                    return new
                    {
                        Exitoso = true,
                        Mensaje = "Usuario registrado correctamente.",
                        Code = 200  // Registro exitoso
                    };
                }

                return new
                {
                    Exitoso = false,
                    Mensaje = "Hubo un error al registrar al usuario.",
                    Code = 400  // Error al registrar
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",   
                    Code = 500  // Error del servidor
                };
            }
        }




    }
}
