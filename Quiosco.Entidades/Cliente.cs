using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Entidades
{
    public class Cliente
    {

        private int idCliente;

        private string nombreCliente;

        private string telefonoCliente;

        private decimal adeudaCliente;

       



        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }

        }
        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }


        public string TelefonoCliente
        {
            get { return telefonoCliente; }
            set { telefonoCliente = value; }
        }


        public decimal AdeudaCliente
        {
            get { return adeudaCliente; }
            set { adeudaCliente = value; }
        }


      

        public Cliente() { }

        public Cliente ( string nombreClient, string telefonoClient,  decimal adeudaClient)

        {
            nombreCliente = nombreClient;
            telefonoCliente = telefonoClient;
            adeudaCliente = adeudaClient;
            

        }

    }
}
