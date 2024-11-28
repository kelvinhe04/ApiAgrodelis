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

            // Validar las credenciales
            if (db.ValidarUsuario(loginRequest.Email, loginRequest.Contraseña))
            {
                // Obtener el rol si las credenciales son válidas
                var rol = db.ObtenerRolPorEmail(loginRequest.Email);

                if (!string.IsNullOrEmpty(rol))
                {
                    return new
                    {
                        titulo = "Login exitoso",
                        mensaje = "Usuario autenticado correctamente",
                        code = 200,
                        usuario = new
                        {
                            email = loginRequest.Email,
                            rol = rol
                        }
                    };
                }
            }

            return new
            {
                titulo = "Error de autenticación",
                mensaje = "El correo o la contraseña son incorrectos",
                code = 401
            };
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
            // Verificar si el email ya está registrado
            var usuarioExistente = new Db().ValidarUsuario(registerRequest.Email, registerRequest.Contraseña);
            if (usuarioExistente != null)
            {
                return new
                {
                    titulo = "Error al registrar",
                    mensaje = "El correo electrónico ya está registrado.",
                    code = 409
                };
            }

            var usuarioCreado = new Db().RegistrarUsuario(registerRequest.Nombre, registerRequest.Email, registerRequest.Contraseña, registerRequest.Rol);
            if (usuarioCreado > 0)
            {
                return new
                {
                    titulo = "Registro exitoso",
                    mensaje = "Usuario registrado correctamente.",
                    code = 200
                };
            }

            return new
            {
                titulo = "Error al registrar",
                mensaje = "Hubo un error al registrar al usuario.",
                code = 400
            };
        }
    }
}
