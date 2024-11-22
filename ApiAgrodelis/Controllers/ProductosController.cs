using ApiAgrodelis.Datos;
using Microsoft.AspNetCore.Mvc;
using ApiAgrodelis.Models;

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
    }
}
