using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Clases
{
    public class Courses
    {
        private Curso curso = new Curso();

        public string CrearCurso(int codigo, string nombre, int idCarrera)
        {
            try
            {
                if (curso.ConsultarExisteCurso(codigo) == false)
                {
                    if (curso.ConsultarExisteCarrera(idCarrera))
                    {
                        int resp = curso.CrearCurso(new Cursos()
                        {
                            Codigo = codigo,
                            Nombre = nombre,
                            idCarrera = idCarrera,
                        });

                        if (resp == 1)
                        {
                            return "1";
                        }
                        else
                        {
                            return "Error al insertar una carrera"; //404
                        }
                    }
                    else
                    {
                        return "La carrera no existe"; //409
                    }
                }
                else
                {
                    return "El curso ya esta registrado"; //409
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cursos> obtenerCursos()
        {
            try
            {
                List<Cursos> cursos = new List<Cursos>();
                List<Cursos> data = curso.obtenerCursos();
                foreach (Cursos curso in data)
                {
                    Cursos temp = new Cursos();
                    temp.Codigo = curso.Codigo;
                    temp.Nombre = curso.Nombre;
                    temp.idCarrera = curso.idCarrera;

                    cursos.Add(temp);
                }

                return cursos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cursos> obtenerCursosFiltrado(int idCarrera)
        {
            try
            {
                List<Cursos> cursos = new List<Cursos>();
                List<Cursos> data = curso.obtenerCursoFiltrado(idCarrera);
                foreach (Cursos curso in data)
                {
                    Cursos temp = new Cursos();
                    temp.Codigo = curso.Codigo;
                    temp.Nombre = curso.Nombre;
                    temp.idCarrera = curso.idCarrera;

                    cursos.Add(temp);
                }

                return cursos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarCurso(int codigo)
        {
            try
            {
                if (curso.ConsultarExisteCurso(codigo))
                {
                    int idCurso = curso.IDCursoExistente(codigo);
                    int resp = curso.EliminarCurso(idCurso);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de eliminar curso.";
                    }
                }
                else
                {
                    return "El curso no esta registrado"; //404
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarUsuario(int id, int codigo, string nombre, int idCarrera)
        {
            try
            {
                if (curso.ConsultarExisteCurso(id))
                {
                    int resp = curso.ActualizarCurso(codigo, nombre, idCarrera);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de modificar el curso";
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
