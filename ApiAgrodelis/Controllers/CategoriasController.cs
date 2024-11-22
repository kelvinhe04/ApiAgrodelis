using ApiAgrodelis.Datos;
using Microsoft.AspNetCore.Mvc;
using ApiAgrodelis.Models;

namespace ApiAgrodelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public List<Categoria> ObtenerValor()
        {
            return new Db().ObtenerCategorias();
        }
        
            [HttpPost]
        [Route("save")]
        public object GuardarCategoria(CategoriaRequest categoria)
        {
            var guardado = new Db().InsertarCategoria(categoria);
            if (guardado > 0)
                return new
                {
                    titulo = "Exito al guardar",
                    Mensaje = "Los datos se han guardado correctamente",
                    Code = 200
                };
            return new
            {
                titulo = "Error al guardar",
                Mensaje = "Los datos explotaron",
                Code = 400
            };
        }

        [HttpPost]
        [Route("edit/{id}")]
        public object EditarCategoria(int id, CategoriaRequest categoria)
        {
            var editado = new Db().ActualizarCategoria(id, categoria);
            if (editado > 0)
                return new
                {
                    titulo = "Exito al editar",
                    Mensaje = "Los datos se han editado correctamente",
                    Code = 200
                };
            return new
            {
                titulo = "Error al editar",
                Mensaje = "Los datos explotaron",
                Code = 400
            };
        }

        [HttpDelete]
        [Route("{id}")]
        public object EliminarCategoria(int id)
        {
            var borrado = new Db().BorrarCategoria(id);
            if (borrado > 0)
                return new
                {
                    titulo = "Exito al borrar",
                    Mensaje = "Los datos se han borrado correctamente",
                    Code = 200
                };
            return new
            {
                titulo = "Error al borrar",
                Mensaje = "Los datos no se borraron",
                Code = 400
            };
        }
    }
}
