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
    public class CampagneLeveeFondsController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: CampagneLeveeFonds
        public ActionResult Index(CampagneLeveeFond u)
        {
            var campagneLeveeFonds = db.CampagneLeveeFonds.Include(c => c.Projet);
            return View(campagneLeveeFonds.ToList());
        }

        // GET: CampagneLeveeFonds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampagneLeveeFond campagneLeveeFond = db.CampagneLeveeFonds.Find(id);
            if (campagneLeveeFond == null)
            {
                return HttpNotFound();
            }
            return View(campagneLeveeFond);
        }

        // GET: CampagneLeveeFonds/Create
        public ActionResult Create()
        {
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet");
            return View();
        }

        // POST: CampagneLeveeFonds/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeCampagneLeveeFond,titreCampagneLeveeFond,dateDebutCampagneLeveeFond,dateFinCampagneLeveeFond,montantCibleCampagneLeveeFond,totalRealiseCampagneLeveeFond,codeProjet")] CampagneLeveeFond campagneLeveeFond)
        {

            if (ModelState.IsValid)
            {
                db.CampagneLeveeFonds.Add(campagneLeveeFond);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            CampagneLeveeFond campagneLevee = db.CampagneLeveeFonds.Find(query);

            if (campagneLevee == null)
            {
                db.CampagneLeveeFonds.Add(campagneLevee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", campagneLeveeFond.codeProjet);
            return View(campagneLeveeFond);
        }

        // GET: CampagneLeveeFonds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampagneLeveeFond campagneLeveeFond = db.CampagneLeveeFonds.Find(id);
            if (campagneLeveeFond == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", campagneLeveeFond.codeProjet);
            return View(campagneLeveeFond);
        }

        // POST: CampagneLeveeFonds/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeCampagneLeveeFond,titreCampagneLeveeFond,dateDebutCampagneLeveeFond,dateFinCampagneLeveeFond,montantCibleCampagneLeveeFond,totalRealiseCampagneLeveeFond,codeProjet")] CampagneLeveeFond campagneLeveeFond)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campagneLeveeFond).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeProjet = new SelectList(db.Projets, "codeProjet", "titreProjet", campagneLeveeFond.codeProjet);
            return View(campagneLeveeFond);
        }

        // GET: CampagneLeveeFonds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampagneLeveeFond campagneLeveeFond = db.CampagneLeveeFonds.Find(id);
            if (campagneLeveeFond == null)
            {
                return HttpNotFound();
            }
            return View(campagneLeveeFond);
        }

        // POST: CampagneLeveeFonds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampagneLeveeFond campagneLeveeFond = db.CampagneLeveeFonds.Find(id);
            db.CampagneLeveeFonds.Remove(campagneLeveeFond);
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
