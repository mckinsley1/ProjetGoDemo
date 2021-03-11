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
    public class MembreRecusController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: MembreRecus
        public ActionResult Index()
        {
            var membreRecus = db.MembreRecus.Include(m => m.CarteBancaire);
            return View(membreRecus.ToList());
        }

        // GET: MembreRecus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembreRecu membreRecu = db.MembreRecus.Find(id);
            if (membreRecu == null)
            {
                return HttpNotFound();
            }
            return View(membreRecu);
        }

        // GET: MembreRecus/Create
        public ActionResult Create()
        {
            ViewBag.numeroCarteBancaire = new SelectList(db.CarteBancaires, "numeroCarteBancaire", "nomDetenteurCarteBancaire");
            return View();
        }

        // POST: MembreRecus/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeRecuMembre,dateRecuMembre,totalRecuMembre,numeroCarteBancaire")] MembreRecu membreRecu)
        {
            if (ModelState.IsValid)
            {
                db.MembreRecus.Add(membreRecu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numeroCarteBancaire = new SelectList(db.CarteBancaires, "numeroCarteBancaire", "nomDetenteurCarteBancaire", membreRecu.numeroCarteBancaire);
            return View(membreRecu);
        }

        // GET: MembreRecus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembreRecu membreRecu = db.MembreRecus.Find(id);
            if (membreRecu == null)
            {
                return HttpNotFound();
            }
            ViewBag.numeroCarteBancaire = new SelectList(db.CarteBancaires, "numeroCarteBancaire", "nomDetenteurCarteBancaire", membreRecu.numeroCarteBancaire);
            return View(membreRecu);
        }

        // POST: MembreRecus/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeRecuMembre,dateRecuMembre,totalRecuMembre,numeroCarteBancaire")] MembreRecu membreRecu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membreRecu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numeroCarteBancaire = new SelectList(db.CarteBancaires, "numeroCarteBancaire", "nomDetenteurCarteBancaire", membreRecu.numeroCarteBancaire);
            return View(membreRecu);
        }

        // GET: MembreRecus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembreRecu membreRecu = db.MembreRecus.Find(id);
            if (membreRecu == null)
            {
                return HttpNotFound();
            }
            return View(membreRecu);
        }

        // POST: MembreRecus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembreRecu membreRecu = db.MembreRecus.Find(id);
            db.MembreRecus.Remove(membreRecu);
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
