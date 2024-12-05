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
    }
}
