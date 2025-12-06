using Microsoft.Data.SqlClient;
using Quiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.BD
{
    public class ListaDetalleCompra : DatosConexionBD
    {

        public int abmDetalleCompra(string accion, DetalleCompra objDetalleCompra)
        {
            int resultado = -1;
            if (accion == "Alta")
            {
                string sql = @"
            INSERT INTO DetalleCompra (IdCompraProducto, IdProducto, CantidadProducto)
            VALUES (@idCompra, @idProducto, @cantidad);
            SELECT CAST(SCOPE_IDENTITY() AS INT);
        ";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idCompra", objDetalleCompra.IdCompraProducto);
                cmd.Parameters.AddWithValue("@idProducto", objDetalleCompra.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", objDetalleCompra.CantidadProducto);

                try
                {
                    Abrirconexion();
                    object o = cmd.ExecuteScalar();
                    if (o != null) resultado = Convert.ToInt32(o);
                }
                catch (Exception e)
                {
                    throw new Exception("Error al insertar DetalleCompra", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
                return resultado;
            }

            // modificar / borrar si necesitás...
            return -1;
        }


        public DataSet listadoDetalleCompra(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from DetalleCompra where idDetalleCompra = {int.Parse(id)};";
            else
                orden = "select * from DetalleCompra;";
            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);

                return ds;
            }
            catch (Exception e)
            {
                return ds = null;
                throw new Exception("Error al listar Detalle de Compra", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            //return ds;
        }



        public List<DetalleCompra> ObtenerDetalleCompra()
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();

            string OrdenEjecucion = "Select IdDetalleCompra, IdCompraProducto, IdProducto, CantidadProducto from DetalleCompra";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    DetalleCompra detalleCompra = new DetalleCompra();

                    detalleCompra.IdDetalleCompra = dataReader.GetInt32(0);
                    detalleCompra.IdCompraProducto = dataReader.GetInt32(1);
                    detalleCompra.IdProducto = dataReader.GetInt32(2);
                    detalleCompra.CantidadProducto = dataReader.GetInt32(3);
                  

                   

                    lista.Add(detalleCompra);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de valores de Detalle de Compra", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }

         

        public DataSet listarDetalleCompraBuscar(string cual)
        {
            string orden = $" select z.IdDetalleCompra, z.CantidadProducto,  c.SubtotalCompraProducto, c.FechaCompraProductos, c.MetodoDePago,  m.NombreProveedor, m.TelefonoProveedor, m.DireccionProveedor, m.HorarioProveedor, m.DiasProveedor, p.NombreProducto, p.MarcaProducto, p.PrecioProducto, p.CantidadProducto, p.PrecioCompra, p.PrecioVenta, m.NombreCategoria" +
                $" from  DetalleCompra as z inner join CompraProducto as c on z.IdDetalleCompra=c.IdCompraProducto inner join Proveedor as m on z.IdDetalleCompra=m.IdProveedor  inner join Producto as p on z.IdDetalleCompra=p.IdProducto   inner join Categoria as m on z.IdDetalleCompra=p.IdCategoria  " +
                $"where z.IdDetalleCompra like '%{cual}%' or z.CantidadProducto like '%{cual}%'  or  c.SubtotalCompraProducto like '%{cual}%'   or c.FechaCompraProductos like '%{cual}%'  or  c.MetodoDePago like '%{cual}%'  or  m.NombreProveedor like '%{cual}%'  or m.TelefonoProveedor like '%{cual}%'  or m.HorarioProveedor like '%{cual}%'  or m.DiasProveedor like '%{cual}%' or  p.NombreProducto like '%{cual}%' or  p.MarcaProducto like '%{cual}%' or  p.PrecioProducto like '%{cual}%' or  p.CantidadProducto like '%{cual}%' or  p.PrecioCompra like '%{cual}%' or  p.PrecioVenta like '%{cual}%' or  p.NombreCategoria like '%{cual}%' ; ";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al buscar Detalle de Compra", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet ListarDetalleCompraEliminar(string id)
        {

            string orden = $"delete from DetalleCompra where IdetalleCompra = {id}";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar el Detalle de Compra", e);
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

            string orden = $" select z.IdDetalleCompra, z.CantidadProducto,  c.SubtotalCompraProducto, c.FechaCompraProductos, c.MetodoDePago,  m.NombreProveedor, m.TelefonoProveedor, m.DireccionProveedor, m.HorarioProveedor, m.DiasProveedor, p.NombreProducto, p.MarcaProducto, p.PrecioProducto, p.CantidadProducto, p.PrecioCompra, p.PrecioVenta, m.NombreCategoria from  DetalleCompra as z inner join CompraProducto as c on z.IdDetalleCompra=c.IdCompraProducto inner join Proveedor as m on z.IdDetalleCompra=m.IdProveedor  inner join Producto as p on z.IdDetalleCompra=p.IdProducto   inner join Categoria as m on z.IdDetalleCompra=p.IdCategoria ";

             SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al buscar los Detalle de Compra", e);
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