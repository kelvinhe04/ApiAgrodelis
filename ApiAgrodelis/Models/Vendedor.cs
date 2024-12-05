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

        
    }
}
