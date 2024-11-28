using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgrodelisForm.Models
{
    public class RegisterRequest
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }         // Rol del usuario (Vendedor, Cliente, etc.)

    }
}
