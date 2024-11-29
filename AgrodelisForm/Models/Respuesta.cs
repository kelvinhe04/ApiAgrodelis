using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AgrodelisForm.Models
{
    public class Respuesta
    {

        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public int Code { get; set; }    // Código de estado (por ejemplo, 200, 400, 500)
    }
}
