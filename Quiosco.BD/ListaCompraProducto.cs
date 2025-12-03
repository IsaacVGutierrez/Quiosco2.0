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
    public class ListaCompraProducto : DatosConexionBD
    {

        public int abmCompraProducto(string accion, CompraProducto objCompraProducto)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = $"insert into CompraProducto values ('{objCompraProducto.SubtotalCompraProducto}','{objCompraProducto.FechaCompraProductos}','{objCompraProducto.MetodoDePago}','{objCompraProducto.IdProveedor}')";

            if (accion == "Modificar")
                orden = $"update CompraProducto set SubtotalCompraProducto = '{objCompraProducto.SubtotalCompraProducto}' where id = {objCompraProducto.IdCompraProducto};  update CompraProducto set FechaCompraProductos = '{objCompraProducto.FechaCompraProductos}' where id = {objCompraProducto.IdCompraProducto}; update CompraProducto set MetodoDePago = '{objCompraProducto.MetodoDePago}' where id = {objCompraProducto.IdCompraProducto}; update CompraProducto set IdProveedor = '{objCompraProducto.IdProveedor}' where id = {objCompraProducto.IdCompraProducto}; ";

            //if (accion == "Baja")
            //    orden = $"delete from CompraProducto where IdCompraProducto = {objCompraProducto.IdCompraProducto}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objCompraProducto} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoCompraProducto(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from CompraProducto where idCompraProducto = {int.Parse(id)};";
            else
                orden = "select * from CompraProducto;";
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
                throw new Exception("Error al listar Compra De Producto", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            //return ds;
        }



        public List<CompraProducto> ObtenerCompraProducto()
        {
            List<CompraProducto> lista = new List<CompraProducto>();

            string OrdenEjecucion = "Select IdCompraProducto, SubtotalCompraProducto, FechaCompraProductos, MetodoDePago , IdProveedor  from CompraProducto";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    CompraProducto compraProducto = new CompraProducto();

                    compraProducto.IdCompraProducto = dataReader.GetInt32(0);
                    compraProducto.SubtotalCompraProducto = Convert.ToDecimal(dataReader.GetDouble(1));
                    compraProducto.FechaCompraProductos = dataReader.GetDateTime(2);
                    compraProducto.MetodoDePago = dataReader.GetString(3);
                    compraProducto.IdProveedor = dataReader.GetInt32(4);

                   lista.Add(compraProducto);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de valores de la Compra de Producto", e);
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
            string orden = $" select c.IdCompraProducto, c.SubtotalCompraProducto, c.FechaCompraProductos, c.MetodoDePago,  m.NombreProveedor, m.TelefonoProveedor, m.DireccionProveedor, m.HorarioProveedor, m.DiasProveedor " +
                $" from  CompraProducto as c inner join Proveedor as m on c.IdCompraProducto= m.IdProveedor" +
                $" where c.IdCompraProducto like '%{cual}%' or c.SubtotalCompraProducto like '%{cual}%'  or c.FechaCompraProductos like '%{cual}%'   or c.MetodoDePago like '%{cual}%'  or m.NombreProveedor like '%{cual}%'  or m.TelefonoProveedor like '%{cual}%'  or m.DireccionProveedor like '%{cual}%'  or m.HorarioProveedor like '%{cual}%'  or m.DiasProveedor like '%{cual}%'; ";

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
                throw new Exception("Error al buscar la Compra de Producto", e);
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
            string orden = $"delete from CompraProducto where IdCompraProducto = {id};";

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
                throw new Exception("Error al eliminar la Compra de Producto", e);
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

            string orden = $" select c.IdCompraProducto, c.SubtotalCompraProducto, c.FechaCompraProductos, c.MetodoDePago,  m.NombreProveedor, m.TelefonoProveedor, m.DireccionProveedor, m.HorarioProveedor, m.DiasProveedor  from  CompraProducto as c inner join Proveedor as m on c.IdCompraProducto= m.IdProveedor";

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
                throw new Exception("Error al buscar los detalles de la Compra de Producto", e);
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