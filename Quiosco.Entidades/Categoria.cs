using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco.Entidades
{
    public class Categoria
    {

        private int idCategoria;

        private string nombreCategoria;


        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }

        }
        public string NombreCategoria
        {
            get { return nombreCategoria; }
            set { nombreCategoria = value; }
        }


        public Categoria() { }

        public Categoria(string nombreCategori)
        {
            nombreCategoria = nombreCategori;


        }



    }
}
