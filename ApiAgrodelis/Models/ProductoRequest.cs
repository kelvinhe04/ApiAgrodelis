namespace ApiAgrodelis.Models
{
    public class ProductoRequest
    {
        public int ProductoId { get; set; } // El ID del producto
        public int Cantidad { get; set; }  // La cantidad a restar del stock
    }
}
