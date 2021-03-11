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
    public class DonsController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: Dons
        public ActionResult Index()
        {
            var dons = db.Dons.Include(d => d.CampagneLeveeFond);
            return View(dons.ToList());

        }

        // GET: Dons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don don = db.Dons.Find(id);
            if (don == null)
            {
                return HttpNotFound();
            }
            return View(don);
        }

        // GET: Dons/Create
        public ActionResult Create()
        {
            ViewBag.codeCampagneLeveeFond = new SelectList(db.CampagneLeveeFonds, "codeCampagneLeveeFond", "titreCampagneLeveeFond");
            return View();
        }

        // POST: Dons/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeDon,montantDon,typePaiementDon,nomDonateur,prenomDonateur,dateDon,emailDonateur,numPhoneDonateur,adresseDonateur,villeDonateur,cpDonateur,PaysDonateur,codeCampagneLeveeFond")] Don don)
        {
            if (ModelState.IsValid)
            {
                db.Dons.Add(don);
                db.SaveChanges();
                return RedirectToAction("PayPal");
            }

            ViewBag.codeCampagneLeveeFond = new SelectList(db.CampagneLeveeFonds, "codeCampagneLeveeFond", "titreCampagneLeveeFond", don.codeCampagneLeveeFond);
            return View();
        }

        // GET: Dons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don don = db.Dons.Find(id);
            if (don == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeCampagneLeveeFond = new SelectList(db.CampagneLeveeFonds, "codeCampagneLeveeFond", "titreCampagneLeveeFond", don.codeCampagneLeveeFond);
            return View(don);
        }

        // POST: Dons/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeDon,montantDon,typePaiementDon,nomDonateur,prenomDonateur,dateDon,emailDonateur,numPhoneDonateur,adresseDonateur,villeDonateur,cpDonateur,PaysDonateur,codeCampagneLeveeFond")] Don don)
        {
            if (ModelState.IsValid)
            {
                db.Entry(don).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeCampagneLeveeFond = new SelectList(db.CampagneLeveeFonds, "codeCampagneLeveeFond", "titreCampagneLeveeFond", don.codeCampagneLeveeFond);
            return View(don);
        }

        // GET: Dons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don don = db.Dons.Find(id);
            if (don == null)
            {
                return HttpNotFound();
            }
            return View(don);
        }

        // POST: Dons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Don don = db.Dons.Find(id);
            db.Dons.Remove(don);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PayPal()
        {
            return View();
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
