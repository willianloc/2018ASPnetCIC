using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LojaPcs.Models;

namespace LojaPcs.Controllers
{
    public class GPUController : Controller
    {
        LojaPCsContext db = new LojaPCsContext();

        // GET: /GPU/
        public ActionResult Index()
        {
            return View(db.GPUs.ToList());
        }

        // GET: /GPU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gpu = db.GPUs.Find(id);
            if (gpu == null)
            {
                return HttpNotFound();
            }
            return View(gpu);
        }

        // GET: /GPU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GPU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GPUId,Nome,Preco")] GPU gpu)
        {
            if (ModelState.IsValid)
            {
                db.GPUs.Add(gpu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gpu);
        }

        // GET: /GPU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gpu = db.GPUs.Find(id);
            if (gpu == null)
            {
                return HttpNotFound();
            }
            return View(gpu);
        }

        // POST: /GPU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GPUId,Nome,Preco")] GPU gpu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gpu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gpu);
        }

        // GET: /GPU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gpu = db.GPUs.Find(id);
            if (gpu == null)
            {
                return HttpNotFound();
            }
            return View(gpu);
        }

        // POST: /GPU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPU gpu = db.GPUs.Find(id);
            db.GPUs.Remove(gpu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
