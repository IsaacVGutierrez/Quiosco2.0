using Quiosco.BD;
using Quiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Negocio
{
    public class ClienteNegocio
    {

        ListaCliente objDatosCliente = new ListaCliente();



        public int abmCliente(string accion, Cliente objCliente)
        {
            return objDatosCliente.abmCliente(accion, objCliente);
        }
        public DataSet listadoCliente(string cual)
        {
            return objDatosCliente.listadoCliente(cual);
        }

        public List<Cliente> ObtenerCliente()
        {
            return objDatosCliente.ObtenerCliente();
        }

        public DataSet listarClienteBuscar(string cual)
        {
            return objDatosCliente.listarClienteBuscar(cual);
        }

        public DataSet ListarClienteEliminar(string id)
        {
            return objDatosCliente.ListarClienteEliminar(id);
        }

      
    }
}
