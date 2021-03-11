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
    public class ProjetsController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: Projets
        [Authorize]
        public ActionResult Index()
        {
            var projets = db.Projets.Include(p => p.ProjetCompteRendu);

            return View(projets.ToList());
        }

        // GET: Membres/Projets
        [Authorize]
        public ActionResult IndexMembresProjet()
        {
            var projets = db.Utilisateurs.Include(p => p.codeUser);

            return View(projets.ToList());
        }

        // GET: Projets/Campagnes
        [Authorize]
        public ActionResult IndexCampagnes()
        {
            var projets = db.CampagneLeveeFonds.Include(p => p.codeCampagneLeveeFond);

            return View(projets.ToList());
        }

        // GET: Projets public
        [HandleError]
        public ActionResult IndexPublic()
        {
            var projets = db.Projets.Include(p => p.ProjetCompteRendu);
            return View(projets.ToList());
        }

        // GET: Projets membres bénévoles
        [Authorize]
        public ActionResult IndexMB()
        {
            var projets = db.Projets.Include(p => p.ProjetCompteRendu);
            return View(projets.ToList());
        }

        // GET: Projets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // GET: Projets MB/Details/5
        public ActionResult DetailsMB(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }
        // GET: Projets MB/Details/5
        public ActionResult DetailsPublic(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // GET: Projets/Create
        public ActionResult Create()
        {
            ViewBag.codeProjetCompteRendu = new SelectList(db.ProjetCompteRendus, "codeProjetCompteRendu", "realisationsCompletees");
            return View();
        }

        // POST: Projets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeProjet,titreProjet,descriptionCourteProjet,butProjet,objectifProjet,statutProjet,beneficesEscomptees,dateDebutEstimeeProjet,budgetProjet,dateDebutReelleProjet,dateFinReelleProjet,linkFichier,codeProjetCompteRendu")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Projets.Add(projet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeProjetCompteRendu = new SelectList(db.ProjetCompteRendus, "codeProjetCompteRendu", "realisationsCompletees", projet.codeProjetCompteRendu);
            return View(projet);
        }

        // GET: Projets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeProjetCompteRendu = new SelectList(db.ProjetCompteRendus, "codeProjetCompteRendu", "realisationsCompletees", projet.codeProjetCompteRendu);
            return View(projet);
        }



        // POST: Projets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeProjet,titreProjet,descriptionCourteProjet,butProjet,objectifProjet,statutProjet,beneficesEscomptees,dateDebutEstimeeProjet,budgetProjet,dateDebutReelleProjet,dateFinReelleProjet,linkFichier,codeProjetCompteRendu")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeProjetCompteRendu = new SelectList(db.ProjetCompteRendus, "codeProjetCompteRendu", "realisationsCompletees", projet.codeProjetCompteRendu);
            return View(projet);
        }


        // GET: Projets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projet projet = db.Projets.Find(id);
            db.Projets.Remove(projet);
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
