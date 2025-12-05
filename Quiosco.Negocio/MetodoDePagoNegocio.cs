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
    public class MetodoDePagoNegocio
    {

        ListaMetodoDePago objDatosMetodoDePago = new ListaMetodoDePago();



        public int abmMetodoDePago(string accion, MetodoDePago objMetodoDePago)
        {
            return objDatosMetodoDePago.abmMetodoDePago(accion, objMetodoDePago);
        }
        public DataSet listadoMetodoDePago(string cual)
        {
            return objDatosMetodoDePago.listadoMetodoDePago(cual);
        }

        public List<MetodoDePago> ObtenerMetodoDePago()
        {
            return objDatosMetodoDePago.ObtenerMetodoDePago();
        }

        public DataSet listarMetodoDePagoBuscar(string cual)
        {
            return objDatosMetodoDePago.listarMetodoDePagoBuscar(cual);
        }

        public DataSet ListarMetodoDePagoEliminar(string id)
        {
            return objDatosMetodoDePago.ListarMetodoDePagoEliminar(id);
        }




    }
}
