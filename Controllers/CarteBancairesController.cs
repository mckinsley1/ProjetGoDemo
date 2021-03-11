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
    public class CarteBancairesController : Controller
    {
        private ProjetGo_dbEntities db = new ProjetGo_dbEntities();

        // GET: CarteBancaires
        public ActionResult Index()
        {
            var carteBancaires = db.CarteBancaires.Include(c => c.Membre);
            return View(carteBancaires.ToList());
        }

        // GET: CarteBancaires/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarteBancaire carteBancaire = db.CarteBancaires.Find(id);
            if (carteBancaire == null)
            {
                return HttpNotFound();
            }
            return View(carteBancaire);
        }

        // GET: CarteBancaires/Create
        public ActionResult Create()
        {
            ViewBag.codeMembre = new SelectList(db.Membres, "codeMembre", "nomStatut");
            return View();
        }

        // POST: CarteBancaires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroCarteBancaire,dateExpirationCateBancaire,nomDetenteurCarteBancaire,adresseDetenteurCarteBaincaire,villeDetenteurCarteBaincaire,provinceDetenteurCarteBaincaire,cpDetenteurCarteBaincaire,numeroControleCarteBancaire,codeMembre")] CarteBancaire carteBancaire)
        {
            if (ModelState.IsValid)
            {
                db.CarteBancaires.Add(carteBancaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeMembre = new SelectList(db.Membres, "codeMembre", "nomStatut", carteBancaire.codeMembre);
            return View(carteBancaire);
        }

        // GET: CarteBancaires/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarteBancaire carteBancaire = db.CarteBancaires.Find(id);
            if (carteBancaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeMembre = new SelectList(db.Membres, "codeMembre", "nomStatut", carteBancaire.codeMembre);
            return View(carteBancaire);
        }

        // POST: CarteBancaires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroCarteBancaire,dateExpirationCateBancaire,nomDetenteurCarteBancaire,adresseDetenteurCarteBaincaire,villeDetenteurCarteBaincaire,provinceDetenteurCarteBaincaire,cpDetenteurCarteBaincaire,numeroControleCarteBancaire,codeMembre")] CarteBancaire carteBancaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carteBancaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeMembre = new SelectList(db.Membres, "codeMembre", "nomStatut", carteBancaire.codeMembre);
            return View(carteBancaire);
        }

        // GET: CarteBancaires/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarteBancaire carteBancaire = db.CarteBancaires.Find(id);
            if (carteBancaire == null)
            {
                return HttpNotFound();
            }
            return View(carteBancaire);
        }

        // POST: CarteBancaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CarteBancaire carteBancaire = db.CarteBancaires.Find(id);
            db.CarteBancaires.Remove(carteBancaire);
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
