using System.Data;
using Microsoft.Data.SqlClient;
using ApiAgrodelis.Models;
using System;
using System.Text;
using System.Security.Cryptography;

namespace ApiAgrodelis.Datos
{
    public class Db
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;

        public Db()
        {
            string cadenaConexion = "server=localhost;database=AgroDelis;persistsecurityinfo=True; Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection();
            con.ConnectionString = cadenaConexion;
            cmd = new SqlCommand();
            cmd.Connection = con;
        }


        //=====================================FRONTEND-SOFTV===========================================
        public List<ProductoV> ObtenerTodosLosProductos()
        {
            List<ProductoV> productos = new List<ProductoV>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;

                // Consulta SQL actualizada para usar la tabla intermedia ProductosVendedores
                cmd.CommandText = @"
        SELECT 
            p.ProductoID, 
            p.Nombre, 
            p.Descripcion, 
            p.Precio, 
            p.Stock, 
            p.RutaImagen,
            c.Nombre AS CategoriaNombre,  -- Nombre de la categoría
            c.CategoriaID,               -- ID de la categoría
            u.Nombre AS VendedorNombre   -- Nombre del vendedor
        FROM 
            Productos p
        LEFT JOIN 
            Categorias c ON p.CategoriaID = c.CategoriaID
        INNER JOIN 
            ProductosVendedores pv ON p.ProductoID = pv.ProductoID  -- Relación con ProductosVendedores
        INNER JOIN 
            Usuarios u ON pv.UsuarioID = u.UsuarioID  -- Relación con Usuarios (vendedores)
        WHERE 
            u.Rol = 'Vendedor' AND u.Activo = 1";

                con.Open(); // Abrir la conexión
                ds = new DataSet();

                // Llenar el DataSet con los resultados de la consulta
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                // Procesar los resultados
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var producto = new ProductoV()
                        {
                            ProductoId = Convert.ToInt32(row["ProductoID"]),
                            Nombre = row["Nombre"].ToString(),
                            Descripcion = row["Descripcion"].ToString(),
                            Precio = Convert.ToDecimal(row["Precio"]),
                            Stock = Convert.ToInt32(row["Stock"]),
                            RutaImagen = row["RutaImagen"].ToString(),

                            // Asignación del nombre de la categoría
                            CategoriaNombre = row["CategoriaNombre"].ToString(),

                            // Asignación del nombre del vendedor
                            VendedorNombre = row["VendedorNombre"].ToString(),

                            // Asignación del ID de la categoría
                            CategoriaID = Convert.ToInt32(row["CategoriaID"])
                        };

                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw ex; // Asegúrate de registrar el error para análisis.
            }
            finally
            {
                con.Close(); // Cerrar la conexión
            }

