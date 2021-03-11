using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Clases
{
    public class Groups
    {
        private Grupo grupo = new Grupo();
        private Usuario usuario = new Usuario();
        private Curso curso = new Curso();
        private Horario horario = new Horario();
        private Periodo periodo = new Periodo();

        public string CrearGrupo(string cedulaProfesor, string numero, string nombreCurso, string codigoHorario, string codigoPeriodo)
        {
            try
            {
                if (grupo.ConsultarExisteGrupo(Int32.Parse(numero)) == false)
                {
                    if (usuario.ConsultarExisteUsuario(cedulaProfesor))
                    {
                        int idProfesor = usuario.IDUsuarioExistenteProfesor(cedulaProfesor);
                        if (curso.ConsultarExisteCurso(nombreCurso))
                        {
                            int idCurso = curso.IDCursoExistente(nombreCurso);
                            if (horario.ConsultarExisteHorario(Int32.Parse(codigoHorario)))
                            {
                                int idHorario = horario.IDHorarioExistente(Int32.Parse(codigoHorario));
                                if (periodo.ConsultarExistePeriodo(codigoPeriodo))
                                {
                                    int idPeriodo = periodo.IDPeriodoExistente(codigoPeriodo);
                                    int resp = grupo.CrearGrupo(new Grupos()
                                    {
                                        idProfesor = idProfesor,
                                        Numero = Int32.Parse(numero),
                                        idCurso = idCurso,
                                        idHorario = idHorario,
                                        idPeriodo = idPeriodo,
                                    });

                                    if (resp == 1)
                                    {
                                        return "1";
                                    }
                                    else
                                    {
                                        return "Error al insertar un grupo";
                                    }
                                }
                                else
                                {
                                    return "Error el periodo no existe"; //404
                                }
                            }
                            else
                            {
                                return "Error el horario no existe"; //404
                            } 
                        }
                        else
                        {
                            return "Error el curso no existe"; //404
                        }  
                    }
                    else
                    {
                        return "Error el profesor no existe"; //404
                    }
                    
                }
                else
                {
                    return "El grupo ya esta registrado"; //409
                }
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
                return grupo.obtenerGrupos();
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
                List<Grupos> grupos = new List<Grupos>();
                List<Grupos> data = grupo.obtenerGruposFiltrado(numero);
                foreach (Grupos grupo in data)
                {
                    Grupos temp = new Grupos();
                    temp.idProfesor = grupo.idProfesor;
                    temp.Numero = grupo.Numero;
                    temp.idCurso = grupo.idCurso;
                    temp.idHorario = grupo.idHorario;
                    temp.idPeriodo = grupo.idPeriodo;

                    grupos.Add(temp);
                }

                return grupos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupos> obtenerGruposPeriodo(string numeroPeriodo)
        {
            try
            {
                List<Grupos> grupos = new List<Grupos>();
                int idPeriodo = periodo.IDPeriodoExistente(numeroPeriodo);
                if(idPeriodo != 0)
                {
                    List<Grupos> data = grupo.obtenerGruposPeriodo(idPeriodo);
                    foreach (Grupos grupo in data)
                    {
                        Grupos temp = new Grupos();
                        temp.idProfesor = grupo.idProfesor;
                        temp.Numero = grupo.Numero;
                        temp.idCurso = grupo.idCurso;
                        temp.idHorario = grupo.idHorario;
                        temp.idPeriodo = grupo.idPeriodo;

                        grupos.Add(temp);
                    }    
                }
                
                return grupos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupos> obtenerGruposProfesor(string cedula)
        {
            try
            {
                List<Grupos> grupos = new List<Grupos>();
                int idProfesor = usuario.IDUsuarioExistente(cedula);
                if (idProfesor != 0)
                {
                    List<Grupos> data = grupo.obtenerGruposProfesor(idProfesor);
                    foreach (Grupos grupo in data)
                    {
                        Grupos temp = new Grupos();
                        temp.idProfesor = grupo.idProfesor;
                        temp.Numero = grupo.Numero;
                        temp.idCurso = grupo.idCurso;
                        temp.idHorario = grupo.idHorario;
                        temp.idPeriodo = grupo.idPeriodo;

                        grupos.Add(temp);
                    }
                }

                return grupos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupos> obtenerGruposCurso(string nombreCurso)
        {
            try
            {
                List<Grupos> grupos = new List<Grupos>();
                int idCurso = curso.IDCursoExistente(nombreCurso);
                if (idCurso != 0)
                {
                    List<Grupos> data = grupo.obtenerGruposCurso(idCurso);
                    foreach (Grupos grupo in data)
                    {
                        Grupos temp = new Grupos();
                        temp.idProfesor = grupo.idProfesor;
                        temp.Numero = grupo.Numero;
                        temp.idCurso = grupo.idCurso;
                        temp.idHorario = grupo.idHorario;
                        temp.idPeriodo = grupo.idPeriodo;

                        grupos.Add(temp);
                    }
                }

                return grupos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarGrupo(int numero)
        {
            try
            {
                if (grupo.ConsultarExisteGrupo(numero))
                {
                    int idGrupo = grupo.IDGrupoExistente(numero);
                    int resp = grupo.EliminarGrupo(idGrupo);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de eliminar grupo.";
                    }
                }
                else
                {
                    return "La grupo no esta registrado"; //404
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarGrupo(int numeroActual, string cedulaProfesor, string numero, string nombreCurso, string codigoHorario, string codigoPeriodo)
        {
            try
            {
                if (grupo.ConsultarExisteGrupo(numeroActual))
                {
                    if (usuario.ConsultarExisteUsuario(cedulaProfesor))
                    {
                        int idProfesor = usuario.IDUsuarioExistenteProfesor(cedulaProfesor);
                        if (curso.ConsultarExisteCurso(nombreCurso))
                        {
                            int idCurso = curso.IDCursoExistente(nombreCurso);
                            if (horario.ConsultarExisteHorario(Int32.Parse(codigoHorario)))
                            {
                                int idHorario = horario.IDHorarioExistente(Int32.Parse(codigoHorario));
                                if (periodo.ConsultarExistePeriodo(codigoPeriodo))
                                {
                                    int idPeriodo = periodo.IDPeriodoExistente(codigoPeriodo);
                                    int idGrupo = grupo.IDGrupoExistente(numeroActual);
                                    int resp = grupo.ActualizarGrupo(idGrupo, idProfesor, Int32.Parse(numero), idCurso, idHorario, idPeriodo);
                                    if (resp == 1)
                                    {
                                        return "1";
                                    }
                                    else
                                    {
                                        return "Error al momento de modificar el grupo";
                                    }
                                }
                                else
                                {
                                    return "Error el periodo no existe"; //404
                                }
                            }
                            else
                            {
                                return "Error el horario no existe";
                            }

                        }
                        else
                        {
                            return "Error el curso no existe"; //404
                        }
                    }
                    else
                    {
                        return "Error el profesor no existe"; //404
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
