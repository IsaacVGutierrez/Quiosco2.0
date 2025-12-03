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
    public class DetalleCompraNegocio
    {

        ListaDetalleCompra objDatosDetalleCompra = new ListaDetalleCompra();



        public int abmDetalleCompra(string accion, DetalleCompra objDetalleCompra)
        {
            return objDatosDetalleCompra.abmDetalleCompra(accion, objDetalleCompra);
        }
        public DataSet listadoDetalleCompra(string cual)
        {
            return objDatosDetalleCompra.listadoDetalleCompra(cual);
        }

        public List<DetalleCompra> ObtenerDetalleCompra()
        {
            return objDatosDetalleCompra.ObtenerDetalleCompra();
        }

        public DataSet listarDetalleCompraBuscar(string cual)
        {
            return objDatosDetalleCompra.listarDetalleCompraBuscar(cual);
        }

        public DataSet ListarDetalleCompraEliminar(string id)
        {
            return objDatosDetalleCompra.ListarDetalleCompraEliminar(id);
        }

        public DataSet Union()
        {
            return objDatosDetalleCompra.Union();
        }




    }
}
