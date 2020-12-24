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

       
    }
}