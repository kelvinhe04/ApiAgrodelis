using ApiAgrodelis.Models;
using Microsoft.AspNetCore.Mvc;
using ApiAgrodelis.Datos;
using Newtonsoft.Json;
namespace ApiAgrodelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private Db _db;

        public VentasController()
        {
            _db = new Db();
        }

        //============================== FRONTEND-SOFTV =====================================
        [HttpPost]
        [Route("registrar")]
        public object RegistrarVentas([FromBody] List<VentaRequest> ventas)
        {
            Console.WriteLine("Datos recibidos para registrar ventas: ");
            try
            {
                // Verificar si la lista no está vacía
                if (ventas == null || ventas.Count == 0)
                {
                    return new
                    {
                        titulo = "Error al registrar ventas",
                        mensaje = "No se enviaron ventas para registrar.",
                        code = 400
                    };
                }

                // Verificar los datos que llegan al servidor
                Console.WriteLine("Datos recibidos: " + JsonConvert.SerializeObject(ventas));

                // Registrar las ventas en la base de datos
                new Db().RegistrarVentas(ventas);

                return new
                {
                    titulo = "Ventas registradas con éxito",
                    mensaje = "Las ventas fueron registradas correctamente.",
                    code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    titulo = "Error al registrar ventas",
                    mensaje = ex.Message,
                    code = 500
                };
            }
        }
        [HttpGet("{vendedorId}")]
        public object ObtenerVentasPorVendedor(int vendedorId)
        {
            try
            {
                var (ventas, totalVentas) = _db.ObtenerVentasPorVendedor(vendedorId);

                return new
                {
                    Exitoso = true,
                    Ventas = ventas,
                    TotalVentas = totalVentas,
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener las ventas: {ex.Message}",
                    Code = 500
                };
            }
        }

        [HttpGet("todas")]
        public object ObtenerTodasLasVentas()
        {
            try
            {
                var (ventas, totalVentas) = _db.ObtenerTodasLasVentas();

                return new
                {
                    Exitoso = true,
                    Ventas = ventas,
                    TotalVentas = totalVentas,
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener las ventas: {ex.Message}",
                    Code = 500
                };
            }
        }


    }
}

