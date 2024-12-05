using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Models
{
    public class TransferenciaProducto
    {
        public int ProductoId { get; set; }
        public int VendedorId { get; set; }
        public int Cantidad { get; set; }  // Cantidad que se va a transferir
    }

}
