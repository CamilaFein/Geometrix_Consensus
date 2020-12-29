using Geometrix_API.Excepciones;
using Geometrix_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Geometrix_API.Estructuras.HelperDTO;
using System.Data.Entity.Core.Objects;

namespace Geometrix_API.Repositorios
{
    public class RepositorioProduccion
    {
        ConsensusEntities db = new ConsensusEntities();
        public IQueryable<Produccion> GetAll()
        {
            IQueryable<Produccion> lista = from p in db.Produccion
                                        select p;
            return lista;
        }
        public Produccion GetByDate(DateTime fecha)
        {
            Produccion produccion = db.Produccion.FirstOrDefault(x => x.Fecha == fecha);
            return produccion;
        }
        public void Create_Sets(DateTime fecha, List<Cantidades_Figura> cantidadesFigura)
        {
            try
            {
                Sets set = null;
                int ID_Figura = 0;
                int Cantidad_Figura = 0;
                int Cantidad = 0;
                int i = 0;
                Random random = new Random();
                RepositorioFiguras repositorio = new RepositorioFiguras();
                List<int> IDs_Figuras = repositorio.GetAll().Select(x => x.ID_Figura).ToList();
                List<Sets_Figuras> lista = new List<Sets_Figuras>();
                Sets_Figuras item = null;
                Figuras figura = null;
                if (IDs_Figuras.Count > 0)
                {
                    throw new GettingException("Debe tener cargada al menos una figura");
                }
                while (cantidadesFigura.Sum(x => x.Cantidad) != 0)
                {
                    set = new Sets();
                    set.Fecha = fecha;
                    db.SaveChanges();
                    for (i = 0; i <= 4; i++)
                    {
                        ID_Figura = random.Next(IDs_Figuras.Min(), IDs_Figuras.Max());
                        figura = repositorio.SingleID(ID_Figura);
                        if (figura != null)
                        {
                            Cantidad_Figura = cantidadesFigura.FirstOrDefault(x => x.ID_Figura == ID_Figura).Cantidad;
                            Cantidad = random.Next(0, 4);
                            if (Cantidad_Figura < Cantidad)
                            {
                                break;
                            }
                            else
                            {
                                item = lista.FirstOrDefault(x => x.ID_Figura == ID_Figura && x.ID_Set == set.ID_Set);
                                if (item != null)
                                {
                                    item.Cantidad = item.Cantidad + Cantidad;
                                    item.Precio_Set = item.Cantidad * figura.Precio;
                                    lista.Where(x => x.ID_Figura == ID_Figura && x.ID_Set == set.ID_Set).ToList().ForEach(x => x.Cantidad = item.Cantidad);
                                }
                                else
                                {
                                    item = new Sets_Figuras();
                                    item.ID_Set = set.ID_Set;
                                    item.ID_Figura = ID_Figura;
                                    item.Cantidad = Cantidad;
                                    item.Precio_Set = Cantidad * figura.Precio;
                                    lista.Add(item);
                                }
                                cantidadesFigura.Where(x => x.ID_Figura == ID_Figura).ToList().ForEach(s => s.Cantidad = (s.Cantidad - Cantidad));
                                db.SaveChanges();
                                i += Cantidad;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Create_Production(ProductionRequest model)
        {
            try
            {
                IT_Produccion item = new IT_Produccion();
                RepositorioFiguras repositorio = new RepositorioFiguras();
                Figuras figura = new Figuras();
                Produccion produccion = new Produccion();
                produccion.Fecha = model.Fecha;
                db.SaveChanges();
                foreach(Cantidades_Figura cant in model.Cantidades)
                {
                    if(cant.Cantidad != 0)
                    {
                        figura = repositorio.SingleID(cant.ID_Figura);
                        item.ID_Figura = cant.ID_Figura;
                        item.Cantidad = cant.Cantidad;
                        item.ID_Produccion = produccion.ID_Produccion;
                        item.Total_Costo = cant.Cantidad * figura.Precio;
                    }
                }
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Detalle_Sets> Obtener_Produccion(DateTime fecha)
        {
            try
            {
               return db.Detalle_Sets(fecha).Select(x => new Detalle_Sets() { 
                   ID_Set = x.ID_Set,
                   Cuadrado = x.Cuadrado,
                   Circulo = x.Circulo,
                   Rectangulo = x.Rectangulo,
                   Triangulo = x.Triangulo,
                   Valorizado_Circulo = x.Valorizado_Circulo,
                   Valorizado_Cuadrado = x.Valorizado_Cuadrado,
                   Valorizado_Rectangulo = x.Valorizado_Rectangulo,
                   Valorizado_Triangulo = x.Valorizado_Triangulo,
                   Total_Set = x.Total_Set
               }).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}