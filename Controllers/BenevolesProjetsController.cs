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
    public class BenevolesProjetsController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: BenevolesProjets
        public ActionResult Index()
        {
            var benevolesProjets = db.BenevolesProjets.Include(b => b.Benevole).Include(b => b.Projet);
            return View(benevolesProjets.ToList());
        }

        // GET: BenevolesProjets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenevolesProjet benevolesProjet = db.BenevolesProjets.Find(id);
            if (benevolesProjet == null)
            {
                return HttpNotFound();
            }
            return View(benevolesProjet);
        }

        // GET: BenevolesProjets/Create
        public ActionResult Create()
        {
            ViewBag.codeBenevole = new SelectList(db.Benevoles, "codeBenevole", "codeBenevole");
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet");
            return View();
        }

        // POST: BenevolesProjets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeBenevoleProjet,codeProjet,codeBenevole")] BenevolesProjet benevolesProjet)
        {
            if (ModelState.IsValid)
            {
                db.BenevolesProjets.Add(benevolesProjet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeBenevole = new SelectList(db.Benevoles, "codeBenevole", "codeBenevole", benevolesProjet.codeBenevole);
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", benevolesProjet.codeProjet);
            return View(benevolesProjet);
        }

        // GET: BenevolesProjets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenevolesProjet benevolesProjet = db.BenevolesProjets.Find(id);
            if (benevolesProjet == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeBenevole = new SelectList(db.Benevoles, "codeBenevole", "codeBenevole", benevolesProjet.codeBenevole);
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", benevolesProjet.codeProjet);
            return View(benevolesProjet);
        }

        // POST: BenevolesProjets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeBenevoleProjet,codeProjet,codeBenevole")] BenevolesProjet benevolesProjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benevolesProjet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeBenevole = new SelectList(db.Benevoles, "codeBenevole", "codeBenevole", benevolesProjet.codeBenevole);
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", benevolesProjet.codeProjet);
            return View(benevolesProjet);
        }

        // GET: BenevolesProjets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenevolesProjet benevolesProjet = db.BenevolesProjets.Find(id);
            if (benevolesProjet == null)
            {
                return HttpNotFound();
            }
            return View(benevolesProjet);
        }

        // POST: BenevolesProjets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BenevolesProjet benevolesProjet = db.BenevolesProjets.Find(id);
            db.BenevolesProjets.Remove(benevolesProjet);
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
