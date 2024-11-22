using System.Data;
using Microsoft.Data.SqlClient;
using ApiAgrodelis.Models;

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
            string cadenaConexion = "server=localhost;database=Agrodelis;persistsecurityinfo=True; Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection();
            con.ConnectionString = cadenaConexion;
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;

                // Consulta SQL que incluye stock y rutaImagen de los productos
                cmd.CommandText = "sp_ObtenerCategoriasConProductos";

                con.Open(); // Abrir la conexión
                ds = new DataSet();

                // Llenar el DataSet
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                // Procesar los resultados
                Dictionary<int, Categoria> categoriaDict = new Dictionary<int, Categoria>();

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        int categoriaId = Convert.ToInt32(row["CategoriaID"]);

                        // Verificar si la categoría ya está en el diccionario
                        if (!categoriaDict.ContainsKey(categoriaId))
                        {
                            var categoria = new Categoria()
                            {
                                CategoriaId = categoriaId,
                                Nombre = row["CategoriaNombre"].ToString(),
                                Productos = new List<Producto>() // Inicializar la lista de productos
                            };
                            categoriaDict[categoriaId] = categoria;
                        }

                        // Si hay producto asociado, agregarlo a la lista
                        if (row["ProductoID"] != DBNull.Value)
                        {
                            var producto = new Producto()
                            {
                                ProductoId = Convert.ToInt32(row["ProductoID"]),
                                Nombre = row["ProductoNombre"].ToString(),
                                Descripcion = row["Descripcion"].ToString(),
                                Precio = Convert.ToDecimal(row["Precio"]),
                                Stock = Convert.ToInt32(row["Stock"]),
                                RutaImagen = row["RutaImagen"].ToString()
                            };

                            categoriaDict[categoriaId].Productos.Add(producto);
                        }
                    }
                }

                // Convertir el diccionario a una lista
                categorias = categoriaDict.Values.ToList();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw;
            }
            finally
            {
                con.Close(); // Cerrar la conexión en el bloque finally
            }

            return categorias;
        }
        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                // Hacemos un JOIN con las tablas Categorias, VendedoresProductos y Vendedores
                cmd.CommandText = @"
        SELECT 
            p.ProductoID, 
            p.Nombre, 
            p.Descripcion, 
            p.Precio, 
            p.Stock, 
            p.RutaImagen,
            c.Nombre AS CategoriaNombre,  -- Nombre de la categoria
 c.CategoriaID,  -- Asegúrate de que esta columna esté seleccionada
            v.Nombre AS VendedorNombre   -- Nombre del vendedor
        FROM 
            Productos p
        LEFT JOIN 
            Categorias c ON p.CategoriaID = c.CategoriaID
        INNER JOIN 
            VendedoresProductos vp ON p.ProductoID = vp.ProductoID
        INNER JOIN 
            Vendedores v ON vp.VendedorID = v.VendedorID";

                con.Open(); // Abrir la conexión
                ds = new DataSet();

                // Llenar el DataSet
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

                            // Asignación del nombre de la Categoria
                            CategoriaNombre = row["CategoriaNombre"].ToString(),

                            // Asignación del nombre del Vendedor
                            VendedorNombre = row["VendedorNombre"].ToString(),
                            CategoriaID = Convert.ToInt32(row["CategoriaID"])  // Aquí agregas el CategoriaID
                        };

                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw;
            }
            finally
            {
                con.Close(); // Cerrar la conexión
            }

            return productos;
        }




        public int InsertarCategoria(CategoriaRequest categoria)
        {
        
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Categorias(nombre)values(@n)";
                cmd.Parameters.Add(new SqlParameter("@n", categoria.Nombre));
      

                con.Open();  // Abrir la conexión
                int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (insertedId > 0)
                    return insertedId;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw;
            }
            finally
            {
                con.Close();  // Cerrar la conexión
            }

            return 0;
        }

        public int ActualizarCategoria(int id, CategoriaRequest categoria)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Categorias SET Nombre = @n WHERE CategoriaID = @id";
                cmd.Parameters.Add(new SqlParameter("@n", categoria.Nombre));
                cmd.Parameters.Add(new SqlParameter("@id", id));

                con.Open();  // Abrir la conexión
                int updatedRows = cmd.ExecuteNonQuery();
                if (updatedRows > 0)
                    return updatedRows;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw;
            }
            finally
            {
                con.Close();  // Cerrar la conexión
            }

            return 0;
        }

        public int BorrarCategoria(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Catagorias WHERE id = @id";
                cmd.Parameters.Add(new SqlParameter("@id", id));

                con.Open();  // Abrir la conexión
                int deletedRows = cmd.ExecuteNonQuery();
                if (deletedRows > 0)
                    return deletedRows;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw;
            }
            finally
            {
                con.Close();  // Cerrar la conexión
            }

            return 0;
        }
    }
}
