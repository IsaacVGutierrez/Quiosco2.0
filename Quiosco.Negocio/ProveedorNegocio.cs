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
    public class ProveedorNegocio
    {

        ListaProveedor objDatosProveedor = new ListaProveedor();



        public int abmProveedor(string accion, Proveedor objProveedor)
        {
            return objDatosProveedor.abmProveedor(accion, objProveedor);
        }
        public DataSet listadoProveedor(string cual)
        {
            return objDatosProveedor.listadoProveedor(cual);
        }

        public List<Proveedor> ObtenerProveedor()
        {
            return objDatosProveedor.ObtenerProveedor();
        }

        public DataSet listarProveedorBuscar(string cual)
        {
            return objDatosProveedor.listarProveedorBuscar(cual);
        }

        public DataSet ListarProveedorEliminar(string id)
        {
            return objDatosProveedor.ListarProveedorEliminar(id);
        }

      


    }
}
