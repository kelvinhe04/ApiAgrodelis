namespace ApiAgrodelis.Models
{
    public class VendedorRequest
    {
        public int VendedorId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
        public int ObjetivoVenta { get; set; }
        public int LugarDeVentas { get; set; }
        public string Motivo { get; set; }
        public string Duracion { get; set; }
        public string Email { get; set; }
    }
}
