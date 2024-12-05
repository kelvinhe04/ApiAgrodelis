using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiAgrodelis.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Contraseña")]
        public string Contraseña { get; set; }

        [JsonProperty("Rol")]
        public string Rol { get; set; }

        [JsonProperty("Activo")]
        public bool Activo { get; set; }

        [JsonProperty("ObjetivoVenta")]
        public int ObjetivoVenta { get; set; }

        [JsonProperty("LugarDeVentas")]
        public int LugarDeVentas { get; set; }

        [JsonProperty("Motivo")]
        public string Motivo { get; set; }

        [JsonProperty("Duracion")]
        public string Duracion { get; set; }
        public string Email { get; set; }
    }

}
