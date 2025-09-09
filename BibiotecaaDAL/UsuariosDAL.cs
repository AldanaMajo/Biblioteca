using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEN;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BibiotecaaDAL
{
    public class UsuariosDAL
    {
        //procedimiento almacenado de Mostrar Usuarios
        public static List<UsuarioEN> MostrarUsuario()
        {
            List<UsuarioEN> _Lista = new List<UsuarioEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarUsuario", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new UsuarioEN
                    {
                        Id = _reader.GetInt32(0),
                        Nombre = _reader.GetString(1),
                        Email = _reader.GetString(2),
                        Telefono = _reader.GetString(3),
                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
        //Procedimiento Almacenado de Agregar Usuario
        public static int AgregarUsuario(UsuarioEN pUsuarioEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("AgregarUsuario", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;

                _comando.Parameters.Add(new SqlParameter("@Nombre", pUsuarioEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Email", pUsuarioEN.Email));
                _comando.Parameters.Add(new SqlParameter("@Telefono", pUsuarioEN.Telefono));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        //Eliminar Usuario
        public static int EliminarUsuario(UsuarioEN pUsuarioEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("EliminarUsuario", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pUsuarioEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }

        }
        //Modificar Usuario
        public static int ModificarUsuario( UsuarioEN pUsuarioEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarUsuario", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pUsuarioEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", pUsuarioEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Email", pUsuarioEN.Email));
                _comando.Parameters.Add(new SqlParameter("@Telefono", pUsuarioEN.Telefono));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
    }
}

