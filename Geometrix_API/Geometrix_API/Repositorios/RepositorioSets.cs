using Geometrix_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Geometrix_API.Estructuras.HelperDTO;

namespace Geometrix_API.Repositorios
{
    public class RepositorioSets
    {
        ConsensusEntities db = new ConsensusEntities();
        public IQueryable<Sets> GetAll()
        {
            IQueryable<Sets> lista = from p in db.Sets
                                           select p;
            return lista;
        }
        public IQueryable<Sets_Figuras> GetAll_IT_Sets()
        {
            IQueryable<Sets_Figuras> sets = from s in db.Sets_Figuras
                                select s;
            return sets;
        }
        public List<Detalle_Produccion> ObtenerSets(DateTime fecha)
        {
            List<Sets> sets = GetAll().Where(x => x.Fecha == fecha).ToList();
            List<Detalle_Produccion> setsFiguras = (from s in sets
                              join sf in GetAll_IT_Sets().ToList() on s.ID_Set equals sf.ID_Set
                              join f in (new RepositorioFiguras()).GetAll().ToList() on sf.ID_Figura equals f.ID_Figura
                              select new Detalle_Produccion {
                                  Figura = f.Descripcion,
                                  Cantidad = sf.Cantidad,
                                  Precio = sf.Precio_Set
                              }).ToList();
            return setsFiguras;
        }
    }
}