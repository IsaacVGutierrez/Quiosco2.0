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

        private string metodoDePago;

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


        public string MetodoDePago
        {
            get { return metodoDePago; }
            set { metodoDePago = value; }
        }


        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }



        public CompraProducto() { }

        public CompraProducto( decimal subtotalCompraProduct, DateTime fechaCompraProduct,  string metodoDePag )
        {
            subtotalCompraProducto = subtotalCompraProduct;
            fechaCompraProductos = fechaCompraProduct;
            metodoDePago = metodoDePag;
          
        }





    }
}
