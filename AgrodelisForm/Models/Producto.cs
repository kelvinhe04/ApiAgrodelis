using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Models
{
    public class Producto
    {

        public int ProductoId { get; set; }
        public int VendedorId { get; set; }


        public string NombreProducto { get; set; }

        public string Descripcion { get; set; } // Nueva propiedad

        public decimal Precio { get; set; }

        public int Stock { get; set; } // Nueva propiedad para controlar el stock disponible


        public string RutaImagen { get; set; }

        public string NombreCategoria { get; set; }

        public string NombreVendedor { get; set; }

        

    }
}
