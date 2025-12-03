using System.Data.SqlTypes;

namespace Quiosco.Entidades
{
    public class Producto
    {

        private int idProducto;

        private string nombreProducto;

        private string marcaProducto;

        private decimal precioProducto;

        private int cantidadProducto;

        private decimal precioCompra;

        private decimal precioVenta;
               
        private int idCategoria;


        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }


        public string NombreProducto
        {
            get { return nombreProducto;
        }
            set { nombreProducto = value; }
        
        
        }


        public string MarcaProducto
        {
            get
            {
                return marcaProducto;
            }
            set { marcaProducto = value; }


        }
        public decimal PrecioProducto

        {
            get { return precioProducto; }
            set { precioProducto = (int)value; }

        }

        public int CantidadProducto
        {
            get { return cantidadProducto; }
            set { cantidadProducto = value; }
        }




        public decimal PrecioCompra

        {
            get { return precioCompra; }
            set { precioCompra = value; } 
        
        }

        public decimal PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }



        public Producto() { }

        public Producto(string nombreProduct,  string marcaProduct, decimal precioProduct, int cantidadProduct, decimal precioCompr, decimal precioVent)
        {
            nombreProducto = nombreProduct;
            marcaProducto = marcaProduct;
            precioProducto = precioProduct;
            cantidadProducto = cantidadProduct;
            precioCompra = precioCompr;
            precioVenta = precioVent;
            
        }
    }
}