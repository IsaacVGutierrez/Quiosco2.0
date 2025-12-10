using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quiosco.Entidades
{
    public class RecuperacionPassword
    {
        public int IdRecuperacion { get; set; }
        public int IdUsuario { get; set; }
        public string Codigo { get; set; }
        public DateTime Expira { get; set; }
        public bool Usado { get; set; }
    }
}
