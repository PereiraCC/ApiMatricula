using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Horario
    {
        private CatalogoEntities entities;

        public Horario()
        {
            entities = new CatalogoEntities();
        }

        public bool ConsultarExisteHorario(int codigo)
        {
            try
            {
                var query = from c in entities.Horarios
                            where c.Codigo == codigo
                            select c;

                List<Horarios> horarios = query.ToList<Horarios>();
                if (horarios.Count > 0)
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

        public int IDHorarioExistente(int codigo)
        {
            try
            {
                var query = from c in entities.Horarios
                            where c.Codigo == codigo
                            select c;

                List<Horarios> horarios = query.ToList<Horarios>();
                foreach (Horarios horario in horarios)
                {
                    if (horario.Codigo == codigo)
                    {
                        return horario.idHorario;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CodigoHorarioExistente(int idHorario)
        {
            try
            {
                var query = from c in entities.Horarios
                            where c.idHorario == idHorario
                            select c;

                List<Horarios> horarios = query.ToList<Horarios>();
                foreach (Horarios horario in horarios)
                {
                    if (horario.idHorario == idHorario)
                    {
                        return horario.Codigo.ToString();
                    }
                }

                return "No";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearHorario(Horarios horario)
        {
            try
            {
                entities.Horarios.Add(horario);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarHorario(int idHorario)
        {
            try
            {
                Horarios horario = entities.Horarios.First<Horarios>(x => x.idHorario == idHorario);
                entities.Horarios.Remove(horario);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarHorario(int idHorario, int codigo, string dia, TimeSpan HoraInicio, TimeSpan HoraFinal)
        {
            try
            {
                Horarios horario = entities.Horarios.First<Horarios>(x => x.idHorario == idHorario);
                horario.Codigo = codigo;
                horario.dia = dia;
                horario.HoraInicio = HoraInicio;
                horario.HoraFinal = HoraFinal;

                entities.Entry(horario).State = EntityState.Modified;

                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Horarios> obtenerHorarios()
        {
            try
            {
                return entities.Horarios.ToList<Horarios>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Obtiene horario por grupo
        public List<Horarios> obtenerHorariosFiltrado(int idCurso)
        {
            try
            {
                var query = from g in entities.Grupos
                            join h in entities.Horarios
                            on g.idHorario equals h.idHorario
                            join r in entities.Cursos on g.idCurso equals r.idCurso
                            where r.idCurso == idCurso
                            select h;

                return query.ToList<Horarios>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public List<Horarios> ObtenerHorariosIdCurso(int curso, int grupo)
        {
            var query = from temp in entities.Horarios
                        join gr in entities.Grupos on temp.idHorario equals gr.idHorario
                        where gr.idGrupo == grupo && gr.idCurso == curso
                        select temp;

            return query.ToList<Horarios>();
                        
        }
        
    }
}
