namespace ApiAgrodelis.Models
{
    public class RegisterRequest
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }         // Rol del usuario (Vendedor, Cliente, etc.)

    }
}
