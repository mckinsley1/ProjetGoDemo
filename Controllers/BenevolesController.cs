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
    public class BenevolesController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: Benevoles
        public ActionResult Index()
        {
            var benevoles = db.Benevoles.Include(b => b.Utilisateur);
            return View(benevoles.ToList());
        }

        // GET: Benevoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benevole benevole = db.Benevoles.Find(id);
            if (benevole == null)
            {
                return HttpNotFound();
            }
            return View(benevole);
        }

        // GET: Benevoles/Create
        public ActionResult Create()
        {
            ViewBag.codeUser = new SelectList(db.Utilisateurs, "codeUser", "nomUser","prenomUser");
            return View();
        }

        // POST: Benevoles/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeBenevole,dateAdhesionBenevole,codeUser")] Benevole benevole)
        {
            if (ModelState.IsValid)
            {
                db.Benevoles.Add(benevole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeUser = new SelectList(db.Utilisateurs, "codeUser", "nomUser","prenomUser", benevole.codeUser);
            return View(benevole);
        }

        // GET: Benevoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benevole benevole = db.Benevoles.Find(id);
            if (benevole == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeUser = new SelectList(db.Utilisateurs, "codeUser", "nomUser", "prenomUser", benevole.codeUser);
            return View(benevole);
        }

        // POST: Benevoles/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeBenevole,dateAdhesionBenevole,codeUser")] Benevole benevole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benevole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeUser = new SelectList(db.Utilisateurs, "codeUser", "nomUser","prenomUser", benevole.codeUser);
            return View(benevole);
        }

        // GET: Benevoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benevole benevole = db.Benevoles.Find(id);
            if (benevole == null)
            {
                return HttpNotFound();
            }
            return View(benevole);
        }

        // POST: Benevoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Benevole benevole = db.Benevoles.Find(id);
            db.Benevoles.Remove(benevole);
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
