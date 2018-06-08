using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LojaPcs.Models;

namespace LojaPcs.Controllers
{
    public class HDController : Controller
    {
        LojaPCsContext db = new LojaPCsContext();
        
        public ActionResult Index()
        {
            return View(db.HDs.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HD hd = db.HDs.Find(id);
            if (hd == null)
            {
                return HttpNotFound();
            }
            return View(hd);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="HDId,Nome,Preco")] HD hd)
        {
            if (ModelState.IsValid)
            {
                db.HDs.Add(hd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hd);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HD hd = db.HDs.Find(id);
            if (hd == null)
            {
                return HttpNotFound();
            }
            return View(hd);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="HDId,Nome,Preco")] HD hd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hd);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HD hd = db.HDs.Find(id);
            if (hd == null)
            {
                return HttpNotFound();
            }
            return View(hd);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HD hd = db.HDs.Find(id);
            db.HDs.Remove(hd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
