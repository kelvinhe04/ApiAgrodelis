using AgrodelisForm.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Services
{
    public class ProductoService
    {
        private readonly HttpClient _client;

        public ProductoService()
        {
            _client = new HttpClient();
        }

        // Obtener todos los productos de un vendedor
        public async Task<Respuesta> ObtenerProductosPorVendedor(int vendedorId)
        {
            try
            {
                var respuesta = await _client.GetAsync($"https://localhost:7156/api/productos/{vendedorId}");
                var contenido = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener los productos: {ex.Message}",
                    Code = 500
                };
            }
        }

        // Registrar un nuevo producto y vincularlo con el vendedor
        public async Task<Respuesta> RegistrarProducto(RegistrarProductoRequest request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var respuesta = await _client.PostAsync("https://localhost:7156/api/Productos/registrar", content);
                var contenido = await respuesta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al registrar el producto: {ex.Message}",
                    Code = 500  // Internal Server Error
                };
            }
        }
    }
}
