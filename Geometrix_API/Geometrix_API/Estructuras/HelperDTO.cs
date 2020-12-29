using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geometrix_API.Estructuras
{
    public class HelperDTO
    {
        public class ProductionRequest
        {
            public DateTime Fecha { get; set; }
            public List<Cantidades_Figura> Cantidades { get; set; }
        }

        public class Cantidades_Figura
        {
            public int ID_Figura { get; set; }
            public int Cantidad { get; set; }
            public decimal Total_Costo { get; set; }
        }
        public class ProductionResponse
        {
            public DateTime Fecha { get; set; }
            public decimal PrecioTotal { get; set; }
            public decimal Total_Costo { get; set; }
            public decimal Ganancia { get; set; }
        }
        public class Detalle_Produccion
        {
            public string Figura { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
        }
        
        public class Detalle_Sets
        {
           public int ID_Set { get; set; }
           public int Cuadrado { get; set; }
            public int Triangulo { get; set; }
            public int Circulo { get; set; }
            public int Rectangulo { get; set; }
            public decimal Valorizado_Cuadrado { get; set; }
            public decimal Valorizado_Rectangulo { get; set; }
            public decimal Valorizado_Triangulo { get; set; }
            public decimal Valorizado_Circulo { get; set; }
            public decimal Total_Set { get; set; }
        }
    }
}