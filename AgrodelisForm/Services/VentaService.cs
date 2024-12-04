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
    public class VentaService
    {
        private readonly HttpClient _client;

        public VentaService()
        {
            _client = new HttpClient();
        }

        // Obtener todas las ventas de un vendedor
        public async Task<Respuesta> ObtenerVentasPorVendedor(int vendedorId)
        {
            try
            {
                var respuesta = await _client.GetAsync($"https://localhost:7156/api/ventas/{vendedorId}");
                var contenido = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = "Error al obtener las ventas.",
                    Code = 500
                };
            }
        }

        public async Task<Respuesta> ObtenerTodasLasVentas()
        {
            try
            {
                var respuesta = await _client.GetAsync("https://localhost:7156/api/ventas/todas");
                var contenido = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = "Error al obtener todas las ventas.",
                    Code = 500
                };
            }
        }

    }



}
