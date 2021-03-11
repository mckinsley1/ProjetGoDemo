using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetGo;

namespace ProjetGo.Controllers
{
    public class FichiersController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: Fichiers
        public ActionResult Index()
        {
            var fichiers = db.Fichiers.Include(f => f.Projet);
            return View(fichiers.ToList());
        }

        // GET: Fichiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichier fichier = db.Fichiers.Find(id);
            if (fichier == null)
            {
                return HttpNotFound();
            }
            return View(fichier);
        }

        // GET: Fichiers/Create
        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet");
            return View();
        }

        // POST: Fichiers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
    
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codefichier,nomAltFichier,linkFichier,codeProjet")] Fichier fichier)
        {
            if (ModelState.IsValid)
            {
                db.Fichiers.Add(fichier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", fichier.codeProjet);
            return View(fichier);
        }

        // GET: Fichiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichier fichier = db.Fichiers.Find(id);
            if (fichier == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", fichier.codeProjet);
            return View(fichier);
        }

        // POST: Fichiers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codefichier,nomAltFichier,linkFichier,codeProjet")] Fichier fichier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", fichier.codeProjet);
            return View(fichier);
        }

        // GET: Fichiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichier fichier = db.Fichiers.Find(id);
            if (fichier == null)
            {
                return HttpNotFound();
            }
            return View(fichier);
        }

        // POST: Fichiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fichier fichier = db.Fichiers.Find(id);
            db.Fichiers.Remove(fichier);
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
