using MVC1.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            List<Categoria> categorias = new List<Categoria>();

            categorias.Add(new Categoria() { id = 1, Nome = "casa", Ativo = true });
            categorias.Add(new Categoria() { id = 2, Nome = "carro", Ativo = true });
            categorias.Add(new Categoria() { id = 3, Nome = "cabeça", Ativo = true });
            categorias.Add(new Categoria() { id = 4, Nome = "casco", Ativo = true });

            ViewBag.MinhasCategorias = categorias;
            return View();
        }
    }
}