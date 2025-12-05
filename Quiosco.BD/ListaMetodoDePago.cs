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
    public class ListaMetodoDePago : DatosConexionBD
    {

        public int abmMetodoDePago(string accion, MetodoDePago objMetodoDePago)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = $"insert into MetodoDePago values ('{objMetodoDePago.NombreMetodoDePago}')";

            if (accion == "Modificar")
                orden = $"update MetodoDePago set NombreMetodoDePago = '{objMetodoDePago.NombreMetodoDePago}' where IdMetodoDePago = {objMetodoDePago.IdMetodoDePago};";

            if (accion == "Baja")
                orden = $"delete from MetodoDePago where IdMetodoDePago = {objMetodoDePago.IdMetodoDePago}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objMetodoDePago} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoMetodoDePago(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from MetodoDePago where idMetodoDePago = {int.Parse(id)};";
            else
                orden = "select * from MetodoDePago;";
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
                throw new Exception("Error al listar MetodoDePago", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }



        public List<MetodoDePago> ObtenerMetodoDePago()
        {
            List<MetodoDePago> lista = new List<MetodoDePago>();

            string OrdenEjecucion = "Select IdMetodoDePago, NombreMetodoDePago  from MetodoDePago";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    MetodoDePago metodoDePago = new MetodoDePago();

                    metodoDePago.IdMetodoDePago = dataReader.GetInt32(0);
                    metodoDePago.NombreMetodoDePago = dataReader.GetString(1);

                    lista.Add(metodoDePago);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de valores del Metodo De Pago", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }


        public DataSet listarMetodoDePagoBuscar(string cual)
        {
            string orden = $"select * from MetodoDePago where IdMetodoDePago like '%{cual}%' or NombreMetodoDePago like '%{cual}%';";

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
                throw new Exception("Error al buscar el Metodo De Pago", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet ListarMetodoDePagoEliminar(string idMetodoDePago)
        {

            string orden = $"delete from MetodoDePago where IdMetodoDePago = {idMetodoDePago}";

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
                throw new Exception("Error al eliminar los detalles del Metodo De Pago", e);
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