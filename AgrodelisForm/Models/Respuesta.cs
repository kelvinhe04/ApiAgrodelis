using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AgrodelisForm.Models
{
    public class Respuesta
    {

        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }

        public int Code { get; set; }    // Código de estado (por ejemplo, 200, 400, 500)
        public List<Producto> Productos { get; set; }  // Asegúrate de que esta propiedad existe
        public DatosUsuario Datos { get; set; }  // Cambiado de 'object' a 'DatosUsuario'
        public List<Categoria> Categorias { get; set; }  // Lista de categorías
        public List<Ventas> Ventas { get; set; }  // Lista de ventas
        public decimal TotalVentas { get; set; } // Nueva propiedad para almacenar el total de ventas
        public List<Vendedor> Vendedores { get; set; }  // Nueva propiedad para la lista de vendedores


    }
    public class DatosUsuario
    {
        public string Rol { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }  // Nueva propiedad para almacenar el nombre
    }
}
