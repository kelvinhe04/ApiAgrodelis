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
    public class CategoriaService
    {
        private readonly HttpClient _client;

        public CategoriaService()
        {
            _client = new HttpClient();
        }

        // Método para obtener las categorías
        public async Task<Respuesta> ObtenerCategorias()
        {
            try
            {
                var respuesta = await _client.GetAsync("https://localhost:7156/api/Categoria");
                var contenido = await respuesta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Respuesta>(contenido);
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener las categorías: {ex.Message}",
                    Code = 500
                };
            }
        }
    }

}
