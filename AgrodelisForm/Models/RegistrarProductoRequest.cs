using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Models
{
    public class RegistrarProductoRequest
    {
        public string Nombre { get; set; }  // Nombre del producto
        public string Descripcion { get; set; }  // Descripción del producto
        public decimal Precio { get; set; }  // Precio del producto
        public int Stock { get; set; }  // Cantidad en stock
        public string RutaImagen { get; set; }  // Ruta de la imagen del producto
        public int CategoriaId { get; set; }  // ID de la categoría del producto
        public int VendedorId  {get; set; }
}


}
