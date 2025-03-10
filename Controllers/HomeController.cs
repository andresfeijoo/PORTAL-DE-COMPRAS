using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalCompras.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult indexlogueado()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult indexlogueadopro()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult indexlogueadouser()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}