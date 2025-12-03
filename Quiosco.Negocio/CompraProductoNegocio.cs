using Quiosco.BD;
using Quiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Negocio
{
    public class CompraProductoNegocio
    {

        ListaCompraProducto objDatosCompraProducto = new ListaCompraProducto();



        public int abmCompraProducto(string accion, CompraProducto objCompraProducto)
        {
            return objDatosCompraProducto.abmCompraProducto(accion, objCompraProducto);
        }
        public DataSet listadoCompraProducto(string cual)
        {
            return objDatosCompraProducto.listadoCompraProducto(cual);
        }

        public List<CompraProducto> ObtenerCompraProducto()
        {
            return objDatosCompraProducto.ObtenerCompraProducto();
        }

        public DataSet listarCompraProductoBuscar(string cual)
        {
            return objDatosCompraProducto.listarCompraProductoBuscar(cual);
        }

        public DataSet ListarCompraProductoEliminar(string id)
        {
            return objDatosCompraProducto.ListarCompraProductoEliminar(id);
        }

        public DataSet Union()
        {
            return objDatosCompraProducto.Union();
        }




    }
}
