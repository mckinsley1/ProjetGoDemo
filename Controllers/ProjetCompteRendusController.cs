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
    public class ProjetCompteRendusController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: ProjetCompteRendus
        public ActionResult Index()
        {
            return View(db.ProjetCompteRendus.ToList());
        }

        // GET: ProjetCompteRendus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetCompteRendu projetCompteRendu = db.ProjetCompteRendus.Find(id);
            if (projetCompteRendu == null)
            {
                return HttpNotFound();
            }
            return View(projetCompteRendu);
        }

        // GET: ProjetCompteRendus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjetCompteRendus/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeProjetCompteRendu,realisationsCompletees,dateFinEstimee,echeancier,totalFondsCollectes,totalDepenses,etatAvancement,etatRisques")] ProjetCompteRendu projetCompteRendu)
        {
            if (ModelState.IsValid)
            {
                db.ProjetCompteRendus.Add(projetCompteRendu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projetCompteRendu);
        }

        // GET: ProjetCompteRendus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetCompteRendu projetCompteRendu = db.ProjetCompteRendus.Find(id);
            if (projetCompteRendu == null)
            {
                return HttpNotFound();
            }
            return View(projetCompteRendu);
        }

        // POST: ProjetCompteRendus/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeProjetCompteRendu,realisationsCompletees,dateFinEstimee,echeancier,totalFondsCollectes,totalDepenses,etatAvancement,etatRisques")] ProjetCompteRendu projetCompteRendu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projetCompteRendu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projetCompteRendu);
        }

        // GET: ProjetCompteRendus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetCompteRendu projetCompteRendu = db.ProjetCompteRendus.Find(id);
            if (projetCompteRendu == null)
            {
                return HttpNotFound();
            }
            return View(projetCompteRendu);
        }

        // POST: ProjetCompteRendus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjetCompteRendu projetCompteRendu = db.ProjetCompteRendus.Find(id);
            db.ProjetCompteRendus.Remove(projetCompteRendu);
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