            return productos;
        }


        //==============================FRONTEND-SOFTV================================
        public int ActualizarProducto(ProductoV producto)
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
        UPDATE Productos 
        SET Stock = @Stock 
        WHERE ProductoID = @ProductoID";

            cmd.Parameters.AddWithValue("@Stock", producto.Stock);
            cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoId);

            con.Open();
            var result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }

        //=============================FRONTEND-SOFTV=================================
        public ProductoV ObtenerProductoPorIdV(int productoId)
        {
            ProductoV producto = null;
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
        SELECT ProductoID, Nombre, Stock
        FROM Productos
        WHERE ProductoID = @ProductoID";

            cmd.Parameters.AddWithValue("@ProductoID", productoId);

            con.Open();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    producto = new ProductoV()
                    {
                        ProductoId = Convert.ToInt32(reader["ProductoID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Stock = Convert.ToInt32(reader["Stock"])
                    };
                }
            }
            con.Close();

            return producto;
        }
        //=================================================================================



        //=============TODO LO QUE TIENE QUE VER CON EL LOGIN Y REGISTRO====================
        public bool ValidarUsuario(string email, string contraseña)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;

                // Consulta para verificar si el email y la contraseña coinciden
                cmd.CommandText = "SELECT 1 FROM usuarios WHERE email = @Email AND contraseña = @Contraseña";
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@Contraseña", EncriptarContraseña(contraseña)));


                con.Open();
                var resultado = cmd.ExecuteScalar(); // Devuelve 1 si las credenciales son válidas

                return resultado != null; // Retorna true si las credenciales son válidas, de lo contrario false
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar credenciales: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Encriptar Contraseña
        private string EncriptarContraseña(string contraseña)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                return Convert.ToBase64String(bytes); // Cifrar la contraseña usando SHA-256
            }
        }


        public string ObtenerRolPorEmail(string email)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;

                // Consulta para obtener el rol del usuario
                cmd.CommandText = "SELECT rol FROM usuarios WHERE email = @Email";
                cmd.Parameters.Add(new SqlParameter("@Email", email));

                con.Open();
                var resultado = cmd.ExecuteScalar(); // Devuelve el rol como un string

                return resultado?.ToString(); // Retorna el rol si existe, de lo contrario null
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el rol: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public int ObtenerUsuarioIdPorEmail(string email)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT UsuarioId FROM usuarios WHERE email = @Email";
                cmd.Parameters.Add(new SqlParameter("@Email", email));

                con.Open();
                var resultado = cmd.ExecuteScalar();  // Devuelve el ID si lo encuentra

                return resultado != null ? Convert.ToInt32(resultado) : 0;  // Retorna el ID o 0 si no existe
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID del usuario: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public string ObtenerNombrePorEmail(string email)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Nombre FROM usuarios WHERE Email = @Email";  // Asegúrate de que el campo 'Nombre' existe en la tabla
                cmd.Parameters.Add(new SqlParameter("@Email", email));

                con.Open();
                var resultado = cmd.ExecuteScalar();  // Devuelve el nombre si lo encuentra

                return resultado != null ? Convert.ToString(resultado) : null;  // Retorna el nombre o null si no existe
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el nombre del usuario: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        public bool ValidarEmail(string email)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;

                // Verificar si el email ya está registrado
                cmd.CommandText = "SELECT COUNT(*) FROM usuarios WHERE LOWER(email) = LOWER(@Email)";
                cmd.Parameters.Add(new SqlParameter("@Email", email));

                con.Open();
                var resultado = cmd.ExecuteScalar();  // Si el resultado es mayor que 0, el email ya está registrado

                return (int)resultado > 0;  // Retorna true si el email ya existe
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el email: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public bool ValidarNombreUsuario(string nombre)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;

                // Verificar si el nombre de usuario ya está registrado
                cmd.CommandText = "SELECT COUNT(*) FROM usuarios WHERE LOWER(nombre) = LOWER(@Nombre)";
                cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));

                con.Open();
                var resultado = cmd.ExecuteScalar();  // Si el resultado es mayor que 0, el nombre de usuario ya está registrado


                return (int)resultado > 0;  // Retorna true si el nombre de usuario ya existe
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el nombre de usuario: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        // Registrar un nuevo Usuario
        public int RegistrarUsuario(string nombre, string email, string contraseña, string rol)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;

                // Asegúrate de incluir el rol en la consulta SQL
                cmd.CommandText = "INSERT INTO usuarios (nombre, email, contraseña, Rol) VALUES (@nombre, @email, @contraseña, @rol)";

                // Añadir los parámetros a la consulta SQL
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@contraseña", EncriptarContraseña(contraseña))); // Encriptamos la contraseña
                cmd.Parameters.Add(new SqlParameter("@rol", rol)); // Agregar el rol (Vendedor, Cliente, etc.)

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected; // Devuelve el número de filas afectadas (debería ser 1 si el registro es exitoso)
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar usuario", ex);
            }
            finally
            {
                con.Close();
            }
        }



        //=================================CRUD DE PRODUCTOS PARA LOS VENDEDORES===============================
        public List<Producto> ObtenerProductosPorVendedor(int vendedorId)
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                cmd.Parameters.Clear();
                // Realizar un JOIN con la tabla Categorias para obtener el nombre de la categoría
                cmd.CommandText = "SELECT p.ProductoId, p.Nombre, p.Descripcion, p.Precio, p.Stock, p.RutaImagen, c.Nombre AS CategoriaNombre " +
                                  "FROM Productos p " +
                                  "INNER JOIN ProductosVendedores pv ON p.ProductoId = pv.ProductoId " +
                                  "INNER JOIN Categorias c ON p.CategoriaId = c.CategoriaId " +  // Join con la tabla Categorias
                                  "WHERE pv.UsuarioId = @VendedorId";

                cmd.Parameters.AddWithValue("@VendedorId", vendedorId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        ProductoId = Convert.ToInt32(reader["ProductoId"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Stock = Convert.ToInt32(reader["Stock"]),
                        RutaImagen = reader["RutaImagen"]?.ToString(),  // Verifica si es null
                        CategoriaNombre = reader["CategoriaNombre"].ToString()  // Asignamos el nombre de la categoría
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos del vendedor: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return productos;
        }
        public int RegistrarProductoYRelacion(string nombre, string descripcion, decimal precio, int stock, string rutaImagen, int categoriaId, int vendedorId)
        {
            try
            {
                // Iniciar una transacción
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                cmd.Transaction = transaction;

                // Registrar el producto
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, RutaImagen, CategoriaId) " +
                                  "VALUES (@Nombre, @Descripcion, @Precio, @Stock, @RutaImagen, @CategoriaId); " +
                                  "SELECT SCOPE_IDENTITY();";  // Obtener el ProductoId generado

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@RutaImagen", rutaImagen);
                cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);

                var productoId = cmd.ExecuteScalar();  // Obtiene el ProductoId recién insertado

                // Si no se insertó correctamente el producto, hacer rollback
                if (productoId == null)
                {
                    transaction.Rollback();
                    throw new Exception("No se pudo obtener el ID del producto.");
                }

                int idProducto = Convert.ToInt32(productoId);

                // Registrar la relación Producto-Vendedor
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ProductosVendedores (ProductoId, UsuarioId) " +
                                  "VALUES (@ProductoId, @UsuarioId)";

                cmd.Parameters.AddWithValue("@ProductoId", idProducto);
                cmd.Parameters.AddWithValue("@UsuarioId", vendedorId);

                cmd.ExecuteNonQuery();  // Ejecuta la inserción de la relación

                // Si todo es correcto, confirmar la transacción
                transaction.Commit();

                return idProducto;  // Retorna el ID del producto registrado
            }
            catch (Exception ex)
            {
                // En caso de error, hacer rollback
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                throw new Exception("Error al registrar el producto y la relación producto-vendedor: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public int ModificarProducto(int productoId, string nombre, string descripcion, decimal precio, int stock, string rutaImagen, int categoriaId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Productos " +
                                  "SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock, RutaImagen = @RutaImagen, CategoriaId = @CategoriaId " +
                                  "WHERE ProductoId = @ProductoId";

                cmd.Parameters.AddWithValue("@ProductoId", productoId);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@RutaImagen", rutaImagen);
                cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);

                con.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar producto: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }




        public int EliminarProducto(int productoId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;

                // Eliminar las relaciones del producto en ProductosVendedores
                cmd.CommandText = "DELETE FROM ProductosVendedores WHERE ProductoID = @ProductoId";
                cmd.Parameters.Add(new SqlParameter("@ProductoId", productoId));    

                con.Open();
                cmd.ExecuteNonQuery(); // Primero elimina las relaciones

                // Ahora elimina el producto en la tabla Productos
                cmd.CommandText = "DELETE FROM Productos WHERE ProductoID = @ProductoId";
                int rowsAffected = cmd.ExecuteNonQuery(); // Luego elimina el producto

                return rowsAffected; // Devuelve el número de filas afectadas
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto y sus relaciones: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        //===============================NOTIFICACION DE ESCRITORIO CUANDO EL STOCK  ESTE BAJO======================================
        public List<Producto> ObtenerProductosConStockBajoPorVendedor(int vendedorId, int limiteStock)
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;

                // Consulta SQL para obtener solo los productos con stock bajo
                cmd.CommandText = @"
SELECT 
    p.ProductoID, 
    p.Nombre, 
    p.Stock
FROM 
    Productos p
INNER JOIN 
    ProductosVendedores pv ON p.ProductoID = pv.ProductoID  
INNER JOIN 
    Usuarios u ON pv.UsuarioID = u.UsuarioID  
WHERE 
    u.Rol = 'Vendedor' AND u.Activo = 1
    AND pv.UsuarioID = @VendedorId
    AND p.Stock < @LimiteStock";  // Filtrar productos con stock bajo

                // Añadir parámetros para evitar inyecciones SQL
                cmd.Parameters.AddWithValue("@VendedorId", vendedorId);
                cmd.Parameters.AddWithValue("@LimiteStock", limiteStock);

                con.Open(); // Abrir la conexión
                ds = new DataSet();

                // Llenar el DataSet con los resultados de la consulta
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                // Procesar los resultados
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var producto = new Producto()
                        {
                            ProductoId = Convert.ToInt32(row["ProductoID"]),
                            Nombre = row["Nombre"].ToString(),
                            Stock = Convert.ToInt32(row["Stock"])
                        };

                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw ex;
            }
            finally
            {
                con.Close(); // Cerrar la conexión
            }

            return productos;
        }

        //==================================== Registrar Ventas ====================================

        public void RegistrarVentas(List<VentaRequest> ventas)
        {
            try
            {
                // Iterar sobre la lista de ventas para insertarlas
                foreach (var item in ventas)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.Text;

                    // Consulta SQL para insertar cada venta en la tabla de Ventas
                    cmd.CommandText = @"
                INSERT INTO Ventas (ProductoId, Cantidad, Precio, VendedorId, Total, FechaVenta)
                VALUES (@ProductoId, @Cantidad, @Precio, @VendedorId, @Total, @FechaVenta)";

                    // Agregar los parámetros de la venta
                    cmd.Parameters.AddWithValue("@ProductoId", item.ProductoId);
                    cmd.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", item.Precio);
                    cmd.Parameters.AddWithValue("@VendedorId", item.VendedorId);
                    cmd.Parameters.AddWithValue("@Total", item.Cantidad * item.Precio);
                    cmd.Parameters.AddWithValue("@FechaVenta", DateTime.UtcNow);

                    // Abrir la conexión y ejecutar la consulta
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (podrías loguear el error si es necesario)
                throw new Exception($"Error al registrar ventas: {ex.Message}");
            }
            finally
            {
                con.Close(); // Asegúrate de cerrar la conexión siempre
            }
        }



        //===============================PARA LAS CATEGORIAS======================================
        public List<Categoria> ObtenerCategorias()
        {
            var categorias = new List<Categoria>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT CategoriaId, Nombre FROM Categorias";  // Suponiendo que tienes una tabla Categorias
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        CategoriaId = Convert.ToInt32(reader["CategoriaId"]),
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener categorías: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return categorias;
        }
        


    }
}
