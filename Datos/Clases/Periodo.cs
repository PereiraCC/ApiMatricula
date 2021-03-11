using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Periodo 
    {
        private CatalogoEntities entities;

        public Periodo()
        {
            entities = new CatalogoEntities();
        }

        public bool ConsultarExistePeriodo(string numero)
        {
            try
            {
                var query = from c in entities.Periodos
                            where c.Numero == numero
                            select c;

                List<Periodos> periodo = query.ToList<Periodos>();
                if (periodo.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IDPeriodoExistente(string numero)
        {
            try
            {
                var query = from c in entities.Periodos
                            where c.Numero == numero
                            select c;

                List<Periodos> periodos = query.ToList<Periodos>();
                foreach (Periodos periodo in periodos)
                {
                    if (periodo.Numero == numero)
                    {
                        return periodo.idPeriodo;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CodigoPeriodoExistente(int idPeriodo)
        {
            try
            {
                var query = from c in entities.Periodos
                            where c.idPeriodo == idPeriodo
                            select c;

                List<Periodos> periodos = query.ToList<Periodos>();
                foreach (Periodos periodo in periodos)
                {
                    if (periodo.idPeriodo == idPeriodo)
                    {
                        return periodo.Numero;
                    }
                }

                return "No";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearPeriodo(Periodos periodo)
        {
            try
            {
                entities.Periodos.Add(periodo);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarPeriodo(int idPeriodo)
        {
            try
            {
                Periodos periodo = entities.Periodos.First<Periodos>(x => x.idPeriodo == idPeriodo);
                entities.Periodos.Remove(periodo);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarPeriodo(int idPeriodo, string numero, DateTime FechaInicio, DateTime FechaFinal, bool activo)
        {
            try
            {
                Periodos periodo = entities.Periodos.First<Periodos>(x => x.idPeriodo == idPeriodo);
                periodo.Numero = numero;
                periodo.FechaInicio = FechaInicio;
                periodo.FechaFinal = FechaFinal;
                periodo.activo = activo;

                entities.Entry(periodo).State = EntityState.Modified;

                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Periodos> obtenerPeriodos()
        {
            try
            {
                return entities.Periodos.ToList<Periodos>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Periodos> obtenerPeriodosFiltrado(string numero)
        {
            try
            {
                var query = from c in entities.Periodos
                            where c.Numero == numero
                            select c;

                return query.ToList<Periodos>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int obtenerperiodoAnterior(Periodos actual)
        {
            try
            {
                var query = from temp in entities.Periodos
                            where temp.activo == true
                            select temp;
                List<Periodos> periodo = query.ToList<Periodos>();
                foreach (Periodos p in periodo)
                {
                    if (p.idPeriodo != actual.idPeriodo && actual.FechaInicio > p.FechaFinal && actual.Año == p.Año)
                    {
                        return p.idPeriodo;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int obtenerPeriodoSiguiente(Periodos actual)
        {
            try
            {
                var query = from temp in entities.Periodos
                            where temp.activo == true
                            select temp;
                List<Periodos> periodo = query.ToList<Periodos>();
                foreach (Periodos p in periodo)
                {
                    if (p.idPeriodo != actual.idPeriodo && actual.FechaFinal < p.FechaInicio && actual.Año == p.Año)
                    {
                        return p.idPeriodo;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int establecerPeriodoActual(Periodos actual)
        {
            try
            {
                var query = from temp in entities.Periodos
                            where temp.activo == true
                            select temp;
                List<Periodos> periodo = query.ToList<Periodos>();
                foreach (Periodos p in periodo)
                {
                    if (p.idPeriodo != actual.idPeriodo && actual.FechaInicio > p.FechaFinal && actual.Año == p.Año)
                    {
                        return p.idPeriodo;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
