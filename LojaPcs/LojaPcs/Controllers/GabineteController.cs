using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LojaPcs.Models;

namespace LojaPcs.Controllers
{
    public class GabineteController : Controller
    {
        LojaPCsContext db = new LojaPCsContext();
        
        public ActionResult Index()
        {
            return View(db.Gabinetes.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinetes.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GabineteId,Nome,Preco")] Gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                db.Gabinetes.Add(gabinete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gabinete);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinetes.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GabineteId,Nome,Preco")] Gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gabinete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gabinete);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinetes.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gabinete gabinete = db.Gabinetes.Find(id);
            db.Gabinetes.Remove(gabinete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
