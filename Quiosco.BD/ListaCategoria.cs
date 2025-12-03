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
    public class ListaCategoria : DatosConexionBD
    {

        public int abmCategoria(string accion, Categoria objCategoria)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = $"insert into Categoria values ('{objCategoria.NombreCategoria}')";

            if (accion == "Modificar")
                orden = $"update Categoria set NombreCategoria = '{objCategoria.NombreCategoria}' where IdCategoria = {objCategoria.IdCategoria};";

            if (accion == "Baja")
               orden = $"delete from Categoria where IdCategoria = {objCategoria.IdCategoria}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objCategoria} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoCategoria(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from Categoria where idCategoria = {int.Parse(id)};";
            else
                orden = "select * from Categoria;";
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
                throw new Exception("Error al listar Categoria", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }



        public List<Categoria> ObtenerCategoria()
        {
            List<Categoria> lista = new List<Categoria>();

            string OrdenEjecucion = "Select IdCategoria, NombreCategoria  from Categoria";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.IdCategoria = dataReader.GetInt32(0);
                    categoria.NombreCategoria = dataReader.GetString(1);
                    
                    lista.Add(categoria);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de valores de la Categoria", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }


        public DataSet listarCategoriaBuscar(string cual)
        {
            string orden = $"select * from Categoria where IdCategoria like '%{cual}%' or NombreCategoria like '%{cual}%';";

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
                throw new Exception("Error al buscar la Categoria", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet ListarCategoriaEliminar(string idCategoria)
        {

            string orden = $"delete from Categoria where IdCategoria = {idCategoria}";

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
                throw new Exception("Error al eliminar los detalles la Categoria", e);
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