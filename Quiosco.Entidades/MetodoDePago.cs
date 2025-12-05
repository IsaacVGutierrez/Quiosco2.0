using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Entidades
{
    public class MetodoDePago
    {

        private int idMetodoDePago;

        private string nombreMetodoDePago;


        public int IdMetodoDePago
        {
            get { return idMetodoDePago; }
            set { idMetodoDePago = value; }

        }
        public string NombreMetodoDePago
        {
            get { return nombreMetodoDePago; }
            set { nombreMetodoDePago = value; }
        }


        public MetodoDePago() { }

        public MetodoDePago(string nombreMetodoDePag)
        {
            nombreMetodoDePago = nombreMetodoDePag;


        }



    }
}
