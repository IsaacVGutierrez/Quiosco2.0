using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Entidades
{
    public class DetalleCompra
    {


        private int idDetalleCompra;

        private int idCompraProducto;

        private int idProducto;

        private int cantidadProducto;




        public int IdDetalleCompra
        {
            get { return idDetalleCompra; }
            set { idDetalleCompra = value; }

        }
        public int IdCompraProducto
        {
            get { return idCompraProducto; }
            set { idCompraProducto = value; }
        }


        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }


        public int CantidadProducto
        {
            get { return cantidadProducto; }
            set { cantidadProducto = value; }
        }

              

        public DetalleCompra() { }

        public DetalleCompra(int cantidadProduct)
        {
            cantidadProducto = cantidadProduct;
           

        }

    }
}
