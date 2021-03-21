using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Matricula
    {
        private CatalogoEntities entities;

        public Matricula()
        {
            entities = new CatalogoEntities();
        }

        public bool PeriodoActivo(string codigo)
        {
            try
            {
                var query = from p in entities.Periodos
                            where p.activo == true && p.Numero.Equals(codigo)
                            select p;
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

        public bool ConsultarExisteMatricular(int idEstudiante, DateTime fecha)
        {
            try
            {
                var query = from c in entities.Matriculas
                            where c.idEstudiante == idEstudiante && c.Fecha == fecha
                            select c;

                List<Matriculas> periodo = query.ToList<Matriculas>();
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

        public bool ConsultarExisteTipoMatricular(string nombre)
        {
            try
            {
                var query = from c in entities.TipoMatricula
                            where c.Descripcion == nombre
                            select c;

                List<TipoMatricula> tipos = query.ToList<TipoMatricula>();
                if (tipos.Count > 0)
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

        public string ConsultarNombreTipoMatricula(int idTipo)
        {
            try
            {
                var query = from c in entities.TipoMatricula
                            where c.idTipoMatricula == idTipo
                            select c;

                List<TipoMatricula> tipos = query.ToList<TipoMatricula>();
                foreach (TipoMatricula tipo in tipos)
                {
                    if (tipo.idTipoMatricula == idTipo)
                    {
                        return tipo.Descripcion;
                    }
                }

                return "No";


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IDtipoMatricula(string nombre)
        {
            try
            {
                var query = from t in entities.TipoMatricula
                            where t.Descripcion == nombre
                            select t;

                List<TipoMatricula> tipos = query.ToList<TipoMatricula>();
                
                foreach(TipoMatricula tipo in tipos)
                {
                    if (tipo.Descripcion.Equals(nombre))
                    {
                        return tipo.idTipoMatricula;
                    }
                }

                return 0;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CrearMatricula(Matriculas matricula)
        {
            try
            {
                entities.Matriculas.Add(matricula);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CrearLineaMatricula(LineasMatricula lineamatricula)
        {
            try
            {
                entities.LineasMatricula.Add(lineamatricula);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ObtenerIDMatricula(int idEstudiante, DateTime fecha)
        {
            try
            {
                var query = from c in entities.Matriculas
                            where c.idEstudiante == idEstudiante && c.Fecha == fecha
                            select c;

                List<Matriculas> matriculas = query.ToList<Matriculas>();
                foreach(Matriculas matricula in matriculas)
                {
                    if(matricula.idEstudiante.Equals(idEstudiante) && matricula.Fecha == fecha)
                    {
                        return matricula.idMatricula;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Matriculas> ObtenerMatriculas()
        {
            try
            {
                var query = from c in entities.Matriculas
                            select c;

                return query.ToList<Matriculas>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LineasMatricula> ObtenerLineaMatricula(int idMatricula)
        {
            try
            {
                var query = from c in entities.LineasMatricula
                            where c.idMatricula == idMatricula
                            select c;

                return query.ToList<LineasMatricula>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
