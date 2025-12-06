using Microsoft.Data.SqlClient;
using Quiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Quiosco.BD
{
    public class ListaVenta : DatosConexionBD
    {
        public int abmVenta(string accion, Venta objVenta)
        {
            int resultado = -1;

            if (accion == "Alta")
            {
                string sql = @"
                    INSERT INTO Venta (SubtotalVenta, FechaVenta, IdMetodoDePago, IdCliente, SaldoVenta)
                    OUTPUT INSERTED.IdVenta
                    VALUES (@subtotal, @fecha, @idMetodoPago, @idCliente, @saldo)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@subtotal", objVenta.SubtotalVenta);
                cmd.Parameters.AddWithValue("@fecha", objVenta.FechaVenta);
                cmd.Parameters.AddWithValue("@idMetodoPago", objVenta.IdMetodoDePagoVenta);
                cmd.Parameters.AddWithValue("@idCliente", objVenta.IdCliente);
                cmd.Parameters.AddWithValue("@saldo", objVenta.SaldoVenta);

                try
                {
                    Abrirconexion();
                    object o = cmd.ExecuteScalar();
                    if (o != null) resultado = Convert.ToInt32(o);
                }
                catch (Exception e)
                {
                    throw new Exception("Error al insertar Venta", e);
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
                    UPDATE Venta
                    SET SubtotalVenta = @subtotal,
                        FechaVenta = @fecha,
                        IdMetodoDePago = @idMetodoPago,
                        IdCliente = @idCliente,
                        SaldoVenta = @saldo
                    WHERE IdVenta = @idVenta";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@subtotal", objVenta.SubtotalVenta);
                cmd.Parameters.AddWithValue("@fecha", objVenta.FechaVenta);
                cmd.Parameters.AddWithValue("@idMetodoPago", objVenta.IdMetodoDePagoVenta);
                cmd.Parameters.AddWithValue("@idCliente", objVenta.IdCliente);
                cmd.Parameters.AddWithValue("@saldo", objVenta.SaldoVenta);
                cmd.Parameters.AddWithValue("@idVenta", objVenta.IdVenta);

                try
                {
                    Abrirconexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al modificar Venta", e);
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

        public DataSet listadoVenta(string id)
        {
            string orden;
            if (id != "Todos")
            {
                orden = $@"
            SELECT v.IdVenta,
                   p.NombreProducto,
                   dv.CantidadProducto,
                   v.SubtotalVenta,
                   mp.NombreMetodoDePago,
                   c.NombreCliente,
                   v.FechaVenta
            FROM Venta v
            INNER JOIN DetalleVenta dv ON v.IdVenta = dv.IdVenta
            INNER JOIN Producto p ON dv.IdProducto = p.IdProducto
            INNER JOIN Cliente c ON v.IdCliente = c.IdCliente
            INNER JOIN MetodoDePago mp ON v.IdMetodoDePago = mp.IdMetododePago
            WHERE v.IdVenta = {int.Parse(id)}
            ORDER BY v.IdVenta DESC";
            }
            else
            {
                orden = @"
            SELECT v.IdVenta,
                   p.NombreProducto,
                   dv.CantidadProducto,
                   v.SubtotalVenta,
                   mp.NombreMetodoDePago,
                   c.NombreCliente,
                   v.FechaVenta
            FROM Venta v
            INNER JOIN DetalleVenta dv ON v.IdVenta = dv.IdVenta
            INNER JOIN Producto p ON dv.IdProducto = p.IdProducto
            INNER JOIN Cliente c ON v.IdCliente = c.IdCliente
            INNER JOIN MetodoDePago mp ON v.IdMetodoDePago = mp.IdMetododePago
            ORDER BY v.IdVenta DESC";
            }

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
                throw new Exception("Error al listar Venta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
        }



        public List<Venta> ObtenerVenta()
        {
            List<Venta> lista = new List<Venta>();
            string sql = "SELECT IdVenta, SubtotalVenta, FechaVenta, IdMetodoDePago, IdCliente, SaldoVenta FROM Venta";
            SqlCommand cmd = new SqlCommand(sql, conexion);

            try
            {
                Abrirconexion();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Venta v = new Venta
                    {
                        IdVenta = dr.GetInt32(0),
                        SubtotalVenta = dr.GetDecimal(1),
                        FechaVenta = dr.GetDateTime(2),
                        IdMetodoDePagoVenta = dr.GetInt32(3),
                        IdCliente = dr.GetInt32(4),
                        SaldoVenta = dr.GetDecimal(5)
                    };
                    lista.Add(v);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener la lista de Venta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return lista;
        }

        public DataSet listarVentaBuscar(string cual)
        {
            string orden = @"
                SELECT v.IdVenta, v.SubtotalVenta, v.FechaVenta, mp.NombreMetodoDePago, k.NombreCliente, v.SaldoVenta
                FROM Venta v
                LEFT JOIN Cliente k ON v.IdCliente = k.IdCliente
                LEFT JOIN MetodoDePago mp ON v.IdMetodoDePago = mp.IdMetodoDePago
                WHERE
                    v.IdVenta LIKE @buscar OR
                    v.SubtotalVenta LIKE @buscar OR
                    CONVERT(VARCHAR(30), v.FechaVenta, 23) LIKE @buscar OR
                    mp.NombreMetodoDePago LIKE @buscar OR
                    k.NombreCliente LIKE @buscar OR
                    v.SaldoVenta LIKE @buscar
                ORDER BY v.IdVenta DESC";
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
                throw new Exception("Error al buscar la Venta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet ListarVentaEliminar(string id)
        {
            string orden = $"DELETE FROM Venta WHERE IdVenta = {id}";
            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                // no hay filas para llenar, pero retornamos ds vacio por compatibilidad
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar Venta", e);
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
                SELECT v.IdVenta, v.SubtotalVenta, v.FechaVenta, mp.NombreMetodoDePago, k.NombreCliente, v.SaldoVenta
                FROM Venta v
                LEFT JOIN Cliente k ON v.IdCliente = k.IdCliente
                LEFT JOIN MetodoDePago mp ON v.IdMetodoDePago = mp.IdMetodoDePago
                ORDER BY v.IdVenta DESC";
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
                throw new Exception("Error al obtener union Venta", e);
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
