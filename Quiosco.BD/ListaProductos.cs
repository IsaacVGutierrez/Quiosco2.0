using Quiosco.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Quiosco.BD
{
    public class ListaProductos : DatosConexionBD
    {

        public int abmProducto(string accion, Producto objProducto)
        {


            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")

                orden = $"insert into Producto values ('{objProducto.NombreProducto}','{objProducto.MarcaProducto}','{objProducto.PrecioProducto}' ,'{objProducto.CantidadProducto}' ,'{objProducto.PrecioCompra}' ,'{objProducto.PrecioVenta}' ,'{objProducto.IdCategoria}')";

            if (accion == "Modificar")
               orden = $"update Producto set NombreProducto = '{objProducto.NombreProducto}' where id = {objProducto.IdProducto}; update Producto set MarcaProducto = '{objProducto.MarcaProducto}' where id = {objProducto.IdProducto}; update Producto set PrecioProducto = '{objProducto.PrecioProducto}' where id = {objProducto.IdProducto}; update Producto set CantidadProducto = {objProducto.CantidadProducto} where id = {objProducto.IdProducto};  update Producto set PrecioCompra = '{objProducto.PrecioCompra}' where id = {objProducto.IdProducto};  update Producto set PrecioVenta = '{objProducto.PrecioVenta}' where id = {objProducto.IdProducto};  update Producto set IdCategoria = '{objProducto.IdCategoria}' where id = {objProducto.IdProducto}; ";

            if (accion == "Baja")

               orden = $"delete from Producto where IdProducto = {objProducto.IdProducto}";


            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar,borrar o modificar {objProducto} ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoProducto(string id)
        {
            string orden = string.Empty;
            if (id != "Todos")
                orden = $"select * from Producto where idProducto = {int.Parse(id)};";
            else
                orden = "select * from Producto;";
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
                throw new Exception("Error al listar Producto", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            //return ds;
        }


        public List<Producto> ObtenerProducto()
        {

            List<Producto> lista = new List<Producto>();


            string OrdenEjecucion = "Select IdProducto, NombreProducto , MarcaProducto , PrecioProducto, CantidadProducto ,PrecioCompra , PrecioVenta, IdCategoria from Producto";

            


            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);

            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    //VER ESTA LINEA EN EL CODIGO ORIGINAL PARA VER PARA QUE SIRVE
                    string productos = dataReader.GetString(2);
                    int precio = dataReader.GetInt32(3);
                    string productoprecio = $"{productos} , ${precio}";



                    Producto producto = new Producto();


                    producto.IdProducto = dataReader.GetInt32(0);

                    producto.NombreProducto = dataReader.GetString(1);

                    producto.MarcaProducto = dataReader.GetString(2);

                    producto.PrecioProducto = dataReader.GetInt32(3);

                    producto.CantidadProducto = dataReader.GetInt32(4);

                    producto.PrecioCompra = Convert.ToDecimal(dataReader.GetDouble(5));

                    producto.PrecioVenta = Convert.ToDecimal(dataReader.GetDouble(6));

                    producto.IdCategoria = dataReader.GetInt32(7);


                    lista.Add(producto);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al obtener la lista de productos", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }

       

        public DataSet listarProductoBuscar(string cual)
        {
            string orden = $" select p.IdProducto , p.NombreProducto, p.MarcaProducto, p.PrecioProducto, p.CantidadProducto, p.PrecioCompra, p.PrecioVenta, m.NombreCategoria" +
                $"from  Producto as p inner join Categoria as m on p.IdProducto=m.IdCategoria " +
                      $"where p.IdProducto like '%{cual}%' or p.NombreProducto like '%{cual}%' or  p.MarcaProducto like '%{cual}%' or  p.PrecioProducto like '%{cual}%' or  p.CantidadProducto like '%{cual}%' or  p.PrecioCompra like '%{cual}%' or  p.PrecioVenta like '%{cual}%' or  p.NombreCategoria like '%{cual}%' ; ";

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
                throw new Exception("Error al buscar el producto", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet ListarProductoEliminar(string id)
        {
            string orden = $"delete from Producto where IdProducto = {id};";

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


       

        public DataSet Union()
        {

            string orden = $" select p.IdProducto , p.NombreProducto, p.MarcaProducto, p.PrecioProducto, p.CantidadProducto, p.PrecioCompra, p.PrecioVenta, m.NombreCategoria from  Producto as p inner join Categoria as m on p.IdProducto=m.IdCategoria ";
        
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
