using Quiosco.BD;
using Quiosco.Entidades;
using System.Data;

namespace Quiosco.Negocio
{
    public class ProductoNegocio
    {
        ListaProductos objDatosProducto = new ListaProductos();


        public int abmProducto(string accion, Producto objProducto)
        {
            return objDatosProducto.abmProducto(accion, objProducto);
        }
        public DataSet listadoProducto(string categoria)
        {
            return objDatosProducto.listadoProducto(categoria);
        }

        public List<Producto> ObtenerProducto()
        {
            return objDatosProducto.ObtenerProducto();
        }

        public DataSet listarProductoBuscar(string cual)
        {
            return objDatosProducto.listarProductoBuscar(cual);
        }

        public bool ListarProductoEliminar(int id)
        {
            return objDatosProducto.ListarProductoEliminar(id);
        }


        public int ReducirStock(int id, int cantidad)
        {
            return objDatosProducto.ReducirStock( id , cantidad);
        }

        public DataSet Union()
        {
            return objDatosProducto.Union();
        }
    }
}
