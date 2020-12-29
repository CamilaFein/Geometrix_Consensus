using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geometrix_Consensus.Views.Models
{
    public class LocalModel
    {

    }

    public class Figuras
    {

        //Modelo para tener estado de Pedidos
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public long cantidad { get; set; }
  
    }

    public class SetFiguras
    {

        //Modelo para tener estado de Pedidos
        public int ID { get; set; }
        public int Cuadrado { get; set; }
        public int Rectangulo { get; set; }
        public int Triangulo { get; set; }
        public int Circulo { get; set; }
        public decimal ValorizadoCuadrado { get; set; }
        public decimal ValorizadoRectangulo { get; set; }
        public decimal ValorizadoTriangulo { get; set; }
        public decimal ValorizadoCiruculo { get; set; }
        public decimal Total_Set { get; set; }

    }
}