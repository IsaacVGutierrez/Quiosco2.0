using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quiosco.Entidades
{
    public class Usuario
    {
        private int idUsuario;
        private string email;
        private string nombreUsuario;
        private string contrasenaHash;
        private string telefono;
        private string rol;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Email { get => email; set => email = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string ContrasenaHash { get => contrasenaHash; set => contrasenaHash = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Rol { get => rol; set => rol = value; }

        public Usuario() { }
    }
}
