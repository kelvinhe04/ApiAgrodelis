using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Models
{
    public class Ventas
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }  // Nombre del producto
        public string NombreCategoria { get; set; }  // Nombre de la categoría
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int VendedorId { get; set; }
        public DateTime FechaVenta { get; set; }
    }


}
