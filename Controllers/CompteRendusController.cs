using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetGo;

namespace ProjetGo.Controllers
{
    public class CompteRendusController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: CompteRendus
        public ActionResult Index()
        {
            var compteRendus = db.CompteRendus.Include(c => c.ProjetCompteRendu);
            return View(compteRendus.ToList());
        }

        // GET: CompteRendus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompteRendu compteRendu = db.CompteRendus.Find(id);
            if (compteRendu == null)
            {
                return HttpNotFound();
            }
            return View(compteRendu);
        }

        // GET: CompteRendus/Create
        public ActionResult Create()
        {
            ViewBag.codeProjetCompteRendu = new SelectList(db.ProjetCompteRendus, "codeProjetCompteRendu", "realisationsCompletees");
            return View();
        }

        // POST: CompteRendus/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeCompteRendu,frequenceCompteRendu,dateCompteRendu,codeProjetCompteRendu")] CompteRendu compteRendu)
        {
            if (ModelState.IsValid)
            {
                db.CompteRendus.Add(compteRendu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeProjetCompteRendu = new SelectList(db.ProjetCompteRendus, "codeProjetCompteRendu", "realisationsCompletees", "codeProjetCompteRendu", compteRendu.codeProjetCompteRendu);
            return View(compteRendu);
        }

        // GET: CompteRendus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompteRendu compteRendu = db.CompteRendus.Find(id);
            if (compteRendu == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeProjetCompteRendu = new SelectList(db.ProjetCompteRendus, "codeProjetCompteRendu", "realisationsCompletees", "codeProjetCompteRendu", compteRendu.codeProjetCompteRendu);
            return View(compteRendu);
        }

        // POST: CompteRendus/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeCompteRendu,frequenceCompteRendu,dateCompteRendu,codeProjetCompteRendu")] CompteRendu compteRendu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compteRendu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeProjetCompteRendu = new SelectList(db.ProjetCompteRendus, "codeProjetCompteRendu", "realisationsCompletees", compteRendu.codeProjetCompteRendu);
            return View(compteRendu);
        }

        // GET: CompteRendus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompteRendu compteRendu = db.CompteRendus.Find(id);
            if (compteRendu == null)
            {
                return HttpNotFound();
            }
            return View(compteRendu);
        }

        // POST: CompteRendus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompteRendu compteRendu = db.CompteRendus.Find(id);
            db.CompteRendus.Remove(compteRendu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
