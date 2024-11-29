using ApiAgrodelis.Datos;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgrodelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        
            private readonly Db _db;

            public CategoriaController()
            {
                _db = new Db();
            }

            // Obtener todas las categorías
            [HttpGet]
            public object ObtenerCategorias()
            {
                try
                {
                    var categorias = _db.ObtenerCategorias();  // Obtener las categorías desde la base de datos
                    if (categorias.Count == 0)
                    {
                        return new
                        {
                            Exitoso = false,
                            Mensaje = "No hay categorías registradas.",
                            Code = 404  // Not Found
                        };
                    }

                    return new
                    {
                        Exitoso = true,
                        Categorias = categorias,
                        Code = 200  // OK
                    };
                }
                catch (Exception ex)
                {
                    return new
                    {
                        Exitoso = false,
                        Mensaje = $"Error al obtener categorías: {ex.Message}",
                        Code = 500  // Internal Server Error
                    };
                }
            }
        }
    
}
