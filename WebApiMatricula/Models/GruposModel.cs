using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class GruposModel
    {
        private Usuario usuario = new Usuario();
        private Curso curso = new Curso();
        private Horario horario = new Horario();
        private Periodo periodo = new Periodo();

        public string codigoProfesor { get; set; }

        public string Numero { get; set; }

        public string nombreCurso { get; set; }

        public string codigoHorario { get; set; }

        public string codigoPeriodo { get; set; }

        public string obtenerCedulaProfesor(int idProfesor)
        {
            try
            {
                string cedula = usuario.CedulaProfesor(idProfesor);
                if (!cedula.Equals("No"))
                {
                    return cedula;
                }
                else
                {
                    return "No existe";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerNombreCurso(int idCurso)
        {
            try
            {
                string nombreCurso = curso.obtenerNombreCurso(idCurso);
                if (!nombreCurso.Equals("No"))
                {
                    return nombreCurso;
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

        public string obtenerCodigoHorario(int idHorario)
        {
            try
            {
                string codigoHorario = horario.CodigoHorarioExistente(idHorario);
                if (!codigoHorario.Equals("No"))
                {
                    return codigoHorario;
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

        public string obtenerCodigoPeriodo(int idPeriodo)
        {
            try
            {
                string codigoPeriodo = periodo.CodigoPeriodoExistente(idPeriodo);
                if (!codigoPeriodo.Equals("No"))
                {
                    return codigoPeriodo;
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