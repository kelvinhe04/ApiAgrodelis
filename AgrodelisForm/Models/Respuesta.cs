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

        public DatosUsuario Datos { get; set; }  // Cambiado de 'object' a 'DatosUsuario'
        public int Code { get; set; }    // Código de estado (por ejemplo, 200, 400, 500)
        public List<Categoria> Categorias { get; set; }  // Lista de categorías
    }
    public class DatosUsuario
    {
        public string Rol { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }  // Nueva propiedad para almacenar el nombre
    }
}
