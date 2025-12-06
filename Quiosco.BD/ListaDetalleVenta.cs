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
                       v.SubtotalVenta, v.FechaVenta, mp.NombreMetodoDePago, c.NombreCliente,
                       p.NombreProducto, p.MarcaProducto
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

        public DataSet Union()
        {
            string orden = @"
                SELECT dv.IdDetalleVenta, dv.IdVenta, dv.IdProducto, dv.CantidadProducto,
                       p.NombreProducto, p.MarcaProducto, p.PrecioProducto, v.SubtotalVenta, v.FechaVenta, c.NombreCliente
                FROM DetalleVenta dv
                LEFT JOIN Producto p ON dv.IdProducto = p.IdProducto
                LEFT JOIN Venta v ON dv.IdVenta = v.IdVenta
                LEFT JOIN Cliente c ON v.IdCliente = c.IdCliente
                ORDER BY dv.IdDetalleVenta DESC";
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
                throw new Exception("Error al obtener union DetalleVenta", e);
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
