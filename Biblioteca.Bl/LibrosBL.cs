using BibiotecaaDAL;
using BibliotecaEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Bl
{
    public class LibrosBL
    {
        public List<LibrosEN> MostrarLibro()
        {
            return LibrosDAL.MostrarLibro();
        }
        public int AgregarLibro(LibrosEN pLibrosEN)
        {
            return LibrosDAL.AgregarLibro(pLibrosEN);
        }
        public int EliminarLibro(LibrosEN pLibrosEN)
        {
            return LibrosDAL.EliminarLibro(pLibrosEN);
        }
        public int ModificarLibro(LibrosEN pLibrosEN)
        {
            return LibrosDAL.ModificarLibro(pLibrosEN);
        }
    }
}
