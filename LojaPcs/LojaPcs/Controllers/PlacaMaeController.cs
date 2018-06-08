using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LojaPcs.Models;

namespace LojaPCs.Controllers
{
    public class PlacaMaeController : Controller
    {
        LojaPCsContext db = new LojaPCsContext();
        
        public ActionResult Index()
        {
            return View(db.PlacaMaes.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMae placamae = db.PlacaMaes.Find(id);
            if (placamae == null)
            {
                return HttpNotFound();
            }
            return View(placamae);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlacaMaeId,Nome,Preco")] PlacaMae placamae)
        {
            if (ModelState.IsValid)
            {
                db.PlacaMaes.Add(placamae);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placamae);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMae placamae = db.PlacaMaes.Find(id);
            if (placamae == null)
            {
                return HttpNotFound();
            }
            return View(placamae);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlacaMaeId,Nome,Preco")] PlacaMae placamae)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placamae).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placamae);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMae placamae = db.PlacaMaes.Find(id);
            if (placamae == null)
            {
                return HttpNotFound();
            }
            return View(placamae);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlacaMae placamae = db.PlacaMaes.Find(id);
            db.PlacaMaes.Remove(placamae);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
