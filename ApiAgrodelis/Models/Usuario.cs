namespace ApiAgrodelis.Models
{
    public class Usuario
    {
        public int Id { get; set; }                 // Identificador único del usuario
        public string Nombre { get; set; }          // Nombre del usuario
        public string Email { get; set; }           // Correo electrónico del usuario
        public string Contraseña { get; set; }      // Contraseña cifrada del usuario
        public string Rol { get; set; }             // Rol del usuario (por ejemplo, "Admin", "Cliente", "Vendedor")
        public bool Activo { get; set; }            // Indicador de si el usuario está activo
    }
}
