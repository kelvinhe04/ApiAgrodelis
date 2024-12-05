using AgrodelisForm.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Services
{
    public class TransferenciaService
    {
        private readonly HttpClient _client;

        public TransferenciaService()
        {
            _client = new HttpClient();
        }

        // Método para realizar la transferencia de un producto
        public async Task<Respuesta> RealizarTransferencia(TransferenciaProducto request)
        {
            try
            {
                // Serializamos la solicitud en formato JSON
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                // Llamada POST a la API para registrar la transferencia
                var respuesta = await _client.PostAsync("https://localhost:7156/api/transferencias/realizar", content);
                var contenido = await respuesta.Content.ReadAsStringAsync();

                // Deserializamos la respuesta de la API
                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolvemos una respuesta con el mensaje de error
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al realizar la transferencia: {ex.Message}",
                    Code = 500
                };
            }
        }

        // Método para obtener todas las transferencias (opcional)
        public async Task<Respuesta> ObtenerTransferencias()
        {
            try
            {
                // Llamada GET a la API para obtener todas las transferencias
                var respuesta = await _client.GetAsync("https://localhost:7156/api/transferencias");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Respuesta>(contenido);
                }

                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = "Error al obtener las transferencias.",
                    Code = 500
                };
            }
            catch (Exception ex)
            {
                // Devolver error si falla la solicitud
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",
                    Code = 500
                };
            }
        }
    }
}
