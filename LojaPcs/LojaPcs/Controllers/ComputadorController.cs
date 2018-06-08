using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LojaPcs.Models;

namespace LojaPcs.Controllers
{
    public class ComputadorController : Controller
    {
        LojaPCsContext db = new LojaPCsContext();
        public ActionResult Index()
        {
            return View(db.Computadors.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computador computador = db.Computadors.Find(id);
            if (computador == null)
            {
                return HttpNotFound();
            }
            return View(computador);
        }

        public ActionResult Create()
        {
            ViewBag.RamId = new SelectList(db.Rams, "RamId", "Nome");
            ViewBag.GabineteId = new SelectList(db.Gabinetes, "GabineteId", "Nome");
            ViewBag.FonteId = new SelectList(db.Fontes, "FonteId", "Nome");
            ViewBag.GPUId = new SelectList(db.GPUs, "GPUId", "Nome");
            ViewBag.HDId = new SelectList(db.HDs, "HDId", "Nome");
            ViewBag.PlacaMaeId = new SelectList(db.PlacaMaes, "PlacaMaeId", "Nome");
            ViewBag.ProcessadorId = new SelectList(db.Processadors, "ProcessadorId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Computador computador, int GabineteId, int ProcessadorId, int PlacaMaeId, int RamId, int qtdram, int GPUId, int qtdgpu, int FonteId, int HDId, int qtdhd)
        {
            computador.Gabinete = db.Gabinetes.Find(GabineteId);
            computador.Processador = db.Processadors.Find(ProcessadorId);
            computador.Placamae = db.PlacaMaes.Find(PlacaMaeId);
            computador.Ram = db.Rams.Find(RamId);
            computador.QtdRam = qtdram;
            computador.Gpu = db.GPUs.Find(GPUId);
            computador.QtdGpu = qtdgpu;
            computador.Fonte = db.Fontes.Find(FonteId);
            computador.Hd = db.HDs.Find(HDId);
            computador.QtdHd = qtdhd;
            computador.Preço = computador.Gabinete.Preco + computador.Processador.Preco + computador.Placamae.Preco + (computador.Ram.Preco * computador.QtdRam) + (computador.Gpu.Preco * computador.QtdGpu) + computador.Fonte.Preco + (computador.Hd.Preco * computador.QtdHd);

            if (ModelState.IsValid)
            {
                db.Computadors.Add(computador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(computador);
        }
               
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computador computador = db.Computadors.Find(id);
            if (computador == null)
            {
                return HttpNotFound();
            }
            return View(computador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComputadorId,QtdRam,QtdGpu,QtdHd,Preço")] Computador computador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computador);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computador computador = db.Computadors.Find(id);
            if (computador == null)
            {
                return HttpNotFound();
            }
            return View(computador);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Computador computador = db.Computadors.Find(id);
            db.Computadors.Remove(computador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
