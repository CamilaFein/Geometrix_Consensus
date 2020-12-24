using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geometrix_API.Excepciones
{
    public class GettingException:Exception
    {
        public GettingException(string mensaje) : base(mensaje)
        {

        }
    }
}