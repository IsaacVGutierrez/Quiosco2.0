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
    public class CategoriaNegocio
    {

        ListaCategoria objDatosCategoria = new ListaCategoria();



        public int abmCategoria(string accion, Categoria objCategoria)
        {
            return objDatosCategoria.abmCategoria(accion, objCategoria);
        }
        public DataSet listadoCategoria(string cual)
        {
            return objDatosCategoria.listadoCategoria(cual);
        }

        public List<Categoria> ObtenerCategoria()
        {
            return objDatosCategoria.ObtenerCategoria();
        }

        public DataSet listarCategoriaBuscar(string cual)
        {
            return objDatosCategoria.listarCategoriaBuscar(cual);
        }

        public DataSet ListarCategoriaEliminar(string id)
        {
            return objDatosCategoria.ListarCategoriaEliminar(id);
        }

      


    }
}
