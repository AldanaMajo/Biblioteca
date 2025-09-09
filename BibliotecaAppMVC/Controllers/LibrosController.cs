using Biblioteca.Bl;
using BibliotecaEN;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAppMVC.Controllers
{
    public class LibrosController : Controller
    {
            LibrosEN LibrosEN = new LibrosEN();
            LibrosBL LibrosBL = new LibrosBL();

            //Metodo que devuelve la vista Index
            public IActionResult Index()
            {
                return View();
            }
            [HttpPost]
            //Metodo que devuelve un JsonResult con la lista de libros
            public JsonResult MostrarLibros()
            {
                return Json(LibrosBL.MostrarLibro());
            }
            //Metodo que devuelve la vista AgregarLibro
            [HttpGet]
            public IActionResult AgregarLibro()
            {
                return View();
            }
            //metodo que realiza la accion de agregar un libro a las N-Capas 
            [HttpPost]
            public IActionResult AgregarLibro(LibrosEN pLibrosEN)
            {
                string mensaje = "";
                if (pLibrosEN != null && pLibrosEN.Titulo != "" && pLibrosEN.Autor != "" && pLibrosEN.AnioPublicacion != 0)
                {
                    if (LibrosBL.AgregarLibro(pLibrosEN) > 0)
                    {
                        mensaje = "Libro agregado correctamente";
                    }
                    else
                    {
                        mensaje = "Error al agregar el libro";
                    }
                }
                else
                {
                    mensaje = "Debe completar todos los campos";
                }
                return Json(new { Mensaje = mensaje });

            }
            //Metodo que devuelve la vista de ModificarLibro
            [HttpGet]
            public IActionResult ModificarLibro(int Id)
            {
                return View();
            }
            //Metodo que realixa la peticion de modificar un libro
            [HttpPost]
            public JsonResult ModificarLibro(LibrosEN pLibrosEN)
            {
                string mensaje = "";
                if (pLibrosEN != null && pLibrosEN.Titulo != "" && pLibrosEN.Autor != "" && pLibrosEN.AnioPublicacion != 0)
                {
                    if (LibrosBL.ModificarLibro(pLibrosEN) > 0)
                    {
                        mensaje = "Libro modificado correctamente";
                    }
                    else
                    {
                        mensaje = "Error al modificar el libro";
                    }
                }
                else
                {
                    mensaje = "Debe completar todos los campos";
                }
                return Json(new { Mensaje = mensaje });
            }
            //Metodo que devuelve la vista EliminarLibro
            [HttpGet]
            public IActionResult EliminarLibro()
            {
                return View();
            }
            //Metodo que realiza la peticion de eliminar un libro
            [HttpPost]
            public JsonResult EliminarLibro(LibrosEN pLibrosEN)
            {
                string mensaje = "";
                if (pLibrosEN.Id != 0)
                {
                    if (LibrosBL.EliminarLibro(pLibrosEN) > 0)
                    {
                        mensaje = "Libro eliminado correctamente";
                    }
                    else
                    {
                        mensaje = "Error al eliminar el libro";
                    }
                }
                else
                {
                    mensaje = "Debe seleccionar un Libro";
                }
                return Json(new { Mensaje = mensaje });
            }
    }
}