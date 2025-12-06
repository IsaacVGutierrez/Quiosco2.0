using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Entidades
{
    public class Venta
    {

        private int idVenta;

        private decimal subtotalVenta;

        private DateTime fechaVenta;

        private int idmetodoDePagoVenta;

        private int idCliente;

        private decimal saldoVenta;




        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }

        }
        public decimal SubtotalVenta
        {
            get { return subtotalVenta; }
            set { subtotalVenta = value; }
        }


        public DateTime FechaVenta
        {
            get { return fechaVenta; }
            set { fechaVenta = value; }
        }


        public int IdMetodoDePagoVenta
        {
            get { return idmetodoDePagoVenta; }
            set { idmetodoDePagoVenta = value; }
        }


        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public decimal SaldoVenta
        {
            get { return saldoVenta; }
            set { saldoVenta = value; }
        }

        public Venta() { }

        public Venta( decimal subtotalVent,  DateTime fechaVent, int idmetodoDePagoVent, decimal saldoVent)
        {
            subtotalVenta = subtotalVent;
            fechaVenta = fechaVent;
            idmetodoDePagoVenta = idmetodoDePagoVent;
            saldoVenta = saldoVent;
          

        }

    }
}
