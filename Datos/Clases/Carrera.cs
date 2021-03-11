using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Carrera
    {
        private CatalogoEntities entities;

        public Carrera()
        {
            entities = new CatalogoEntities();
        }

        public bool ConsultarExisteCarrera(string codigo)
        {
            try
            {
                var query = from c in entities.Carreras
                            where c.Codigo == codigo
                            select c;

                List<Carreras> curso = query.ToList<Carreras>();
                if (curso.Count > 0)
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

        public int IDCarreraExistente(string codigo)
        {
            try
            {
                var query = from c in entities.Carreras
                            where c.Codigo == codigo
                            select c;

                List<Carreras> carreras = query.ToList<Carreras>();
                foreach (Carreras carrera in carreras)
                {
                    if (carrera.Codigo == codigo)
                    {
                        return carrera.idCarrera;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearCarrera(Carreras carrera)
        {
            try
            {
                entities.Carreras.Add(carrera);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int EliminarCarrera(int idCarrera)
        {
            try
            {
                Carreras carrera = entities.Carreras.First<Carreras>(x => x.idCarrera == idCarrera);
                entities.Carreras.Remove(carrera);
                return entities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarCarrera(string idCarrera, string codigo, string nombre)
        {
            try
            {
                Carreras carreras = entities.Carreras.First<Carreras>(x => x.Codigo == idCarrera);
                carreras.Codigo = codigo;
                carreras.Nombre = nombre;

                entities.Entry(carreras).State = EntityState.Modified;

                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Carreras> obtenerCarreras()
        {
            try
            {
                return entities.Carreras.ToList<Carreras>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Carreras> obtenerCarreraFiltrado(string codigo)
        {
            try
            {
                var query = from c in entities.Carreras
                            where c.Codigo == codigo
                            select c;

                return query.ToList<Carreras>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
