using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Entidades
{
    public class CompraProducto
    {

        private int idCompraProducto;

        private decimal subtotalCompraProducto;

        private DateTime fechaCompraProductos;

        private int idmetodoDePago;

        private int idProveedor;

      



        public int IdCompraProducto
        {
            get { return idCompraProducto; }
            set { idCompraProducto = value; }

        }
        public decimal SubtotalCompraProducto
        {
            get { return subtotalCompraProducto; }
            set { subtotalCompraProducto = value; }
        }


        public DateTime FechaCompraProductos
        {
            get { return fechaCompraProductos; }
            set { fechaCompraProductos = value; }
        }


        public int IdMetodoDePago
        {
            get { return idmetodoDePago; }
            set { idmetodoDePago = value; }
        }


        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }



        public CompraProducto() { }

        public CompraProducto( decimal subtotalCompraProduct, DateTime fechaCompraProduct, int idmetodoDePag )
        {
            subtotalCompraProducto = subtotalCompraProduct;
            fechaCompraProductos = fechaCompraProduct;
            idmetodoDePago = idmetodoDePag;
          
        }





    }
}
