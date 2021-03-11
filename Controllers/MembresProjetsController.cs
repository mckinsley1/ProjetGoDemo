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
    public class MembresProjetsController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: MembresProjets
        public ActionResult Index(string Sorting_Order)
        {
            var membresProjets = db.MembresProjets.Include(m => m.Membre).Include(m => m.Projet);           
           
            return View(membresProjets.ToList());
        }

        // GET: MembresProjets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembresProjet membresProjet = db.MembresProjets.Find(id);
            if (membresProjet == null)
            {
                return HttpNotFound();
            }        
                return View(membresProjet);
        }

        // GET: MembresProjets/Create
        public ActionResult Create()
        {
            ViewBag.codeMembre = new SelectList(db.Membres, "codeMembre");
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet");
            return View();
        }

        // POST: MembresProjets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeMembreProjet,responsableProjet,codeMembre,codeProjet")] MembresProjet membresProjet)
        {
            if (ModelState.IsValid)
            {
                db.MembresProjets.Add(membresProjet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeMembre = new SelectList(db.Membres, "codeMembre", "nomStatut", membresProjet.codeMembre);
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", membresProjet.codeProjet);
            return View(membresProjet);
        }

        // GET: MembresProjets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembresProjet membresProjet = db.MembresProjets.Find(id);
            if (membresProjet == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeMembre = new SelectList(db.Membres, "codeMembre", "nomStatut", membresProjet.codeMembre);
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", membresProjet.codeProjet);
            return View(membresProjet);
        }

        // POST: MembresProjets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeMembreProjet,responsableProjet,codeMembre,codeProjet")] MembresProjet membresProjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membresProjet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeMembre = new SelectList(db.Membres, "codeMembre", "nomStatut", membresProjet.codeMembre);
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", membresProjet.codeProjet);
            return View(membresProjet);
        }

        // GET: MembresProjets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembresProjet membresProjet = db.MembresProjets.Find(id);
            if (membresProjet == null)
            {
                return HttpNotFound();
            }
            return View(membresProjet);
        }

        // POST: MembresProjets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembresProjet membresProjet = db.MembresProjets.Find(id);
            db.MembresProjets.Remove(membresProjet);
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
