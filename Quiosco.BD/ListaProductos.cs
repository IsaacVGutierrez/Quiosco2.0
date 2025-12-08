using Quiosco.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Quiosco.BD
{
    public class ListaProductos : DatosConexionBD
    {

        public int abmProducto(string accion, Producto objProducto)
        {
            int resultado = -1;

            if (accion == "Alta")
            {
                string sql = @"
            INSERT INTO Producto (NombreProducto, MarcaProducto, PrecioProducto, CantidadProducto, PrecioCompra, PrecioVenta, IdCategoria)
            OUTPUT INSERTED.IdProducto
            VALUES (@nombre, @marca, @precioProducto, @cantidad, @precioCompra, @precioVenta, @idCategoria);
        ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", objProducto.NombreProducto);
                cmd.Parameters.AddWithValue("@marca", objProducto.MarcaProducto);
                cmd.Parameters.AddWithValue("@precioProducto", objProducto.PrecioProducto);
                cmd.Parameters.AddWithValue("@cantidad", objProducto.CantidadProducto);
                cmd.Parameters.AddWithValue("@precioCompra", objProducto.PrecioCompra);
                cmd.Parameters.AddWithValue("@precioVenta", objProducto.PrecioVenta);
                cmd.Parameters.AddWithValue("@idCategoria", objProducto.IdCategoria);

                try
                {
                    Abrirconexion();
                    object o = cmd.ExecuteScalar();
                    if (o != null) resultado = Convert.ToInt32(o);
                }
                catch (Exception e)
                {
                    throw new Exception("Error al insertar Producto", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }

                return resultado;
            }
            else if (accion == "Modificar")
            {
                string sql = @"
            UPDATE Producto SET
                NombreProducto = @nombre,
                MarcaProducto = @marca,
                PrecioProducto = @precioProducto,
                CantidadProducto = @cantidad,
                PrecioCompra = @precioCompra,
                PrecioVenta = @precioVenta,
                IdCategoria = @idCategoria
            WHERE IdProducto = @idProducto;
        ";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", objProducto.NombreProducto);
                cmd.Parameters.AddWithValue("@marca", objProducto.MarcaProducto);
                cmd.Parameters.AddWithValue("@precioProducto", objProducto.PrecioProducto);
                cmd.Parameters.AddWithValue("@cantidad", objProducto.CantidadProducto);
                cmd.Parameters.AddWithValue("@precioCompra", objProducto.PrecioCompra);
                cmd.Parameters.AddWithValue("@precioVenta", objProducto.PrecioVenta);
                cmd.Parameters.AddWithValue("@idCategoria", objProducto.IdCategoria);
                cmd.Parameters.AddWithValue("@idProducto", objProducto.IdProducto);

                try
                {
                    Abrirconexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al modificar Producto", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
                return resultado;
            }
            else if (accion == "Baja")
            {
                string sql = "DELETE FROM Producto WHERE IdProducto = @idProducto";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idProducto", objProducto.IdProducto);
                try
                {
                    Abrirconexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al eliminar Producto", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
                return resultado;
            }

            return resultado;
        }




        public DataSet listadoProducto(string id)
        {
            string orden = @"
        SELECT
            p.IdProducto,
            p.NombreProducto,
            p.MarcaProducto,
            p.PrecioProducto,
            p.CantidadProducto,
            p.PrecioCompra,
            p.PrecioVenta,
            p.IdCategoria,
            cp.IdProveedor,
            cp.IdMetodoDePago,
            cp.FechaCompraProductos,
            dc.IdCompraProducto
        FROM Producto p
        LEFT JOIN DetalleCompra dc ON p.IdProducto = dc.IdProducto
        LEFT JOIN CompraProducto cp ON dc.IdCompraProducto = cp.IdCompraProducto
        WHERE p.IdProducto = @id;
    ";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@id", int.Parse(id));

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Producto", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
        }


        public List<Producto> ObtenerProducto()
        {

            List<Producto> lista = new List<Producto>();


            string OrdenEjecucion = "Select IdProducto, NombreProducto , MarcaProducto , PrecioProducto, CantidadProducto ,PrecioCompra , PrecioVenta, IdCategoria from Producto";

            


            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                 /*   string productos = dataReader.GetString(2);
                    decimal precio = dataReader.GetDecimal(3);
                    string productoprecio = $"{productos} , ${precio}";
                 */



                    Producto producto = new Producto();


                    producto.IdProducto = dataReader.GetInt32(0);

                    producto.NombreProducto = dataReader.GetString(1);

                    producto.MarcaProducto = dataReader.GetString(2);

                    producto.PrecioProducto = dataReader.GetDecimal(3);

                    producto.CantidadProducto = dataReader.GetInt32(4);

                    producto.PrecioCompra = dataReader.GetDecimal(5);

                    producto.PrecioVenta = dataReader.GetDecimal(6);

                    producto.IdCategoria = dataReader.GetInt32(7);



                    lista.Add(producto);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de productos", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }

        public bool ReducirStock(int idProducto, int cantidad)
        {
            string sqlCheck = "SELECT CantidadProducto FROM Producto WHERE IdProducto = @id";
            string sqlUpdate = "UPDATE Producto SET CantidadProducto = CantidadProducto - @cantidad WHERE IdProducto = @id";

            SqlCommand cmdCheck = new SqlCommand(sqlCheck, conexion);
            cmdCheck.Parameters.AddWithValue("@id", idProducto);

            try
            {
                Abrirconexion();

                // Verificar stock disponible
                int stockActual = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (stockActual < cantidad)
                {
                    return false; // No hay stock suficiente
                }

                // Restar stock
                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conexion);
                cmdUpdate.Parameters.AddWithValue("@cantidad", cantidad);
                cmdUpdate.Parameters.AddWithValue("@id", idProducto);
                cmdUpdate.ExecuteNonQuery();

                return true;
            }
            finally
            {
                Cerrarconexion();
            }
        }



        public DataSet listarProductoBuscar(string cual)
        {
            string orden = @"
        SELECT  
            p.IdProducto,
            p.NombreProducto,
            p.MarcaProducto,
            p.PrecioProducto,
            c.NombreCategoria,
            p.CantidadProducto,
            pr.NombreProveedor,
            p.PrecioCompra,
            p.PrecioVenta,
            mp.NombreMetodoDePago,
            cp.FechaCompraProductos
        FROM Producto p
            INNER JOIN Categoria c ON p.IdCategoria = c.IdCategoria
            INNER JOIN DetalleCompra dc ON p.IdProducto = dc.IdProducto
            INNER JOIN CompraProducto cp ON dc.IdCompraProducto = cp.IdCompraProducto
            INNER JOIN Proveedor pr ON cp.IdProveedor = pr.IdProveedor
            INNER JOIN MetodoDePago mp ON cp.IdMetodoDePago = mp.IdMetodoDePago
        WHERE 
            p.IdProducto LIKE @buscar OR
            p.NombreProducto LIKE @buscar OR
            p.MarcaProducto LIKE @buscar OR
            p.PrecioProducto LIKE @buscar OR
            p.CantidadProducto LIKE @buscar OR
            p.PrecioCompra LIKE @buscar OR
            p.PrecioVenta LIKE @buscar OR
            c.NombreCategoria LIKE @buscar OR
            pr.NombreProveedor LIKE @buscar OR
           mp.NombreMetodoDePago LIKE @buscar OR
CONVERT(VARCHAR(10), cp.FechaCompraProductos, 120) LIKE @buscar OR
           CONVERT(VARCHAR(10), cp.FechaCompraProductos, 120) LIKE @buscar
        ORDER BY p.IdProducto DESC;
    ";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@buscar", $"%{cual}%");

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                Abrirconexion();
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al buscar el producto", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return ds;
        }




        public bool ListarProductoEliminar(int idProducto)
        {
            try
            {
                Abrirconexion();

                // 1) Obtener IdCompraProducto asociado
                var cmdGet = new SqlCommand("SELECT IdCompraProducto FROM DetalleCompra WHERE IdProducto=@id", conexion);
                cmdGet.Parameters.AddWithValue("@id", idProducto);

                object o = cmdGet.ExecuteScalar();
                int idCompra = (o == null) ? -1 : Convert.ToInt32(o);

                // 2) Eliminar detalle
                var cmd1 = new SqlCommand("DELETE FROM DetalleCompra WHERE IdProducto=@id", conexion);
                cmd1.Parameters.AddWithValue("@id", idProducto);
                cmd1.ExecuteNonQuery();

                // 3) Eliminar compra si no tiene más detalles
                if (idCompra > 0)
                {
                    var cmdCheck = new SqlCommand("SELECT COUNT(*) FROM DetalleCompra WHERE IdCompraProducto=@idc", conexion);
                    cmdCheck.Parameters.AddWithValue("@idc", idCompra);

                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count == 0)
                    {
                        var cmd2 = new SqlCommand("DELETE FROM CompraProducto WHERE IdCompraProducto=@idc", conexion);
                        cmd2.Parameters.AddWithValue("@idc", idCompra);
                        cmd2.ExecuteNonQuery();
                    }
                }

                // 4) Eliminar producto
                var cmd3 = new SqlCommand("DELETE FROM Producto WHERE IdProducto=@id", conexion);
                cmd3.Parameters.AddWithValue("@id", idProducto);
                cmd3.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto", ex);
            }
            finally
            {
                Cerrarconexion();
            }
        }





        public DataSet Union()
        {
            string orden = @"
          SELECT 
                p.IdProducto,
              p.NombreProducto,
              p.MarcaProducto,
               p.PrecioProducto,
              c.NombreCategoria,
              p.CantidadProducto,
              pr.NombreProveedor,
              p.PrecioCompra,
              p.PrecioVenta,
              mp.NombreMetodoDePago,
              cp.FechaCompraProductos
             FROM Producto p
             INNER JOIN Categoria c ON p.IdCategoria = c.IdCategoria
              LEFT JOIN DetalleCompra dc ON p.IdProducto = dc.IdProducto
             LEFT JOIN CompraProducto cp ON dc.IdCompraProducto = cp.IdCompraProducto
              LEFT JOIN Proveedor pr ON cp.IdProveedor = pr.IdProveedor
             LEFT JOIN MetodoDePago mp ON cp.IdMetodoDePago = mp.IdMetodoDePago

              ORDER BY p.IdProducto DESC;


               ";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Abrirconexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener todas las compras del producto", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }




    }
}
