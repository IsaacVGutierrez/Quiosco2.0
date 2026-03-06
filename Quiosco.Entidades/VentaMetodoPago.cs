using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Quiosco.Entidades
{
    public class VentaMetodoPago
    {
        public int IdVentaMetodoPago { get; set; } // PK
        public int IdVenta { get; set; }
        public int IdMetodoDePago { get; set; }
        public decimal Monto { get; set; }
    }

    // Lista para manejar pagos en memoria
    public class ListaVentaMetodoPago : List<VentaMetodoPago>
    {
        // Se pueden agregar métodos útiles si se desea, ejemplo totales
        public decimal Total()
        {
            decimal total = 0;
            foreach (var pago in this)
                total += pago.Monto;
            return total;
        }
    }
}
