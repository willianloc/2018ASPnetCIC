using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LojaPcs.Models;

namespace LojaPcs.Controllers
{
    public class FonteController : Controller
    {
        LojaPCsContext db = new LojaPCsContext();

        // GET: /Fonte/
        public ActionResult Index()
        {
            return View(db.Fontes.ToList());
        }

        // GET: /Fonte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonte fonte = db.Fontes.Find(id);
            if (fonte == null)
            {
                return HttpNotFound();
            }
            return View(fonte);
        }

        // GET: /Fonte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Fonte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FonteId,Nome,Preco")] Fonte fonte)
        {
            if (ModelState.IsValid)
            {
                db.Fontes.Add(fonte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fonte);
        }

        // GET: /Fonte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonte fonte = db.Fontes.Find(id);
            if (fonte == null)
            {
                return HttpNotFound();
            }
            return View(fonte);
        }

        // POST: /Fonte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FonteId,Nome,Preco")] Fonte fonte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fonte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fonte);
        }

        // GET: /Fonte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonte fonte = db.Fontes.Find(id);
            if (fonte == null)
            {
                return HttpNotFound();
            }
            return View(fonte);
        }

        // POST: /Fonte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fonte fonte = db.Fontes.Find(id);
            db.Fontes.Remove(fonte);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
