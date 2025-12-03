using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Entidades
{
    public class DetalleVenta
    {

        private int idDetalleVenta;

        private int idVenta;

        private int idProducto;

        private int cantidadProducto;

        

        public int IdDetalleVenta
        {
            get { return idDetalleVenta; }
            set { idDetalleVenta = value; }

        }
        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
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




        public DetalleVenta() { }

        public DetalleVenta(int cantidadProduct)
        {
            cantidadProducto = cantidadProduct;
           
        

        }


    }
}
