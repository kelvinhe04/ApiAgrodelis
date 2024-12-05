using AgrodelisForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                    Mensaje = "Error al obtener los productos!",
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
        public async Task<Respuesta> ModificarProducto(ModificarProductoRequest request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                // Asumiendo que la URL del API está configurada correctamente
                var respuesta = await _client.PutAsync($"https://localhost:7156/api/Productos/Modificar", content);
                var contenido = await respuesta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al modificar el producto: {ex.Message}",
                    Code = 500 // Internal Server Error
                };
            }
        }
        // Método para eliminar un producto
        public async Task<Respuesta> EliminarProducto(int productoId)
        {
            try
            {
                var respuesta = await _client.DeleteAsync($"https://localhost:7156/api/Productos/eliminar/{productoId}");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Respuesta>(contenido);
                }

                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = "Error al eliminar el producto.",
                    Code = 500
                };
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",
                    Code = 500
                };
            }
        }


        // INVENTARIO DE TODOS LOS VENDEDORES
        public async Task<Respuesta> ObtenerInventarioDeTodosLosVendedores()
        {
            try
            {
                var respuesta = await _client.GetAsync("https://localhost:7156/api/Productos/inventario");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Respuesta>(contenido);
                }

                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = "Error al obtener el inventario.",
                    Code = 500
                };
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",
                    Code = 500
                };
            }
        }
        public async Task<Respuesta> ObtenerInventarioPorVendedor(int vendedorId)
        {
            try
            {
                var respuesta = await _client.GetAsync($"https://localhost:7156/api/Productos/inventario/{vendedorId}");
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


        // NOTIFICACION DE STOCK BAJO
        public async Task<Respuesta> ObtenerProductosConStockBajoPorVendedorAsync(int vendedorId)
        {
            try
            {
                // URL de la API para obtener productos con stock bajo de un vendedor
                var url = $"https://localhost:7156/api/productos/{vendedorId}/stock-bajo";  // Ajusta la URL según tu dominio

                // Realizar la solicitud GET
                var respuesta = await _client.GetAsync(url);

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();

                    // Deserializar el contenido a la clase Respuesta
                    return JsonConvert.DeserializeObject<Respuesta>(contenido);
                }

                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = "Error al obtener productos con stock bajo.",
                    Code = (int)respuesta.StatusCode
                };
            }
            catch (Exception ex)
            {
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

