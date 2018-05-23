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
        public ActionResult Index2()
        {
            List<Categoria> categorias = new List<Categoria>();

            categorias.Add(
                new Categoria
                {
                    Nome = "Casa"
                }
                );

            categorias.Add(new Categoria() { Nome = "Trabalho" });
            categorias.Add(new Categoria() { Nome = "Família" });
            categorias.Add(new Categoria() { Nome = "Carro" });


            return View();
        }

        public ActionResult Formulario()   //GET - ao chamar página
        {
            return View();
        }

        [HttpPost]
        public ActionResult Formulario(string nome, string descricao, bool ativo)  //POST ao clicar em algum botão
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            if(ModelState.IsValid)
            {

            }
            return View(categoria);
        }
    }
}