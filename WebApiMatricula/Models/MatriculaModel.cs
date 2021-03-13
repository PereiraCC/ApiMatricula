using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class MatriculaModel
    {
        private Usuario usuarios = new Usuario();


        public DateTime FechaMatricula { get; set; }

        public string Estudiante { get; set; }

        public string NombreCarrera { get; set; }

        public List<MateriasModelo> Materias { get; set; }

        public string Periodo { get; set; }

        public string TipoMatricula { get; set; }

        public List<string> obtenerMaterias(List<MateriasModelo> materias)
        {
            try
            {
                List<string> matricula = new List<string>();
                foreach (MateriasModelo materia in materias)
                {
                    matricula.Add(materia.NombreCurso + "," + materia.CodigoGrupo);
                }

                return matricula;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        public List<MateriasModelo> obtenerMaterias2(LineasMatricula lineas)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}