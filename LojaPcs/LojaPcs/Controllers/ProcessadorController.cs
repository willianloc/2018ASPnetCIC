using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LojaPcs.Models;

namespace LojaPCs.Controllers
{
    public class ProcessadorController : Controller
    {
        LojaPCsContext db = new LojaPCsContext();
        
        public ActionResult Index()
        {
            return View(db.Processadors.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processador processador = db.Processadors.Find(id);
            if (processador == null)
            {
                return HttpNotFound();
            }
            return View(processador);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProcessadorId,Nome,Preco")] Processador processador)
        {
            if (ModelState.IsValid)
            {
                db.Processadors.Add(processador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(processador);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processador processador = db.Processadors.Find(id);
            if (processador == null)
            {
                return HttpNotFound();
            }
            return View(processador);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProcessadorId,Nome,Preco")] Processador processador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processador);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processador processador = db.Processadors.Find(id);
            if (processador == null)
            {
                return HttpNotFound();
            }
            return View(processador);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Processador processador = db.Processadors.Find(id);
            db.Processadors.Remove(processador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
