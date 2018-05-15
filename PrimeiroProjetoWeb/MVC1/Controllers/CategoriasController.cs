using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            List<string> categorias = new List<string>();

            categorias.Add("Estudo");
            categorias.Add("Lesma");
            categorias.Add("Jão");
            categorias.Add("Trabalho");

            ViewBag.MinhasCategorias = categorias;

            return View();
        }
    }
}