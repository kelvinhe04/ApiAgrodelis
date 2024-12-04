using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiAgrodelis.Models
{
    public class ProductoV
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(500)] // Configuramos un límite de longitud opcional para la descripción
        public string Descripcion { get; set; } // Nueva propiedad
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Stock { get; set; } // Nueva propiedad para controlar el stock disponible

        [StringLength(200)]
        public string RutaImagen { get; set; }

        // Nuevas propiedades para almacenar solo los nombres
        public string CategoriaNombre { get; set; }
        public string VendedorNombre { get; set; }
        // Nueva propiedad CategoriaID
        public int CategoriaID { get; set; }
        public int VendedorId { get; set; }

    }
}
    