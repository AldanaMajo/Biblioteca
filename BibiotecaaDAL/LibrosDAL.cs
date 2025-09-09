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
    public class LibrosDAL
    {
        //procedimiento almacenado de MostrarLibros
        public static List<LibrosEN> MostrarLibro()
        {
            List<LibrosEN> _Lista = new List<LibrosEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarLibro", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new LibrosEN
                    {
                        Id = _reader.GetInt32(0),
                        Titulo = _reader.GetString(1),
                        Autor = _reader.GetString(2),
                        AnioPublicacion = _reader.GetInt32(3),
                        Disponible = _reader.GetBoolean(4),
                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
        //Procedimiento Almacenado de Agregar Libro
        public static int AgregarLibro(LibrosEN pLibrosEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("AgregarLibro", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;

                _comando.Parameters.Add(new SqlParameter("@Titulo", pLibrosEN.Titulo));
                _comando.Parameters.Add(new SqlParameter("@Autor", pLibrosEN.Autor));
                _comando.Parameters.Add(new SqlParameter("@AnioPublicacion", pLibrosEN.AnioPublicacion));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        //Eliminar Libro
        public static int EliminarLibro(LibrosEN pLibrosEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("EliminarLibro", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pLibrosEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
           
        }
        //Modificar libro
        public static int ModificarLibro(LibrosEN pLibrosEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarLibro", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pLibrosEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Titulo", pLibrosEN.Titulo));
                _comando.Parameters.Add(new SqlParameter("@Autor", pLibrosEN.Autor));
                _comando.Parameters.Add(new SqlParameter("@AnioPublicacion", pLibrosEN.AnioPublicacion));
                _comando.Parameters.Add(new SqlParameter("@Disponible", pLibrosEN.Disponible));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
    }
}
