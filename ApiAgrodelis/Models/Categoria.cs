
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAgrodelis.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }


        public ICollection<Producto> Productos { get; set; }
    }
}