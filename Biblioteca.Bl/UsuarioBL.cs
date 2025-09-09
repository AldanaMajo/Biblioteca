using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEN;
using BibiotecaaDAL;

namespace Biblioteca.Bl
{
    public class UsuarioBL
    {
        public List<UsuarioEN> MostrarUsuario()
        {
            return UsuariosDAL.MostrarUsuario();
        }
        public int AgregarUsuario(UsuarioEN pUsuarioEN)
        {
            return UsuariosDAL.AgregarUsuario(pUsuarioEN);
        }
        public int EliminarUsuario(UsuarioEN pUsuarioEN)
        {
            return UsuariosDAL.EliminarUsuario(pUsuarioEN);
        }
        public int ModificarUsuario(UsuarioEN pUsuarioEN)
        {
            return UsuariosDAL.ModificarUsuario(pUsuarioEN);
        }
    }
}
