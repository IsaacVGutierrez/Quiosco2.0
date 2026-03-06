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
    public class VentaMetodoPagoNegocio
    {
        Quiosco.BD.ListaVentaMetodoPago objDatosPago = new Quiosco.BD.ListaVentaMetodoPago();


        public int abmVentaMetodoPago(string accion, VentaMetodoPago objPago)
        {
            return objDatosPago.abmVentaMetodoPago(accion, objPago);
        }

        public List<VentaMetodoPago> ObtenerPagosPorVenta(int idVenta)
        {
            return objDatosPago.ObtenerPagosPorVenta(idVenta);
        }
        public int AgregarPago(VentaMetodoPago pago)
        {
            return abmVentaMetodoPago("Alta", pago);
        }


    }


}
