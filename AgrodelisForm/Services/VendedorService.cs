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
    public class VendedorService
    {
        private readonly HttpClient _client;

        public VendedorService()
        {
            _client = new HttpClient();
        }

        public async Task<Respuesta> ObtenerVendedores()
        {
            try
            {
                var respuesta = await _client.GetAsync("https://localhost:7156/api/vendedores/vendedores");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Respuesta>(contenido);
                }

                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = "Error al obtener los vendedores.",
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
            public async Task<Respuesta> ObtenerTodosVendedores()
            {
                try
                {
                    var respuesta = await _client.GetAsync("https://localhost:7156/api/vendedores/vendedores/todos");

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var contenido = await respuesta.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Respuesta>(contenido);
                    }

                    return new Respuesta
                    {
                        Exitoso = false,
                        Mensaje = "Error al obtener los vendedores.",
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


        public async Task<Respuesta> RegistrarVendedor(VendedorRequest request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var respuesta = await _client.PostAsync("https://localhost:7156/api/Vendedores/registrar", content);
                var contenido = await respuesta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al registrar el vendedor: {ex.Message}",
                    Code = 500
                };
            }
        }
        public async Task<Respuesta> ModificarVendedor(VendedorRequest request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var respuesta = await _client.PostAsync("https://localhost:7156/api/Vendedores/modificar", content);
                var contenido = await respuesta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al modificar el vendedor: {ex.Message}",
                    Code = 500  // Internal Server Error
                };
            }
        }
        public async Task<Respuesta> EliminarVendedor(int vendedorId)
        {
            try
            {
                var respuesta = await _client.DeleteAsync($"https://localhost:7156/api/Vendedores/eliminar/{vendedorId}");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Respuesta>(contenido);
                }

                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = "Error al eliminar el vendedor.",
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

    }
}
