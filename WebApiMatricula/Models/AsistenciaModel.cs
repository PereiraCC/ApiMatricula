using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class AsistenciaModel
    {
        private Usuario usuarios = new Usuario();
        private Grupo grupos = new Grupo();
        private Curso cursos = new Curso();
        private Asistencia asistencia = new Asistencia();

        public DateTime FechaAsistencia { get; set; }

        public string Estudiante { get; set; }

        public string Grupo { get; set; }

        public string Curso { get; set; }

        public string TipoAsistencia { get; set; }

        public string obtenerCedulaEstudiante(int idEstudiante)
        {
            try
            {
                return usuarios.CedulaEstudiante(idEstudiante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerDataGrupo(int idGrupo)
        {
            try
            {
                Grupos gr = grupos.obtenerGrupo(idGrupo);
                return gr.Numero.ToString() + "," + obtenerNombreCurso(gr.idCurso);
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
                return cursos.obtenerNombreCurso(idCurso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerNombreTipoAsistencia(int idAsistencia)
        {
            try
            {
                return asistencia.ConsultarNombreTipoAsistencia(idAsistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}