using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class MatriculaModel
    {
        private Usuario usuarios = new Usuario();
        private Grupo grupos = new Grupo();
        private Curso cursos = new Curso();
        private Periodo periodo = new Periodo();
        private Matricula matricula = new Matricula();
        private Carrera carrera = new Carrera();


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

        public List<MateriasModelo> obtenerMaterias2(List<LineasMatricula> lineas)
        {
            try
            {
                List<MateriasModelo> materias = new List<MateriasModelo>();
                foreach (LineasMatricula lineaM in lineas)
                {
                    string[] temp = obtenerDataGrupo(lineaM.idGrupo).Split(',');
                    MateriasModelo tempM = new MateriasModelo()
                    {
                        CodigoGrupo = temp[0],
                        NombreCurso = temp[1]
                    };
                    materias.Add(tempM);
                }

                return materias;
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

        public string obtenerPeriodo(List<LineasMatricula> lineas)
        {
            try
            {
                string data = string.Empty;
                foreach (LineasMatricula lineaM in lineas)
                {
                    Grupos gr = grupos.obtenerGrupo(lineaM.idGrupo);
                    data = periodo.CodigoPeriodoExistente(gr.idPeriodo);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerNombreCarrera(List<LineasMatricula> lineas)
        {
            try
            {
                string data = string.Empty;
                foreach (LineasMatricula lineaM in lineas)
                {
                    Grupos gr = grupos.obtenerGrupo(lineaM.idGrupo);
                    Cursos cur = cursos.obtenerCurso(gr.idCurso);
                    data = carrera.obtenerNombreCarrera(cur.idCarrera);

                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerTipoMatricula(int idTipoMatricula)
        {
            try
            {
                return matricula.ConsultarNombreTipoMatricula(idTipoMatricula);
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


    }
}