using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Clases
{
    public class Assistance
    {
        private Asistencia asistencia = new Asistencia();
        private Usuario usuario = new Usuario();
        private Grupo grupo = new Grupo();
        private Curso curso = new Curso();

        public string CrearAsistencia(string cedulaEstudiante, int numeroGrupo, int numeroCurso, string TipoAsistencia, DateTime Fecha)
        {
            try
            {
                if (usuario.ConsultarExisteEstudiante(cedulaEstudiante))
                {
                    int idEstudiante = usuario.IDUsuarioExistenteEstudiante(cedulaEstudiante);
                    if (curso.ConsultarExisteCurso(numeroCurso))
                    {
                        if (grupo.ConsultarExisteGrupo(numeroGrupo))
                        {
                            int idGrupo = grupo.IDGrupoExistente(numeroGrupo);
                            if (asistencia.ConsultarExisteTipoAsistencia(TipoAsistencia))
                            {
                                int idTipoAsistencia = asistencia.IDTipoAsistenciaExistente(TipoAsistencia);
                                if (asistencia.ConsultarExisteAsistencia(idEstudiante, idGrupo, Fecha, idTipoAsistencia) == false)
                                {
                                    int resp = asistencia.CrearAsistencia(new Asistencias()
                                    {
                                        idEstudiante = idEstudiante,
                                        idGrupo = idGrupo,
                                        fecha = Fecha,
                                        idTipoAsistencia = idTipoAsistencia,
                                    });

                                    if (resp == 1)
                                    {
                                        return "1";
                                    }
                                    else
                                    {
                                        return "Error al insertar una asistencia";
                                    }
                                }
                                else
                                {
                                    return "La asistencia ya esta registrado"; //404
                                }
                            }
                            else
                            {
                                return "Error el tipo de asistencia no existe"; //404
                            }
                        }
                        else
                        {
                            return "Error el grupo no existe";
                        }
                        
                    }
                    else
                    {
                        return "Error el curso no existe"; //404
                    }

                }
                else
                {
                    return "Error el estudiante no existe"; //409
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
