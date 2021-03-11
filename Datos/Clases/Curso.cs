using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Curso
    {
        private CatalogoEntities entities;

        public Curso()
        {
            entities = new CatalogoEntities();
        }

        public bool ConsultarExisteCurso(int codigo)
        {
            try
            {
                var query = from c in entities.Cursos
                            where c.Codigo == codigo
                            select c;

                List<Cursos> curso = query.ToList<Cursos>();
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

        public bool ConsultarExisteCurso(string nombreCurso)
        {
            try
            {
                var query = from c in entities.Cursos
                            where c.Nombre == nombreCurso
                            select c;

                List<Cursos> curso = query.ToList<Cursos>();
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

        public bool ConsultarExisteCarrera(int codigo)
        {
            try
            {
                var query = from c in entities.Carreras
                            where c.idCarrera == codigo
                            select c;

                List<Carreras> carrera = query.ToList<Carreras>();
                if (carrera.Count > 0)
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

        public int IDCursoExistente(int codigo)
        {
            try
            {
                var query = from c in entities.Cursos
                            where c.Codigo == codigo 
                            select c;

                List<Cursos> curso = query.ToList<Cursos>();
                foreach (Cursos usu in curso)
                {
                    if (usu.Codigo == codigo)
                    {
                        return usu.idCurso;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IDCursoExistente(string nombreCurso)
        {
            try
            {
                var query = from c in entities.Cursos
                            where c.Nombre == nombreCurso
                            select c;

                List<Cursos> curso = query.ToList<Cursos>();
                foreach (Cursos usu in curso)
                {
                    if (usu.Nombre == nombreCurso)
                    {
                        return usu.idCurso;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerNombreCurso(int idCurso)
        {
            try
            {
                var query = from c in entities.Cursos
                            where c.idCurso == idCurso
                            select c;

                List<Cursos> curso = query.ToList<Cursos>();
                foreach (Cursos usu in curso)
                {
                    if (usu.idCurso == idCurso)
                    {
                        return usu.Nombre;
                    }
                }
                return "No";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearCurso(Cursos usu)
        {
            try
            {
                entities.Cursos.Add(usu);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int EliminarCurso(int idCurso)
        {
            try
            {

                Cursos curso = entities.Cursos.First<Cursos>(x => x.idCurso == idCurso);
                entities.Cursos.Remove(curso);
                return entities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarCurso(int codigo, string nombre, int idCarrera)
        {
            try
            {
                Cursos curso = entities.Cursos.First<Cursos>(x => x.Codigo == codigo);
                curso.Nombre = nombre;
                curso.idCarrera = idCarrera;

                entities.Entry(curso).State = EntityState.Modified;

                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Cursos> obtenerCursos()
        {
            try
            {
                return entities.Cursos.ToList<Cursos>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cursos> obtenerCursoFiltrado(int idCarrera)
        {
            try
            {
                var query = from c in entities.Cursos
                            where c.idCarrera == idCarrera
                            select c;

                return query.ToList<Cursos>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        

        //public List<Horarios> ObtenerHorariosdeCurso(int curso)
        //{
        //    try
        //    {
        //        var query = from temp in entities.Horarios
        //                    where temp.idCurso == curso
        //                    select temp;
        //        return query.ToList<Horarios>();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


    }
}
