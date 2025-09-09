using BibliotecaEN;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibiotecaaDAL
{
    public class PrestamosDAL
    {
        //REGISTRAR PRESTAMOS
        public static int RegistrarPrestamo(PrestamosEN pPrestamosEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("RegistrarPrestamo", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;

                _comando.Parameters.Add(new SqlParameter("@IdLibro", pPrestamosEN.IdLibro));
                _comando.Parameters.Add(new SqlParameter("@IdUsuario", pPrestamosEN.IdUsuario));
                _comando.Parameters.Add(new SqlParameter("@FechaPrestamo", pPrestamosEN.FechaPrestamo));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        //REGISTRAR DEVOLUCION 
        public static int RegistrarDevolucion(PrestamosEN pPrestamosEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("RegistrarDevolucion", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pPrestamosEN.Id));
                _comando.Parameters.Add(new SqlParameter("@FechaDevolucion", pPrestamosEN.FechaDevolucion));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        //Mostrar Prestamos
        public static List<PrestamosEN> MostrarPrestamos()
        {
            List<PrestamosEN> _Lista = new List<PrestamosEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarPrestamos", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new PrestamosEN
                    {
                        Id = _reader.GetInt32(0),
                        IdLibro = _reader.GetInt32(1),
                        Titulo = _reader.GetString(2),
                        IdUsuario = _reader.GetInt32(3),
                        Nombre = _reader.GetString(4),
                        Email = _reader.GetString(5),
                        FechaPrestamo = _reader.GetDateTime(6),
                        FechaDevolucion = _reader.GetDateTime(7),
                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
    }
}
