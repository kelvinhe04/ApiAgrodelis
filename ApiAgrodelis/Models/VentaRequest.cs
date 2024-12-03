namespace ApiAgrodelis.Models
{
    public class VentaRequest
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int VendedorId { get; set; }
    }
}
