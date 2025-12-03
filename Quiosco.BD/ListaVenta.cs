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
    public class ListaVenta : DatosConexionBD
    {

        public int abmVenta(string accion, Venta objVenta)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = $"insert into Venta values ('{objVenta.SubtotalVenta}','{objVenta.FechaVenta}','{objVenta.MetodoDePagoVenta}','{objVenta.IdCliente}' ,'{objVenta.SaldoVenta}' )";

            if (accion == "Modificar")
                orden = $"update Venta set SubtotalVenta = '{objVenta.SubtotalVenta}' where id = {objVenta.IdVenta};  update Venta set FechaVenta = '{objVenta.FechaVenta}' where id = {objVenta.IdVenta}; update Venta set MetodoDePagoVenta = '{objVenta.MetodoDePagoVenta}' where id = {objVenta.IdVenta}; update Venta set IdCliente = '{objVenta.IdCliente}' where id = {objVenta.IdVenta};  update Venta set SaldoVenta = '{objVenta.SaldoVenta}' where id = {objVenta.IdVenta} ; ";

            //if (accion == "Baja")
            //    orden = $"delete from Venta where IdVenta = {objVenta.IdVenta}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objVenta} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoVenta(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from Venta where idVenta = {int.Parse(id)};";
            else
                orden = "select * from Venta;";
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
                throw new Exception("Error al listar Venta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            //return ds;
        }



        public List<Venta> ObtenerVenta()
        {
            List<Venta> lista = new List<Venta>();

            string OrdenEjecucion = "Select IdVenta, SubtotalVenta, FechaVenta, MetodoDePagoVenta , IdCliente , SaldoVenta  from Venta";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Venta venta = new Venta();

                    venta.IdVenta = dataReader.GetInt32(0);
                    venta.SubtotalVenta = Convert.ToDecimal(dataReader.GetDouble(1));
                    venta.FechaVenta = dataReader.GetDateTime(2);
                    venta.MetodoDePagoVenta = dataReader.GetString(3);
                    venta.IdCliente = dataReader.GetInt32(4);
                    venta.SaldoVenta = Convert.ToDecimal(dataReader.GetDouble(5));

                    lista.Add(venta);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de valores de la Venta", e);
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
            string orden = $" select v.IdVenta, v.SubtotalVenta, v.FechaVenta, v.MetodoDePagoVenta, v.SaldoVenta, k.NombreCliente, k.TelefonoCliente, k.AdeudaCliente" +
                $" from  Venta as v inner join Cliente as k on v.IdVenta=k.IdCliente" +
                $" where v.IdVenta like '%{cual}%' or v.SubtotalVenta like '%{cual}%'  or v.FechaVenta like '%{cual}%'   or v.MetodoDePagoVenta like '%{cual}%'  or v.SaldoVenta like '%{cual}%'  or k.NombreCliente like '%{cual}%'  or k.TelefonoCliente like '%{cual}%'  or k.AdeudaCliente like '%{cual}%' ; ";

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

            string orden = $"delete from Venta where IdVenta = {id}";

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

            string orden = $" select v.IdVenta, v.SubtotalVenta, v.FechaVenta, v.MetodoDePagoVenta, v.SaldoVenta, k.NombreCliente, k.TelefonoCliente, k.AdeudaCliente from  Venta as v inner join Cliente as k on v.IdVenta=k.IdCliente ";
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
                throw new Exception("Error al buscar los detalles de la Venta", e);
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