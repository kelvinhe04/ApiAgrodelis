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
        [HttpPut("Modificar")]
        public object ModificarProducto([FromBody] ModificarProductoRequest request)
        {
            try
            {
                var resultado = _db.ModificarProducto(request.ProductoId, request.Nombre, request.Descripcion, request.Precio, request.Stock, request.RutaImagen, request.CategoriaId);

                if (resultado > 0)
                {
                    return new
                    {
                        Exitoso = true,
                        Mensaje = "Producto modificado correctamente",
                        Code = 200 // OK
                    };
                }
                else
                {
                    return new
                    {
                        Exitoso = false,
                        Mensaje = "Hubo un error al modificar el producto",
                        Code = 400 // Bad Request
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al modificar el producto: {ex.Message}",
                    Code = 500 // Internal Server Error
                };
            }
        }

        [HttpDelete("eliminar/{productoId}")]
        public object EliminarProducto(int productoId)
        {
            try
            {
                var db = new Db();
                int resultado = db.EliminarProducto(productoId);

                if (resultado > 0)
                {
                    return new
                    {
                        Exitoso = true,
                        Mensaje = "Producto eliminado correctamente.",
                        Code = 200
                    };
                }
                else
                {
                    return new
                    {
                        Exitoso = false,
                        Mensaje = "No se encontró el producto para eliminar.",
                        Code = 404
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error interno: {ex.Message}",
                    Code = 500
                };
            }
        }

        //=================================NOTIFICACION DE ESCRITORIO CUANDO EL STOCK  ESTE BAJO=====================================
        [HttpGet("{vendedorId}/stock-bajo")]
        public object ObtenerProductosConStockBajoPorVendedor(int vendedorId)
        {
            try
            {
                // Llamada al método para obtener los productos de un vendedor con stock bajo (menos de 5 unidades)
                var productosConStockBajo = _db.ObtenerProductosConStockBajoPorVendedor(vendedorId, 5);

                return new
                {
                    Exitoso = true,
                    Productos = productosConStockBajo,
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener los productos con stock bajo: {ex.Message}",
                    Code = 500
                };
            }
        }
        //=================================INVENTARIO=====================================
        [HttpGet("inventario")]
        public object ObtenerInventarioDeTodosLosVendedores()
        {
            try
            {
                var productos = _db.ObtenerInventarioDeTodosLosVendedores();

                return new
                {
                    Exitoso = true,
                    Productos = productos,
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener el inventario: {ex.Message}",
                    Code = 500
                };
            }
        }

        [HttpGet("inventario/{vendedorId}")]
        public object ObtenerInventarioPorVendedor(int vendedorId)
        {
            try
            {
                var productos = _db.ObtenerInventarioPorVendedor(vendedorId);
                return new
                {
                    Exitoso = true,
                    Productos = productos,
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






    }
}
