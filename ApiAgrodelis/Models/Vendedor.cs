using System.ComponentModel.DataAnnotations;

namespace ApiAgrodelis.Models
{
    public class Vendedor
    {
        [Key]
        public int VendedorId { get; set; } // Clave primaria

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } // Nombre del vendedor

        [StringLength(15)]
        public string Telefono { get; set; } // Teléfono del vendedor (opcional)

        // Relación con productos
        public ICollection<Producto> Productos { get; set; } // Un vendedor puede vender varios productos
    }
}
