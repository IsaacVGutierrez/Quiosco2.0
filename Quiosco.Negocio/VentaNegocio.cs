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
    public class VentaNegocio
    {
        ListaVenta objDatosVenta = new ListaVenta();



        public int abmVenta(string accion, Venta objVenta)
        {
            return objDatosVenta.abmVenta(accion, objVenta);
        }
        public DataSet listadoVenta(string cual)
        {
            return objDatosVenta.listadoVenta(cual);
        }

        public List<Venta> ObtenerVenta()
        {
            return objDatosVenta.ObtenerVenta();
        }

        public DataSet listarVentaBuscar(string cual)
        {
            return objDatosVenta.listarVentaBuscar(cual);
        }

        public DataSet ListarVentaEliminar(string id)
        {
            return objDatosVenta.ListarVentaEliminar(id);
        }

        public DataSet Union()
        {
            return objDatosVenta.Union();
        }


    }
}
