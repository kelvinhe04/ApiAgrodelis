using ApiAgrodelis.Datos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiAgrodelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : Controller
    {
        private Db _db;

        public VendedoresController()
        {
            _db = new Db();
        }
        [HttpGet]
        [Route("vendedores")]
        public object ObtenerVendedores()
        {
            try
            {
                var vendedores = _db.ObtenerVendedores(); // Método en la base de datos que obtiene los vendedores.
                return new
                {
                    Exitoso = true,
                    Vendedores = vendedores,
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener los vendedores: {ex.Message}",
                    Code = 500
                };
            }
        }


    }
}
