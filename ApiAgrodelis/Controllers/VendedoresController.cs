﻿using ApiAgrodelis.Datos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ApiAgrodelis.Models;
namespace ApiAgrodelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : Controller
    {
        private Db _db;

        public VendedoresController()
        {
            _db = new Db();
        }
        [HttpGet]
        [Route("vendedores")]
        public object ObtenerVendedores()
        {
            try
            {
                var vendedores = _db.ObtenerVendedores(); // Método en la base de datos que obtiene los vendedores.
                return new
                {
                    Exitoso = true,
                    Vendedores = vendedores,
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener los vendedores: {ex.Message}",
                    Code = 500
                };
            }
        }
        [HttpGet]
        [Route("vendedores/todos")]
        public object ObtenerTodosVendedores()
        {
            try
            {
                var vendedores = _db.ObtenerTodosVendedores(); // Método en la base de datos que obtiene los vendedores.
                return new
                {
                    Exitoso = true,
                    Vendedores = vendedores,
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al obtener los vendedores: {ex.Message}",
                    Code = 500
                };
            }
        }
        //============================================CRUD VENDEDORES================================================
        [HttpPost("registrar")]
        public object RegistrarVendedor([FromBody] RegistrarVendedorRequest request)
        {
            try
            {
                var resultado = _db.RegistrarVendedor(request.Nombre, request.Contrasena, request.Rol, request.Activo, request.ObjetivoVenta, request.LugarDeVentas, request.Motivo, request.Duracion, request.Email);

                if (resultado > 0)
                {
                    return new
                    {
                        Exitoso = true,
                        Mensaje = "Vendedor registrado correctamente.",
                        Code = 200
                    };
                }
                else
                {
                    return new
                    {
                        Exitoso = false,
                        Mensaje = "Hubo un error al registrar el vendedor.",
                        Code = 400
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    Exitoso = false,
                    Mensaje = $"Error al registrar el vendedor: {ex.Message}",
                    Code = 500
                };
            }
        }



    }
}
