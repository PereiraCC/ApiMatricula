using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Grupo
    {
        private CatalogoEntities entities;

        public Grupo()
        {
            entities = new CatalogoEntities();
        }

        public bool ConsultarExisteGrupo(int numero)
        {
            try
            {
                var query = from c in entities.Grupos
                            where c.Numero == numero
                            select c;

                List<Grupos> periodo = query.ToList<Grupos>();
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

        public int IDGrupoExistente(int numero)
        {
            try
            {
                var query = from c in entities.Grupos
                            where c.Numero == numero
                            select c;

                List<Grupos> grupos = query.ToList<Grupos>();
                foreach (Grupos grupo in grupos)
                {
                    if (grupo.Numero == numero)
                    {
                        return grupo.idGrupo;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearGrupo(Grupos grupo)
        {
            try
            {
                entities.Grupos.Add(grupo);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarGrupo(int idGrupo)
        {
            try
            {
                Grupos grupo = entities.Grupos.First<Grupos>(x => x.idGrupo == idGrupo);
                entities.Grupos.Remove(grupo);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarGrupo(int idGrupo, int idProfesor, int numero, int idCurso, int idHorario, int idPeriodo)
        {
            try
            {
                Grupos grupo = entities.Grupos.First<Grupos>(x => x.idGrupo == idGrupo);
                grupo.idProfesor = idProfesor;
                grupo.Numero = numero;
                grupo.idCurso = idCurso;
                grupo.idHorario = idHorario;
                grupo.idPeriodo = idPeriodo;

                entities.Entry(grupo).State = EntityState.Modified;

                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupos> obtenerGrupos()
        {
            try
            {
                return entities.Grupos.ToList<Grupos>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupos> obtenerGruposFiltrado(int numero)
        {
            try
            {
                var query = from c in entities.Grupos
                            where c.Numero == numero
                            select c;

                return query.ToList<Grupos>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupos> obtenerGruposPeriodo(int idPeriodo)
        {
            try
            {
                var query = from c in entities.Grupos
                            where c.idPeriodo == idPeriodo
                            select c;

                return query.ToList<Grupos>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupos> obtenerGruposProfesor(int idProfesor)
        {
            try
            {
                var query = from c in entities.Grupos
                            where c.idProfesor == idProfesor
                            select c;

                return query.ToList<Grupos>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupos> obtenerGruposCurso(int idCurso)
        {
            try
            {
                var query = from c in entities.Grupos
                            where c.idCurso == idCurso
                            select c;

                return query.ToList<Grupos>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Grupos obtenerGrupo(int idGrupo)
        {
            try
            {
                Grupos gr = new Grupos();
                var query = from c in entities.Grupos
                            where c.idGrupo == idGrupo
                            select c;

                List<Grupos> grupos = query.ToList<Grupos>();
                foreach (Grupos grupo in grupos)
                {
                    if (grupo.idGrupo == idGrupo)
                    {
                        gr = grupo;
                    }
                }

                return gr;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
