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
    public class DetalleVentaNegocio
    {

        ListaDetalleVenta objDatosDetalleVenta = new ListaDetalleVenta();



        public int abmDetalleVenta(string accion, DetalleVenta objDetalleVenta)
        {
            return objDatosDetalleVenta.abmDetalleVenta(accion, objDetalleVenta);
        }
        public DataSet listadoDetalleVenta(string cual)
        {
            return objDatosDetalleVenta.listadoDetalleVenta(cual);
        }

        public List<DetalleVenta> ObtenerDetalleVenta()
        {
            return objDatosDetalleVenta.ObtenerDetalleVenta();
        }

        public DataSet listarDetalleVentaBuscar(string cual)
        {
            return objDatosDetalleVenta.listarDetalleVentaBuscar(cual);
        }

        public DataSet ListarDetalleVentaEliminar(string id)
        {
            return objDatosDetalleVenta.ListarDetalleVentaEliminar(id);
        }

        public DataSet Union()
        {
            return objDatosDetalleVenta.Union();
        }



    }
}
