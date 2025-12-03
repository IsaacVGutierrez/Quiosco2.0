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
    public class ListaProveedor : DatosConexionBD
    {

        public int abmProveedor(string accion, Proveedor objProveedor)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = $"insert into Proveedor values ('{objProveedor.NombreProveedor}','{objProveedor.TelefonoProveedor}','{objProveedor.DireccionProveedor}','{objProveedor.HorarioProveedor}' ,'{objProveedor.DiasProveedor}')";

            if (accion == "Modificar")
                orden = $"update Proveedor set NombreProveedor = '{objProveedor.NombreProveedor}' where IdProveedor = {objProveedor.IdProveedor};  update Proveedor set TelefonoProveedor = '{objProveedor.TelefonoProveedor}' where IdProveedor = {objProveedor.IdProveedor}; update Proveedor set DireccionProveedor = '{objProveedor.DireccionProveedor}' where IdProveedor = {objProveedor.IdProveedor}; update Proveedor set HorarioProveedor = '{objProveedor.HorarioProveedor}' where IdProveedor = {objProveedor.IdProveedor};  update Proveedor set DiasProveedor = '{objProveedor.DiasProveedor}' where IdProveedor = {objProveedor.IdProveedor}; ";

            if (accion == "Baja")
                orden = $"delete from Proveedor where IdProveedor = {objProveedor.IdProveedor}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objProveedor} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoProveedor(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from Proveedor where idProveedor = {int.Parse(id)};";
            else
                orden = "select * from Proveedor;";
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
                return ds = null;
                throw new Exception("Error al listar Proveedor", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }



        public List<Proveedor> ObtenerProveedor()
        {
            List<Proveedor> lista = new List<Proveedor>();

            string OrdenEjecucion = "Select IdProveedor, NombreProveedor, TelefonoProveedor, DireccionProveedor , HorarioProveedor, DiasProveedor  from Proveedor";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Proveedor proveedor = new Proveedor();

                    proveedor.IdProveedor = dataReader.GetInt32(0);
                    proveedor.NombreProveedor = dataReader.GetString(1);
                    proveedor.TelefonoProveedor = dataReader.GetString(2);
                    proveedor.DireccionProveedor = dataReader.GetString(3);
                    proveedor.HorarioProveedor = dataReader.GetString(4);
                    proveedor.DiasProveedor = dataReader.GetString(5);
                   
                    lista.Add(proveedor);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de valores del Proveedor", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }

        public DataSet listarProveedorBuscar(string cual)
        {
            string orden = $"select * from Proveedor where IdProveedor like '%{cual}%' or NombreProveedor like '%{cual}%' or TelefonoProveedor like '%{cual}%'  or DireccionProveedor like '%{cual}%' or HorarioProveedor like '%{cual}%' or DiasProveedor like '%{cual}%' ;";

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
                throw new Exception("Error al buscar Proveedor", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet ListarProveedorEliminar(string id)
        {

            string orden = $"delete from Proveedor where IdProveedor = {id}";

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
                throw new Exception("Error al eliminar el producto", e);
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