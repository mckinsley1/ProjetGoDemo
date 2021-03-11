using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetGo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Benevole()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Don()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Membre()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Projets()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Realisations()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}