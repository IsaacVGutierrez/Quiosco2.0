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
    public class ListaDetalleVenta : DatosConexionBD
    {

        public int abmDetalleVenta(string accion, DetalleVenta objDetalleVenta)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = $"insert into DetalleVenta values ('{objDetalleVenta.IdVenta}','{objDetalleVenta.IdProducto}','{objDetalleVenta.CantidadProducto}')";

            if (accion == "Modificar")
                orden = $"update DetalleVenta set IdVenta = '{objDetalleVenta.IdVenta}' where id = {objDetalleVenta.IdDetalleVenta};  update DetalleVenta set IdProducto = '{objDetalleVenta.IdProducto}' where id = {objDetalleVenta.IdDetalleVenta}; update DetalleVenta set CantidadProducto = '{objDetalleVenta.CantidadProducto}' where id = {objDetalleVenta.IdDetalleVenta};";

            //if (accion == "Baja")
            //    orden = $"delete from DetalleVenta where Id = {objDetalleVenta.IdDetalleVenta}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objDetalleVenta} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoDetalleVenta(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from DetalleVenta where idDetalleVenta = {int.Parse(id)};";
            else
                orden = "select * from DetalleVenta;";
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
                throw new Exception("Error al listar Detalle de Venta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            //return ds;
        }




        public List<DetalleVenta> ObtenerDetalleVenta()
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();

            string OrdenEjecucion = "Select IdDetalleVenta, IdVenta, IdProducto, CantidadProducto from DetalleVenta";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    DetalleVenta detalleVenta = new DetalleVenta();

                    detalleVenta.IdDetalleVenta = dataReader.GetInt32(0);
                    detalleVenta.IdVenta = dataReader.GetInt32(1);
                    detalleVenta.IdProducto = dataReader.GetInt32(2);
                    detalleVenta.CantidadProducto = dataReader.GetInt32(3);
                                                  

                    lista.Add(detalleVenta);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de valores de Detalle de Venta", e);
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
            string orden = $" select c.IdDetalleVenta, c.CantidadProducto, v.SubtotalVenta, v.FechaVenta, v.MetodoDePagoVenta, v.SaldoVenta, k.NombreCliente, k.TelefonoCliente, k.AdeudaCliente, p.NombreProducto, p.MarcaProducto, p.PrecioProducto, p.CantidadProducto, p.PrecioCompra, p.PrecioVenta, m.NombreCategoria " +
                $"from  DetalleVenta as c inner join Venta as v on c.IdDetalleVenta=v.IdVenta inner join Cliente as k on c.IdDetalleVenta=k.IdCliente   inner join Producto as p on c.IdDetalleVenta=p.IdProducto   inner join Categoria as m on c.IdDetalleVenta=m.IdCategoria  " +
                $"where c.IdDetalleVenta like '%{cual}%' or c.CantidadProducto like '%{cual}%'  or v.SubtotalVenta like '%{cual}%'   or v.FechaVenta like '%{cual}%'  or v.MetodoDePagoVenta like '%{cual}%'  or v.SaldoVenta like '%{cual}%'  or k.NombreCliente like '%{cual}%'  or k.TelefonoCliente like '%{cual}%'  or k.AdeudaCliente like '%{cual}%' or p.NombreProducto like '%{cual}%' or p.MarcaProducto like '%{cual}%' or p.PrecioProducto like '%{cual}%' or p.PrecioCompra like '%{cual}%' or p.PrecioVenta like '%{cual}%' or p.NombreCategoria like '%{cual}%' ; ";

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
                throw new Exception("Error al buscar Detalle de Venta", e);
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

            string orden = $"delete from DetalleVenta where IdDetalleVenta = {id}";

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
                throw new Exception("Error al eliminar el Detalle de Venta", e);
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

            string orden = $" select c.IdDetalleVenta, c.CantidadProducto, v.SubtotalVenta, v.FechaVenta, v.MetodoDePagoVenta, v.SaldoVenta, k.NombreCliente, k.TelefonoCliente, k.AdeudaCliente, p.NombreProducto, p.MarcaProducto, p.PrecioProducto, p.CantidadProducto, p.PrecioCompra, p.PrecioVenta, m.NombreCategoria from  DetalleVenta as c inner join Venta as v on c.IdDetalleVenta=v.IdVenta inner join Cliente as k on c.IdDetalleVenta=k.IdCliente   inner join Producto as p on c.IdDetalleVenta=p.IdProducto   inner join Categoria as m on c.IdDetalleVenta=m.IdCategoria  ";

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
                throw new Exception("Error al buscar los detalles de DetalleVenta", e);
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