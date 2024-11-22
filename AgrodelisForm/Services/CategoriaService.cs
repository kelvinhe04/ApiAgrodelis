//using AgrodelisForm.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;


//namespace AgrodelisForm.Services
//{
//    public class CategoriaService
//    {
//        public async Task<List<Categoria>> ObtenerTodosLasCategorias()
//        {
//            HttpClient client = new HttpClient();
//            var respuesta = await client.GetAsync("https://localhost:7217/api/categorias/all");

//            return JsonConvert.DeserializeObject<List<Categoria>>(respuesta.Content.ReadAsStringAsync().Result);
//        }

//        public async Task<Respuesta> EnviarGuardarCategoria(CategoriaRequest categoria)
//        {
//            HttpClient client = new HttpClient();

//            var datos = JsonConvert.SerializeObject(categoria);
//            var data = new StringContent(datos, Encoding.UTF8, "application/json");
//            var respuesta = await client.PostAsync("https://localhost:7217/api/categorias/save", data);

//            return JsonConvert.DeserializeObject<Respuesta>(respuesta.Content.ReadAsStringAsync().Result);
//        }

//        public async Task<Respuesta> EnviarEditarCategoria(int id, CategoriaRequest categoria)
//        {
//            HttpClient client = new HttpClient();

//            var datos = JsonConvert.SerializeObject(categoria);
//            var data = new StringContent(datos, Encoding.UTF8, "application/json");
//            var respuesta = await client.PostAsync("https://localhost:7217/api/categorias/edit/" + id, data);

//            return JsonConvert.DeserializeObject<Respuesta>(respuesta.Content.ReadAsStringAsync().Result);
//        }

//        public async Task<Respuesta> EliminarCategoria(int categoriaId)
//        {
//            HttpClient client = new HttpClient();
//            var respuesta = await client.DeleteAsync("https://localhost:7217/api/categorias/" + categoriaId);

//            return JsonConvert.DeserializeObject<Respuesta>(respuesta.Content.ReadAsStringAsync().Result);
//        }
//    }
//}
