using ApiAgrodelis.Datos;
using Microsoft.AspNetCore.Mvc;
using ApiAgrodelis.Models;
using Newtonsoft.Json;

namespace ApiAgrodelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public List<Producto> ObtenerTodosLosProductos()
        {
            return new Db().ObtenerTodosLosProductos();
        }

        [HttpPost]
        [Route("update")]
        public object ActualizarStockProductos([FromBody] List<ProductoRequest> productos)
        {
            Console.WriteLine("Datos recibidos: ");
            try
            {
                // Verificar si la lista no está vacía
                if (productos == null || productos.Count == 0)
                {
                    return new
                    {
                        titulo = "Error al actualizar",
                        mensaje = "No se enviaron productos para actualizar.",
                        code = 400
                    };
                }
                // Verificar los datos que llegan al servidor
                Console.WriteLine("Datos recibidos: " + JsonConvert.SerializeObject(productos));

                foreach (var producto in productos)
                {
                    // Lógica para actualizar el stock en la base de datos
                    var productoDb = new Db().ObtenerProductoPorId(producto.ProductoId);
                    if (productoDb != null && producto.Cantidad > 0)
                    {
                        productoDb.Stock -= producto.Cantidad; // Resta la cantidad solicitada
                        new Db().ActualizarProducto(productoDb); // Actualiza el producto en la base de datos
                    }
                }

                return new
                {
                    titulo = "Éxito al actualizar",
                    mensaje = "Stock actualizado correctamente",
                    code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    titulo = "Error al actualizar",
                    mensaje = ex.Message,
                    code = 500
                };
            }
        }





    }
}
