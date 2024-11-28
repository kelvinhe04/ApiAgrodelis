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

        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> productos = new List<Producto>();
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
                        var producto = new Producto()
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





        public int ActualizarProducto(Producto producto)
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

        public Producto ObtenerProductoPorId(int productoId)
        {
            Producto producto = null;
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
                    producto = new Producto
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


        
    }



}

