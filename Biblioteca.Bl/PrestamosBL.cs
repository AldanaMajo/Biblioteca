using BibiotecaaDAL;
using BibliotecaEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Bl
{
 
    public class PrestamosBL
    {
        public int RegistrarPrestamo(PrestamosEN pPrestamosEN)
        {
            return PrestamosDAL.RegistrarPrestamo(pPrestamosEN);
        }

        public int RegistrarDevolucion(PrestamosEN pPrestamosEN)
        {
            return PrestamosDAL.RegistrarDevolucion(pPrestamosEN);
        }
    }
}
