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
        private Db _db;

        public ProductosController()
        {
            _db = new Db();  
        }


        //==============================FRONTEND-SOFTV================================
        [HttpGet]   
        [Route("all")]
        public List<ProductoV> ObtenerTodosLosProductos()
        {
            return new Db().ObtenerTodosLosProductos();
        }
        //==============================FRONTEND-SOFTV================================
        [HttpPost]
        [Route("update")]
        public object ActualizarStockProductos([FromBody] List<ProductoRequestV> productos)
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
                    var productoDb = new Db().ObtenerProductoPorIdV(producto.ProductoId);
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
        //=======================================================================================================================


        //=================================CRUD PARA QUE LOS VENDEDORES MANEJEN SUS PRODUCTOS=====================================

        // Endpoint para obtener los productos de un vendedor
        [HttpGet("{vendedorId}")]
        public object ObtenerProductosPorVendedor(int vendedorId)
        {
            try
            {
                var productos = _db.ObtenerProductosPorVendedor(vendedorId);  // Llamada al método para obtener los productos
                return new
                {
                    Exitoso = true,
                    Productos = productos,  // Aquí deberías devolver la lista de productos
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener los productos: {ex.Message}",
                    Code = 500
                };
            }
        }



        // Endpoint para registrar un nuevo producto
        [HttpPost("registrar")]
        public object RegistrarProducto([FromBody] RegistrarProductoRequest request)
        {
            try
            {
                var resultado = _db.RegistrarProductoYRelacion(request.Nombre, request.Descripcion, request.Precio, request.Stock, request.RutaImagen, request.CategoriaId, request.VendedorId);

                if (resultado > 0)
                {
                    return new
                    {
                        Exitoso = true,
                        Mensaje = "Producto registrado correctamente.",
                        Code = 200  // OK
                    };
                }
                else
                {
                    return new
                    {
                        Exitoso = false,
                        Mensaje = "Hubo un error al registrar el producto.",
                        Code = 400  // Bad Request
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al registrar el producto: {ex.Message}",
                    Code = 500  // Internal Server Error
                };
            }
        }

    }
}
