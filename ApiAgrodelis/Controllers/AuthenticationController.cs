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
                // Verificar las credenciales
                if (db.ValidarUsuario(loginRequest.Email, loginRequest.Contraseña))
                {
                    // Obtener el rol, ID y nombre del usuario
                    var rol = db.ObtenerRolPorEmail(loginRequest.Email);
                    var usuarioId = db.ObtenerUsuarioIdPorEmail(loginRequest.Email);  // Aquí obtenemos el ID del usuario
                    var nombreUsuario = db.ObtenerNombrePorEmail(loginRequest.Email);  // Aquí obtenemos el nombre del usuario

                    if (!string.IsNullOrEmpty(rol) && usuarioId != 0 && !string.IsNullOrEmpty(nombreUsuario))
                    {
                        return new
                        {
                            Exitoso = true,
                            Mensaje = "Usuario autenticado correctamente",
                            Code = 200,
                            Datos = new
                            {
                                UsuarioId = usuarioId,  // ID del usuario
                                Nombre = nombreUsuario,  // Nombre del usuario
                                Rol = rol  // El rol del usuario (Vendedor, Admin, etc.)
                            }
                        };
                    }
                    else
                    {
                        return new
                        {
                            Exitoso = false,
                            Mensaje = "El rol o el ID del usuario no fueron encontrados.",
                            Code = 401
                        };
                    }
                }
                else
                {
                    return new
                    {
                        Exitoso = false,
                        Mensaje = "El correo o la contraseña son incorrectos",
                        Code = 401
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",
                    Code = 500
                };
            }
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
