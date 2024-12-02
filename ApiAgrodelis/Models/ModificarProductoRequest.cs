﻿namespace ApiAgrodelis.Models
{
    public class ModificarProductoRequest
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public int CategoriaId { get; set; }
    }
}
