using AgrodelisForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _client;

        public AuthenticationService()
        {
            _client = new HttpClient();
        }

        // Login
        public async Task<Respuesta> Login(LoginRequest loginRequest)
        {
            
            try
            {
               
                // Serializar la solicitud de login
                var datos = JsonConvert.SerializeObject(loginRequest);
                var data = new StringContent(datos, Encoding.UTF8, "application/json");

                // Enviar solicitud POST al endpoint de login
                var respuesta = await _client.PostAsync("https://localhost:7156/api/Authentication/login", data);

                // Verificar si la respuesta es exitosa
                if (respuesta.IsSuccessStatusCode)
                {
                    var content = await respuesta.Content.ReadAsStringAsync();
                    var respuestaDeserializada = JsonConvert.DeserializeObject<Respuesta>(content);

                    // Aquí no es necesario volver a asignar Exitoso = true
                    if (respuestaDeserializada.Exitoso) // Solo revisas si el servidor lo marcó como exitoso
                    {
                        string rol = await ObtenerRolUsuario(loginRequest.Email);

                        if (!string.IsNullOrEmpty(rol))
                        {
                            // Asignar el rol al usuario
                            respuestaDeserializada.Mensaje = $"El rol del usuario es: {rol}";

                            // Aquí puedes hacer algo con el rol, como redirigir a una página específica
                            return respuestaDeserializada;
                        }
                        else
                        {
                            return new Respuesta
                            {
                                Exitoso = false,
                                Mensaje = "No se pudo obtener el rol del usuario.",
                                Code = 400
                            };
                        }
                    }
                    else
                    {
                        return respuestaDeserializada; // Retorna la respuesta original si no fue exitosa
                    }
                }
                else
                {
                    return new Respuesta
                    {
                        Exitoso = false,
                        Mensaje = "Error en la respuesta del servidor.",
                        Code = 500
                    };
                }


                // Manejar error en la solicitud
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al iniciar sesión: {respuesta.ReasonPhrase}",
                    Code = (int)respuesta.StatusCode
                };
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",
                    Code = 500 // Código para errores internos del servidor
                };
            }
        }


        public async Task<string> ObtenerRolUsuario(string email)
        {
            try
            {
                // Realizar una solicitud GET para obtener el rol del usuario
                var respuesta = await _client.GetAsync($"https://localhost:7156/api/Authentication/rol?email={email}");

                if (respuesta.IsSuccessStatusCode)
                {
                    // Leer la respuesta
                    var content = await respuesta.Content.ReadAsStringAsync();
                    return content; // Se asume que la API retorna solo el rol como un string
                }

                return null; // Si no se pudo obtener el rol
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el rol: " + ex.Message);
            }
        }

        public async Task<string> ObtenerRol(string email)
        {
            try
            {
                // Crear la solicitud GET al endpoint de la API para obtener el rol
                var respuesta = await _client.GetAsync($"https://localhost:7156/api/Authentication/rol?email={email}");

                if (respuesta.IsSuccessStatusCode)
                {
                    // Leer el contenido de la respuesta
                    var content = await respuesta.Content.ReadAsStringAsync();
                    return content; // Se asume que el API devuelve solo el rol como string
                }

                return null; // Retorna null si no se pudo obtener el rol
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el rol: " + ex.Message);
            }
        }



        // Registro
        public async Task<Respuesta> Register(RegisterRequest registerRequest)
        {
            try
            {
                // Serializar la solicitud
                var datos = JsonConvert.SerializeObject(registerRequest);
                var data = new StringContent(datos, Encoding.UTF8, "application/json");

                // Enviar solicitud POST al endpoint de registro
                var respuesta = await _client.PostAsync("https://localhost:7156/api/Authentication/register", data);

                // Verificar si la respuesta es exitosa
                if (respuesta.IsSuccessStatusCode)
                {
                    var content = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Respuesta>(content);
                }

                // Manejar error en la solicitud
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al registrar: {respuesta.ReasonPhrase}",
                    Code = (int)respuesta.StatusCode // Convertir el código de estado HTTP a int
                };
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",
                    Code = 500 // Código para errores internos del servidor
                };
            }
        }

    }
}