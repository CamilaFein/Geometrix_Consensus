using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geometrix_Consensus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Bienvenidos al Sistema de Produccion";
            ViewData["Message"] = "En esta aplicacion usted podra ingresar la produccion diaria y consultar los informes de Produccion";
            ViewData["Fecha"] = DateTime.Now;
            ViewData["Version"] = "20201228V2";

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
    }
}