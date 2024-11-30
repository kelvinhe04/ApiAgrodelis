using System.ComponentModel.DataAnnotations;

namespace ApiAgrodelis.Models
{
    public class Producto
    {
        
        public int ProductoId { get; set; }

        
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; } // Nueva propiedad
       
        public decimal Precio { get; set; }
       
        public int Stock { get; set; } // Nueva propiedad para controlar el stock disponible

      
        public string RutaImagen { get; set; }

        // Nuevas propiedades para almacenar solo los nombres
        public int VendedorId { get; set; }
        // Nueva propiedad CategoriaID
        public string CategoriaNombre { get; set; }

    }
}
