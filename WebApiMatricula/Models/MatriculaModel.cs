using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class MatriculaModel
    {
        public DateTime FechaMatricula { get; set; }

        public string Estudiante { get; set; }

        public string Carrera { get; set; }

        public List<MateriasModelo> Materias { get; set; }

        public string Periodo { get; set; }

        public string TipoMatricula { get; set; }

        public List<string> obtenerMatriculas(List<MateriasModelo> materias)
        {
            try
            {
                List<string> matricula = new List<string>();
                foreach (MateriasModelo materia in materias)
                {
                    matricula.Add(materia.Curso + "," + materia.Grupo);
                }

                return matricula;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}