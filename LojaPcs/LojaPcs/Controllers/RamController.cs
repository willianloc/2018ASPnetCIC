using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaPcs.Models;

namespace LojaPCs.Controllers
{
    public class RamController : Controller
    {
        LojaPCsContext db = new LojaPCsContext();

        public ActionResult RamList()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            return View(db.Rams.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ram ram = db.Rams.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RamId,Nome,Preco")] Ram ram)
        {
            if (ModelState.IsValid)
            {
                db.Rams.Add(ram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ram);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ram ram = db.Rams.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RamId,Nome,Preco")] Ram ram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ram);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ram ram = db.Rams.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ram ram = db.Rams.Find(id);
            db.Rams.Remove(ram);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
