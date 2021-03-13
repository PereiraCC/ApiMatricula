using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Clases;

namespace Negocios.Clases
{
   public class Enroll
    {
        private Horario horario = new Horario();
        private Curso curso = new Curso();
        private Grupo grupo = new Grupo();
        private Periodo periodos = new Periodo();
        private Usuario usuario = new Usuario();
        private Matricula matricula = new Matricula();
        private Carrera carreras = new Carrera();

        public string MatricularEstudiante(DateTime fecha, string estudiante, List<string> materias, string periodo, string tipo)
        {
            try
            {
                if (usuario.ConsultarExisteEstudiante(estudiante))
                {
                    int idEstudiante = usuario.IDUsuarioExistenteEstudiante(estudiante);
                    if (matricula.ConsultarExisteMatricular(idEstudiante, fecha) == false)
                    {
                        if (matricula.ConsultarExisteTipoMatricular(tipo))
                        {
                            int idTipoMatricula = matricula.IDtipoMatricula(tipo);
                            if (matricula.PeriodoActivo(periodo))
                            {
                                int resp = matricula.CrearMatricula(new Matriculas()
                                {
                                    idEstudiante = idEstudiante,
                                    idTipoMatricula = idTipoMatricula,
                                    Fecha = fecha,
                                });

                                if (resp == 1)
                                {
                                    int idMatricula = matricula.ObtenerIDMatricula(idEstudiante, fecha);
                                    if(idMatricula != 0)
                                    {
                                        foreach(string data in materias)
                                        {
                                            string[] temp = data.Split(',');
                                            if (curso.ConsultarExisteCurso(temp[0]))
                                            {
                                                if (grupo.ConsultarExisteGrupo(Int32.Parse(temp[1])))
                                                {
                                                    int idGrupo = grupo.IDGrupoExistente(Int32.Parse(temp[1]));
                                                    resp = matricula.CrearLineaMatricula(new LineasMatricula()
                                                    {
                                                        idMatricula = idMatricula,
                                                        idGrupo = idGrupo,
                                                    });
                                                }
                                                else
                                                {
                                                    return "Error algun de los grupos no existe.";
                                                }
                                            }
                                            else
                                            {
                                                return "Error algun de los cursos no existe.";
                                            }
                                        }

                                        return "1";
                                    }
                                    else
                                    {
                                        return "Error en el proceso de matricula";
                                    }
                                }
                                else
                                {
                                    return "Error en el proceso de matricula";
                                }
                            }
                            else
                            {
                                return "Error el perido no es valido para matricular";
                            }
                        }
                        else
                        {
                            return "Error el Tipo de matricula no existe";
                        }
                    }
                    else
                    {
                        return "La matricula ya esta registrada"; //404
                    }
                }
                else
                {
                    return "Error el estudainte no existe"; //404
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

        public List<Matriculas> obtenerMatriculas()
        {
            try
            {
                return matricula.ObtenerMatriculas();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<LineasMatricula> obtenerLineasMatriculas(int idMatricula)
        {
            try
            {
                return matricula.ObtenerLineaMatricula(idMatricula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
