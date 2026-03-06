using Microsoft.Data.SqlClient;
using Quiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.BD
{
    public class ListaVentaMetodoPago : DatosConexionBD
    {
        public int abmVentaMetodoPago(string accion, VentaMetodoPago objPago)
        {
            int resultado = -1;

            if (accion == "Alta")
            {
                string sql = @"
                    INSERT INTO VentaMetodoPago (IdVenta, IdMetodoDePago, Monto)
                    OUTPUT INSERTED.IdVentaMetodoPago
                    VALUES (@idVenta, @idMetodoPago, @monto);
                ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idVenta", objPago.IdVenta);
                cmd.Parameters.AddWithValue("@idMetodoPago", objPago.IdMetodoDePago);
                cmd.Parameters.AddWithValue("@monto", objPago.Monto);

                try
                {
                    Abrirconexion();
                    object o = cmd.ExecuteScalar();
                    if (o != null) resultado = Convert.ToInt32(o);
                }
                catch (Exception e)
                {
                    throw new Exception("Error al insertar VentaMetodoPago", e);
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
                    UPDATE VentaMetodoPago SET
                        IdVenta = @idVenta,
                        IdMetodoDePago = @idMetodoPago,
                        Monto = @monto
                    WHERE IdVentaMetodoPago = @idPago;
                ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idVenta", objPago.IdVenta);
                cmd.Parameters.AddWithValue("@idMetodoPago", objPago.IdMetodoDePago);
                cmd.Parameters.AddWithValue("@monto", objPago.Monto);
                cmd.Parameters.AddWithValue("@idPago", objPago.IdVentaMetodoPago);

                try
                {
                    Abrirconexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al modificar VentaMetodoPago", e);
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
                string sql = "DELETE FROM VentaMetodoPago WHERE IdVentaMetodoPago = @idPago";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idPago", objPago.IdVentaMetodoPago);

                try
                {
                    Abrirconexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al eliminar VentaMetodoPago", e);
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

        public List<VentaMetodoPago> ObtenerPagosPorVenta(int idVenta)
        {
            List<VentaMetodoPago> lista = new List<VentaMetodoPago>();
            string sql = @"
                SELECT IdVentaMetodoPago, IdVenta, IdMetodoDePago, Monto
                FROM VentaMetodoPago
                WHERE IdVenta = @idVenta
            ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idVenta", idVenta);

            SqlDataReader reader;

            try
            {
                Abrirconexion();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VentaMetodoPago pago = new VentaMetodoPago
                    {
                        IdVentaMetodoPago = reader.GetInt32(0),
                        IdVenta = reader.GetInt32(1),
                        IdMetodoDePago = reader.GetInt32(2),
                        Monto = reader.GetDecimal(3)
                    };
                    lista.Add(pago);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener pagos de la venta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }
    }
}
