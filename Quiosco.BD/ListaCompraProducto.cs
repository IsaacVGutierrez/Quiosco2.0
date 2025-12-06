using Microsoft.Data.SqlClient;
using Quiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Quiosco.BD
{
    public class ListaCompraProducto : DatosConexionBD
    {

        public int abmCompraProducto(string accion, CompraProducto objCompraProducto)
        {
            int resultado = -1;

            if (accion == "Alta")
            {
                string sql = @"
                    INSERT INTO CompraProducto
                  (SubtotalCompraProducto, FechaCompraProductos, IdMetodoDePago, IdProveedor)
                   VALUES (@subtotal, @fecha, @metodo, @idProveedor);
                  SELECT CAST(SCOPE_IDENTITY() AS INT);
                   ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@subtotal", objCompraProducto.SubtotalCompraProducto);
                cmd.Parameters.AddWithValue("@fecha", objCompraProducto.FechaCompraProductos);
                // IdMetodoDePago ahora es int (no string)
                cmd.Parameters.AddWithValue("@metodo", objCompraProducto.IdMetodoDePago);
                cmd.Parameters.AddWithValue("@idProveedor", objCompraProducto.IdProveedor);

                try
                {
                    Abrirconexion();
                    object o = cmd.ExecuteScalar();
                    if (o != null) resultado = Convert.ToInt32(o);
                }
                catch (Exception e)
                {
                    throw new Exception("Error al insertar CompraProducto", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
                return resultado;
            }
           
                                          

                 return -1;
        }


        public int ModificarCompra(CompraProducto obj)
        {
            string sql = @"
        UPDATE CompraProducto SET
            IdProveedor = @prov,
            IdMetodoDePago = @metodo,
            FechaCompraProductos = @fecha
        WHERE IdCompraProducto = @id;
    ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@prov", obj.IdProveedor);
            cmd.Parameters.AddWithValue("@metodo", obj.IdMetodoDePago);
            cmd.Parameters.AddWithValue("@fecha", obj.FechaCompraProductos);
            cmd.Parameters.AddWithValue("@id", obj.IdCompraProducto);

            try
            {
                Abrirconexion();
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
        }




        public DataSet listadoCompraProducto(string id)
        {
            string orden;

            if (id != "Todos")
                orden = $"SELECT * FROM CompraProducto WHERE IdCompraProducto = {id}";
            else
                orden = "SELECT * FROM CompraProducto";

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
                throw new Exception("Error al listar CompraProducto", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
        }

        public List<CompraProducto> ObtenerCompraProducto()
        {
            List<CompraProducto> lista = new List<CompraProducto>();

            string sql = @"SELECT IdCompraProducto, SubtotalCompraProducto,
               FechaCompraProductos, IdMetodoDePago, IdProveedor
               FROM CompraProducto";

            SqlCommand cmd = new SqlCommand(sql, conexion);

            try
            {
                Abrirconexion();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CompraProducto cp = new CompraProducto();

                    cp.IdCompraProducto = dr.GetInt32(0);
                    // Subtotal puede venir como decimal -> leer con GetDecimal
                    cp.SubtotalCompraProducto = dr.GetDecimal(1);
                    cp.FechaCompraProductos = dr.GetDateTime(2);
                    // IdMetodoDePago ahora es int
                    cp.IdMetodoDePago = dr.GetInt32(3);
                    cp.IdProveedor = dr.GetInt32(4);

                    lista.Add(cp);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener lista de CompraProducto", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }

        public DataSet listarCompraProductoBuscar(string cual)
        {
            string sql =
            $@"SELECT 
            c.IdCompraProducto,
            c.SubtotalCompraProducto,
            c.FechaCompraProductos,
            mp.NombreMetodoDePago,
            m.NombreProveedor,
            m.TelefonoProveedor,
            m.DireccionProveedor,
            m.HorarioProveedor,
            m.DiasProveedor
        FROM CompraProducto AS c
        INNER JOIN Proveedor AS m ON c.IdProveedor = m.IdProveedor
        INNER JOIN MetodoPago AS mp ON c.IdMetodoDePago = mp.IdMetodoDePago
        WHERE
            c.IdCompraProducto LIKE '%{cual}%'
            OR c.SubtotalCompraProducto LIKE '%{cual}%'
            OR CONVERT(VARCHAR(10), c.FechaCompraProductos, 120) LIKE '%{cual}%'
            OR mp.NombreMetodoDePago LIKE '%{cual}%'
            OR m.NombreProveedor LIKE '%{cual}%'
            OR m.TelefonoProveedor LIKE '%{cual}%'
            OR m.DireccionProveedor LIKE '%{cual}%'
            OR m.HorarioProveedor LIKE '%{cual}%'
            OR m.DiasProveedor LIKE '%{cual}%'
    ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return ds;
        }


        public DataSet ListarCompraProductoEliminar(string id)
        {
            string sql = $"DELETE FROM CompraProducto WHERE IdCompraProducto = {id}";

            SqlCommand cmd = new SqlCommand(sql, conexion);
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
                throw new Exception("Error al eliminar CompraProducto", e);
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
            string sql =
            @"SELECT 
            c.IdCompraProducto,
            c.SubtotalCompraProducto,
            c.FechaCompraProductos,
            mp.NombreMetodoDePago,
            m.NombreProveedor,
            m.TelefonoProveedor,
            m.DireccionProveedor,
            m.HorarioProveedor,
            m.DiasProveedor
        FROM CompraProducto AS c
        INNER JOIN Proveedor AS m ON c.IdProveedor = m.IdProveedor
        INNER JOIN MetodoPago AS mp ON c.IdMetodoDePago = mp.IdMetodoDePago";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
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