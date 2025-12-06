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

    public class ListaCliente : DatosConexionBD
    {

        public int abmCliente(string accion, Cliente objCliente)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = $"insert into Cliente values ('{objCliente.NombreCliente}', '{objCliente.TelefonoCliente}', {objCliente.AdeudaCliente.ToString(System.Globalization.CultureInfo.InvariantCulture)})";

            if (accion == "Modificar")
                orden = $"update Cliente set AdeudaCliente = {objCliente.AdeudaCliente.ToString(System.Globalization.CultureInfo.InvariantCulture)} where IdCliente = {objCliente.IdCliente};";

            if (accion == "ModificarSoloDeuda")
                orden = $"update Cliente set AdeudaCliente = {objCliente.AdeudaCliente.ToString(System.Globalization.CultureInfo.InvariantCulture)} where IdCliente = {objCliente.IdCliente};";


            if (accion == "Baja")
               orden = $"delete from Cliente where IdCliente = {objCliente.IdCliente}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objCliente} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoCliente(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from Cliente where idCliente = {int.Parse(id)};";
            else
                orden = "select * from Cliente;";
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
                throw new Exception("Error al listar Cliente", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            
            return ds;
        }



        public List<Cliente> ObtenerCliente()
        {
            List<Cliente> lista = new List<Cliente>();

            string OrdenEjecucion = "Select IdCliente, NombreCliente, TelefonoCliente, AdeudaCliente  from Cliente";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.IdCliente = dataReader.GetInt32(0);
                    cliente.NombreCliente = dataReader.GetString(1);
                    cliente.TelefonoCliente = dataReader.GetString(2);
                    cliente.AdeudaCliente = dataReader.GetDecimal(3);



                    lista.Add(cliente);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de valores del Cliente", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }


        public DataSet listarClienteBuscar(string cual)
        {
            string orden = $"select * from Cliente where IdCliente like '%{cual}%' or NombreCliente like '%{cual}%' or TelefonoCliente like '%{cual}%' or AdeudaCliente like '%{cual}%';";

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
                throw new Exception("Error al buscar el Cliente", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet ListarClienteEliminar(string id)
        {
            string orden = $"delete from Cliente where IdCliente = {id};";

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
                throw new Exception("Error al eliminar el Cliente", e);
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

