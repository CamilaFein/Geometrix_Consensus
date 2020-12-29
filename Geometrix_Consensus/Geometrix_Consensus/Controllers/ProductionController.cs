using Geometrix_Consensus.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geometrix_Consensus.Controllers
{
    public class ProductionController : Controller
    {
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Generar Produccion";

            List<Figuras> figuras = new List<Figuras>();

            Figuras figura1 = new Figuras();
            figura1.Descripcion = "Rectangulo";
            figura1.ID = 1;
            figuras.Add(figura1);
            Figuras figura2 = new Figuras();
            figura2.Descripcion = "Circulo";
            figura2.ID = 2;
            figuras.Add(figura2);
            Figuras figura3 = new Figuras();
            figura3.Descripcion = "Cuadrado";
            figura3.ID = 3;
            figuras.Add(figura3);
            Figuras figura4 = new Figuras();
            figura4.Descripcion = "Triangulo";
            figura4.ID = 4;
            figuras.Add(figura4);

            return View(figuras);
        }
        
        public ActionResult AddProduction(IList<Figuras> itm)
        {
            string fecha = Request.Form["example-date-input"];
            if (itm != null)
            {
                foreach (Figuras i in itm)
                {
                    if (i.cantidad > 0)
                    {
                        String aux = i.Descripcion;
                    }
                }
            }
            return RedirectToAction("Index", "Home");
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