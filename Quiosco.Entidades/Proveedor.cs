using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Entidades
{
    public class Proveedor
    {
        private int idProveedor;

        private string nombreProveedor;

        private string telefonoProveedor;

        private string direccionProveedor;

        private string horarioProveedor;

        private string diasProveedor;
      
        


        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }

        }
        public string NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }


        public string TelefonoProveedor
        {
            get { return telefonoProveedor; }
            set { telefonoProveedor = value; }
        }


        public string DireccionProveedor
        {
            get { return direccionProveedor; }
            set { direccionProveedor = value; }
        }


        public string HorarioProveedor
        {
            get { return horarioProveedor; }
            set { horarioProveedor = value; }
        }

        public string DiasProveedor
         {
            get { return diasProveedor; }
            set { diasProveedor = value; }
        }


        public Proveedor() { }

        public Proveedor( string nombreProv, string telefonoProv,string direccionProv, string horarioProv, string diasProv)
        {
            nombreProveedor = nombreProv;
            telefonoProveedor = telefonoProv;
            direccionProveedor = direccionProv;
            horarioProveedor = horarioProv;
            diasProveedor = diasProv;

        }




    }
}
