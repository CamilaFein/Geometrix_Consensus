using Geometrix_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geometrix_API.Repositorios
{
    public class RepositorioFiguras
    {
        ConsensusEntities db = new ConsensusEntities();
        public IQueryable<Figuras> GetAll()
        {
            IQueryable<Figuras> lista = from f in db.Figuras
                                        select f;
            return lista;
        }

        public Figuras SingleID(int id)
        {
            Figuras figura = db.Figuras.FirstOrDefault(x => x.ID_Figura == id);
            return figura;
        }
    }
}