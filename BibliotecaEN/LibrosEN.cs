using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEN
{
    public class LibrosEN
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public int? AnioPublicacion { get; set; }
        public bool Disponible { get; set; } = true;
    }
}
