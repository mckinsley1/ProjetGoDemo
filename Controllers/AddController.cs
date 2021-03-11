using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetGo.Controllers
{
    public class AddController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Fichier fichierModel)
        {


            string fileName = Path.GetFileNameWithoutExtension(fichierModel.FichierFile.FileName);
            string extension = Path.GetExtension(fichierModel.FichierFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            fichierModel.linkFichier = "~/Content/images/projets/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/images/projets/"), fileName);
            fichierModel.FichierFile.SaveAs(fileName);
            using (ProjetGo_dbEntities db = new ProjetGo_dbEntities())
            {
                db.Fichiers.Add(fichierModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            Fichier fichierModel = new Fichier();
            using (ProjetGo_dbEntities db = new ProjetGo_dbEntities())
            {
                fichierModel = db.Fichiers.Where(x => x.codefichier == id).FirstOrDefault();
            }

            return View(fichierModel);
        }

    }
}