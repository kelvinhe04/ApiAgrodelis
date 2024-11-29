using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Models
{
    public class ProductoV
    {
     
        public int ProductoId { get; set; }

       
        public string Nombre { get; set; }


        public decimal Precio { get; set; }

      
        public string RutaImagen { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int VendedorId { get; set; } // Llave foránea hacia el vendedor
        //public Vendedor Vendedor { get; set; } // Relación con el modelo 
    }
}
