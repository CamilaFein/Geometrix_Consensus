using Geometrix_Consensus.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geometrix_Consensus.Controllers
{
    public class InformeController : Controller
    {
        decimal por_costo = 60, por_ganancia = 40;
        public ActionResult Index()
        {

            ViewData["SubTitle"] = "Produccion Diaria";

            List<SetFiguras> setFiguras = new List<SetFiguras>();

            SetFiguras setfigura1 = new SetFiguras();
            setfigura1.ID = 1;
            setfigura1.Cuadrado = 2;
            setfigura1.Rectangulo = 1;
            setfigura1.Triangulo = 0;
            setfigura1.Circulo = 1;
            setfigura1.ValorizadoCuadrado = 20;
            setfigura1.ValorizadoRectangulo = 11;
            setfigura1.ValorizadoTriangulo = 0;
            setfigura1.ValorizadoCiruculo = 14;
            setfigura1.Total_Set = 40;
            setFiguras.Add(setfigura1);

            SetFiguras setfigura2 = new SetFiguras();
            setfigura2.ID = 2;
            setfigura2.Cuadrado = 1;
            setfigura2.Rectangulo = 0;
            setfigura2.Triangulo = 0;
            setfigura2.Circulo = 3;
            setfigura2.ValorizadoCuadrado = 10;
            setfigura2.ValorizadoRectangulo = 0;
            setfigura2.ValorizadoTriangulo = 0;
            setfigura2.ValorizadoCiruculo = 43;
            setfigura2.Total_Set = 53;
            setFiguras.Add(setfigura2);

            SetFiguras setfigura3 = new SetFiguras();
            setfigura3.ID = 3;
            setfigura3.Cuadrado = 0;
            setfigura3.Rectangulo = 0;
            setfigura3.Triangulo = 4;
            setfigura3.Circulo = 0;
            setfigura3.ValorizadoCuadrado = 0;
            setfigura3.ValorizadoRectangulo = 0;
            setfigura3.ValorizadoTriangulo = 48;
            setfigura3.ValorizadoCiruculo = 0;
            setfigura3.Total_Set = 48;
            setFiguras.Add(setfigura3);

            SetFiguras setfigura4 = new SetFiguras();
            setfigura4.ID = 4;
            setfigura4.Cuadrado = 1;
            setfigura4.Rectangulo = 1;
            setfigura4.Triangulo = 1;
            setfigura4.Circulo = 1;
            setfigura4.ValorizadoCuadrado = 10;
            setfigura4.ValorizadoRectangulo = 11;
            setfigura4.ValorizadoTriangulo = 12;
            setfigura4.ValorizadoCiruculo = 14;
            setfigura4.Total_Set = 47;
            setFiguras.Add(setfigura4);

            ViewBag.Cant_Rectangulo = setFiguras.Sum(q => q.Rectangulo);
            ViewBag.Cant_Cuadrado = setFiguras.Sum(q => q.Cuadrado);
            ViewBag.Cant_Triangulo = setFiguras.Sum(q => q.Triangulo);
            ViewBag.Cant_Circulo = setFiguras.Sum(q => q.Circulo);

            decimal total_costo, ganancia_percibida, precio_total;

            total_costo = setFiguras.Sum(q => q.Total_Set);
            ganancia_percibida = (por_ganancia * total_costo) / por_costo;
            precio_total = total_costo + ganancia_percibida;

            ViewBag.Total_Cantidad_Set = setFiguras.Count();
            ViewBag.Total_Costo = decimal.Round(total_costo, 2); 
            ViewBag.Ganancia_Percibida = decimal.Round(ganancia_percibida, 2); 
            ViewBag.Precio_Total = decimal.Round(precio_total, 2); 

            return View(setFiguras);
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