using Geometrix_API.Excepciones;
using Geometrix_API.Models;
using Geometrix_API.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static Geometrix_API.Estructuras.HelperDTO;

namespace Geometrix_API.Controllers
{
    public class ProductionController: ApiController
    {
        private const int MaxMinPiezas = 1000000;
        [System.Web.Http.HttpPost]
        public IHttpActionResult postProduction(ProductionRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if(model != null)
                {
                    List<Cantidades_Figura> cantidadesFigura = model.Cantidades;
                    int cant = cantidadesFigura.Sum(x => x.Cantidad);
                    RepositorioProduccion repositorio = new RepositorioProduccion();
                    Produccion produccion = repositorio.GetAll().FirstOrDefault(x => x.Fecha == model.Fecha);
                    if (produccion == null)
                    {
                        if (cant == MaxMinPiezas)
                        {
                            repositorio.Create_Sets(model.Fecha, cantidadesFigura);
                            repositorio.Create_Production(model);
                        }
                        else
                        {
                            throw new GettingException(string.Format("La cantidad de piezas {0} no es correcta. Debe ser de {1}", cant, MaxMinPiezas));
                        }
                    }
                    else
                    {
                        throw new GettingException(string.Format("Ya se encuentra almacenada la producción para la fecha {0}", model.Fecha));
                    }
                }
            }
            catch (GettingException ex1)
            {
                return Ok(ex1.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok();
        }

        [System.Web.Http.HttpGet]
        public List<Detalle_Sets> getProduction(DateTime fecha)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return null;
                }
                
                if(fecha != null)
                {
                    RepositorioProduccion repositorio = new RepositorioProduccion();
                    return repositorio.Obtener_Produccion(fecha);
                }
                else
                {
                    throw new GettingException("Debe indicar una fecha");
                }

            }
            catch (GettingException ex1)
            {
                throw ex1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}