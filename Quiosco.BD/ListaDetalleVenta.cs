using Microsoft.Data.SqlClient;
using Quiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Quiosco.BD
{
    public class ListaDetalleVenta : DatosConexionBD
    {
        public int abmDetalleVenta(string accion, DetalleVenta objDetalleVenta)
        {
            int resultado = -1;

            if (accion == "Alta")
            {
                string sql = @"
                    INSERT INTO DetalleVenta (IdVenta, IdProducto, CantidadProducto)
                    VALUES (@idVenta, @idProducto, @cantidad)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idVenta", objDetalleVenta.IdVenta);
                cmd.Parameters.AddWithValue("@idProducto", objDetalleVenta.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", objDetalleVenta.CantidadProducto);

                try
                {
                    Abrirconexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al insertar DetalleVenta", e);
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
                    UPDATE DetalleVenta
                    SET IdVenta = @idVenta,
                        IdProducto = @idProducto,
                        CantidadProducto = @cantidad
                    WHERE IdDetalleVenta = @idDetalle";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idVenta", objDetalleVenta.IdVenta);
                cmd.Parameters.AddWithValue("@idProducto", objDetalleVenta.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", objDetalleVenta.CantidadProducto);
                cmd.Parameters.AddWithValue("@idDetalle", objDetalleVenta.IdDetalleVenta);

                try
                {
                    Abrirconexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al modificar DetalleVenta", e);
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

        public DataSet listadoDetalleVenta(string id)
        {
            string orden;
            if (id != "Todos")
                orden = $"SELECT * FROM DetalleVenta WHERE IdDetalleVenta = {int.Parse(id)}";
            else
                orden = "SELECT * FROM DetalleVenta";

            SqlCommand cmd = new SqlCommand(orden, conexion);
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
                throw new Exception("Error al listar DetalleVenta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
        }

        public List<DetalleVenta> ObtenerDetalleVenta()
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            string sql = "SELECT IdDetalleVenta, IdVenta, IdProducto, CantidadProducto FROM DetalleVenta";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            try
            {
                Abrirconexion();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DetalleVenta dv = new DetalleVenta
                    {
                        IdDetalleVenta = dr.GetInt32(0),
                        IdVenta = dr.GetInt32(1),
                        IdProducto = dr.GetInt32(2),
                        CantidadProducto = dr.GetInt32(3)
                    };
                    lista.Add(dv);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener lista DetalleVenta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return lista;
        }

        public DataSet listarDetalleVentaBuscar(string cual)
        {
            string orden = @"
        SELECT dv.IdDetalleVenta, dv.IdVenta, dv.IdProducto, dv.CantidadProducto,
               p.NombreProducto, p.MarcaProducto, p.PrecioVenta,
               v.SubtotalVenta, v.FechaVenta,
               mp.NombreMetodoDePago, 
               c.NombreCliente
        FROM DetalleVenta dv
        LEFT JOIN Venta v ON dv.IdVenta = v.IdVenta
        LEFT JOIN MetodoDePago mp ON v.IdMetodoDePago = mp.IdMetodoDePago
        LEFT JOIN Cliente c ON v.IdCliente = c.IdCliente
        LEFT JOIN Producto p ON dv.IdProducto = p.IdProducto
        WHERE
            dv.IdDetalleVenta LIKE @buscar OR
            dv.IdVenta LIKE @buscar OR
            dv.IdProducto LIKE @buscar OR
            dv.CantidadProducto LIKE @buscar OR
            p.PrecioVenta LIKE @buscar OR
            v.SubtotalVenta LIKE @buscar OR
            CONVERT(VARCHAR(30), v.FechaVenta, 23) LIKE @buscar OR
            mp.NombreMetodoDePago LIKE @buscar OR
            c.NombreCliente LIKE @buscar OR
            p.NombreProducto LIKE @buscar
        ORDER BY dv.IdDetalleVenta DESC";
            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@buscar", $"%{cual}%");
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
                throw new Exception("Error al buscar DetalleVenta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet ListarDetalleVentaEliminar(string id)
        {
            string orden = $"DELETE FROM DetalleVenta WHERE IdDetalleVenta = {id}";
            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar DetalleVenta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }


     

        public double ObtenerTotalVentas(DateTime desde, DateTime hasta)
        {
            double totalVentas = 0;
            string sql = @"
        SELECT ISNULL(SUM(dv.CantidadProducto * p.PrecioVenta), 0)
        FROM DetalleVenta dv
        INNER JOIN Producto p ON dv.IdProducto = p.IdProducto
        INNER JOIN Venta v ON dv.IdVenta = v.IdVenta
        WHERE v.FechaVenta BETWEEN @desde AND @hasta";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            try
            {
                Abrirconexion();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    totalVentas = Convert.ToDouble(result);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return totalVentas;
        }

        public double ObtenerTotalCompras(DateTime desde, DateTime hasta)
        {
            double totalCompras = 0;
            string sql = @"
        SELECT ISNULL(SUM(p.PrecioCompra * dv.CantidadProducto), 0)
        FROM DetalleVenta dv
        INNER JOIN Producto p ON dv.IdProducto = p.IdProducto
        INNER JOIN Venta v ON dv.IdVenta = v.IdVenta
        WHERE v.FechaVenta BETWEEN @desde AND @hasta";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            try
            {
                Abrirconexion();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    totalCompras = Convert.ToDouble(result);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return totalCompras;
        }
        public DataSet Union()
        {
            // Usamos FORMAT(vmp.Monto, 'C', 'es-AR') para que SQL devuelva el dinero formateado
            string orden = @"
        SELECT 
            dv.IdDetalleVenta, 
            dv.IdVenta, 
            dv.IdProducto, 
            dv.CantidadProducto,
            p.NombreProducto, 
            p.MarcaProducto, 
            p.PrecioVenta,
            (dv.CantidadProducto * p.PrecioVenta) AS SubtotalVenta, 
            v.FechaVenta,
            c.NombreCliente,
            ISNULL((
                SELECT STRING_AGG(mp_sub.NombreMetodoDePago + ': ' + FORMAT(vmp.Monto, 'C', 'es-AR'), ' | ')
                FROM VentaMetodoPago vmp
                JOIN MetodoDePago mp_sub ON vmp.IdMetodoDePago = mp_sub.IdMetodoDePago
                WHERE vmp.IdVenta = v.IdVenta
            ), FORMAT(v.SubtotalVenta, 'C', 'es-AR')) AS NombreMetodoDePago 
        FROM DetalleVenta dv
        LEFT JOIN Producto p ON dv.IdProducto = p.IdProducto
        LEFT JOIN Venta v ON dv.IdVenta = v.IdVenta
        LEFT JOIN Cliente c ON v.IdCliente = c.IdCliente
        LEFT JOIN MetodoDePago mp ON v.IdMetodoDePago = mp.IdMetodoDePago
        ORDER BY v.IdVenta DESC, dv.IdDetalleVenta DESC";
      

        SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                Abrirconexion();
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("Error en SQL Union: " + e.Message);
            }
            finally
            {
                Cerrarconexion();
            }
        }
    }
}
