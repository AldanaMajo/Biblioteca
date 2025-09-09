using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace BibiotecaaDAL
{
    public class ComunBD
    {
        public enum TipoBD
        {
            SqlServer, Oracle, DB2
        }
        public const string Sqlconn = @"Data Source=.;Initial Catalog=Biblioteca;Integrated Security=True;TrustServerCertificate=True";
        public static IDbConnection ObtenerConexion(TipoBD pTipoBD)
        {
            IDbConnection _conn;
            if (pTipoBD == TipoBD.SqlServer)
            {
                _conn = new SqlConnection(Sqlconn);
                return _conn;
            }
            return null;
        }
    }
}
