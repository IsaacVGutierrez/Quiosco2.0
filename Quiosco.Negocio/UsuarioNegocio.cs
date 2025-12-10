using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiosco.BD;
using Quiosco.Entidades;
using System.Data;
using System;
using System.Collections.Generic;

namespace Quiosco.Negocio
{
    public class UsuarioNegocio
    {
        ListaUsuario objDatosUsuario = new ListaUsuario();

        public List<Usuario> ListaUsuarios()
        {
            return objDatosUsuario.ObtenerUsuarios();
        }

        public int RegistrarUsuario(Usuario u)
        {
            return objDatosUsuario.abmUsuario("Alta", u);
        }

       
        public int ActualizarUsuario(Usuario u)
        {
            return objDatosUsuario.abmUsuario("Modificar", u);
        }

        public int EliminarUsuario(int id)
        {
            Usuario u = new Usuario();
            u.IdUsuario = id;
            return objDatosUsuario.abmUsuario("Baja", u);
        }

        public Usuario Login(string email, string passHash)
        {
            return objDatosUsuario.Login(email, passHash);
        }

     
        public Usuario BuscarPorEmail(string email)
        {
            return objDatosUsuario.BuscarPorEmail(email);
        }

        public void CrearCodigoRecuperacion(int idUsuario, string codigo)
        {
            RecuperacionPassword r = new RecuperacionPassword();
            r.IdUsuario = idUsuario;
            r.Codigo = codigo;
            r.Expira = DateTime.Now.AddMinutes(10); // expira en 10 minutos

            // Llamamos al método de ListaUsuario (o DatosUsuario) que guarda el registro en DB
            objDatosUsuario.CrearCodigoRecuperacion(r);
        }



        public bool ValidarCodigo(int idUsuario, string codigo)
        {
            return objDatosUsuario.ValidarCodigo(idUsuario, codigo);
        }

       
        public void MarcarCodigoUsado(int idUsuario, string codigo)
        {
            objDatosUsuario.MarcarCodigoUsado(idUsuario, codigo);
        }

        public void CambiarPassword(int idUsuario, string nuevoHash)
        {
            objDatosUsuario.CambiarPassword(idUsuario, nuevoHash);
        }
    }
}
