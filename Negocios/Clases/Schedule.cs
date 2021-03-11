using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Clases
{
    public class Schedule
    {
        private Horario horario = new Horario();
        private Curso curso = new Curso();

        public string CrearHorario(int codigo,  string dia, TimeSpan HoraInicio, TimeSpan HoraFinal)
        {
            try
            {
                if (horario.ConsultarExisteHorario(codigo) == false)
                {
                    int resp = horario.CrearHorario(new Horarios()
                    {
                        Codigo = codigo,
                        dia = dia,
                        HoraInicio = HoraInicio,
                        HoraFinal = HoraFinal
                    });

                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al insertar un horario"; //404
                    }
                }
                else
                {
                    return "El horario ya esta registrado"; //409
                }
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
                return horario.obtenerHorarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Horarios> obtenerHorarioFiltrado(string nombreCurso)
        {
            try
            {
                List<Horarios> horarios = new List<Horarios>();
                if (curso.ConsultarExisteCurso(nombreCurso))
                {
                    int idCurso = curso.IDCursoExistente(nombreCurso);
                    List<Horarios> data = horario.obtenerHorariosFiltrado(idCurso);
                    foreach (Horarios horario in data)
                    {
                        Horarios temp = new Horarios();
                        temp.Codigo = horario.Codigo;
                        temp.dia = horario.dia;
                        temp.HoraInicio = horario.HoraInicio;
                        temp.HoraFinal = horario.HoraFinal;

                        horarios.Add(temp);
                    }                    
                }

                return horarios;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarHorario(int codigo)
        {
            try
            {
                if (horario.ConsultarExisteHorario(codigo))
                {
                    int idHorario = horario.IDHorarioExistente(codigo);
                    int resp = horario.EliminarHorario(idHorario);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de eliminar horario.";
                    }
                }
                else
                {
                    return "El horario no esta registrado"; //404
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarHorario(int codigoActual, int codigo, string dia, TimeSpan HoraInicio, TimeSpan HoraFinal)
        {
            try
            {
                if (horario.ConsultarExisteHorario(codigoActual))
                {
                    int idHorario = horario.IDHorarioExistente(codigoActual);

                    int resp = horario.ActualizarHorario(idHorario, codigo, dia, HoraInicio, HoraFinal);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de modificar el horario";
                    }
                }
                else
                {
                    return "No existe";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
