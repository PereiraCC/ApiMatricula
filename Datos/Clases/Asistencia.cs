using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Asistencia
    {
        private CatalogoEntities entities;

        public Asistencia()
        {
            entities = new CatalogoEntities();
        }

        public bool ConsultarExisteAsistencia(int idEstudiante, int idGrupo, DateTime Fecha, int tipoA)
        {
            try
            {
                var query = from c in entities.Asistencias
                            where c.idEstudiante == idEstudiante && c.idGrupo == idGrupo
                                && c.fecha == Fecha && c.idTipoAsistencia == tipoA
                            select c;

                List<Asistencias> asistencias = query.ToList<Asistencias>();
                if (asistencias.Count > 0)
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

        public bool ConsultarExisteAsistencia(int idEstudiante, DateTime Fecha)
        {
            try
            {
                var query = from c in entities.Asistencias
                            where c.idEstudiante == idEstudiante && c.fecha == Fecha
                            select c;

                List<Asistencias> asistencias = query.ToList<Asistencias>();
                if (asistencias.Count > 0)
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

        public bool ConsultarExisteTipoAsistencia(string nombreAsistencia)
        {
            try
            {
                var query = from c in entities.TiposAsistencia
                            where c.Descripcion == nombreAsistencia
                            select c;

                List<TiposAsistencia> TipoAsistencias = query.ToList<TiposAsistencia>();
                if (TipoAsistencias.Count > 0)
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

        public int IDAsistenciaExistente(int idEstudiante)
        {
            try
            {
                var query = from c in entities.Asistencias
                            where c.idEstudiante == idEstudiante
                            select c;

                List<Asistencias> asistencias = query.ToList<Asistencias>();
                foreach (Asistencias asistencia in asistencias)
                {
                    if (asistencia.idEstudiante == idEstudiante)
                    {
                        return asistencia.idAsistencia;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IDTipoAsistenciaExistente(string nombreAsistencia)
        {
            try
            {
                var query = from c in entities.TiposAsistencia
                            where c.Descripcion == nombreAsistencia
                            select c;

                List<TiposAsistencia> asistencias = query.ToList<TiposAsistencia>();
                foreach (TiposAsistencia asistencia in asistencias)
                {
                    if (asistencia.Descripcion == nombreAsistencia)
                    {
                        return asistencia.idTipoAsistencia;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearAsistencia(Asistencias asistencia)
        {
            try
            {
                entities.Asistencias.Add(asistencia);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarAsistencia(int idAsistencia, int idGrupo,int idTipoAsistencia)
        {
            try
            {
                Asistencias asistencia = entities.Asistencias.First<Asistencias>(x => x.idAsistencia == idAsistencia);
                asistencia.idGrupo = idGrupo;
                asistencia.idTipoAsistencia = idTipoAsistencia;

                entities.Entry(asistencia).State = EntityState.Modified;

                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Asistencias> obtenerAsistencias()
        {
            try
            {
                return entities.Asistencias.ToList<Asistencias>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConsultarNombreTipoAsistencia(int idTipoAsistencia)
        {
            try
            {
                string nombre = string.Empty;
                var query = from c in entities.TiposAsistencia
                            where c.idTipoAsistencia == idTipoAsistencia
                            select c;

                List<TiposAsistencia> TipoAsistencias = query.ToList<TiposAsistencia>();
                foreach(TiposAsistencia asistencia in TipoAsistencias)
                {
                    if(asistencia.idTipoAsistencia == idTipoAsistencia)
                    {
                        nombre = asistencia.Descripcion;
                    }
                }
                return nombre;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
