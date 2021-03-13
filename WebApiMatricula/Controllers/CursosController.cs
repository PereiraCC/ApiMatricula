using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Datos;
using Negocios.Clases;
using WebApiMatricula.Models;

namespace WebApiMatricula.Controllers
{
    public class CursosController : ApiController
    {
        private Courses db = new Courses();
        private Validaciones validaciones = new Validaciones();

        // GET: api/Cursos
        public List<CursosModel> GetCursos()
        {
            try
            {
                List<CursosModel> cursos = new List<CursosModel>();
                List<Cursos> data = db.obtenerCursos();
                foreach (Cursos curso in data)
                {
                    CursosModel temp = new CursosModel();
                    temp.Codigo = curso.Codigo;
                    temp.Nombre = curso.Nombre;
                    temp.NombreCarrera = temp.obtenerNombreCarrera(curso.idCarrera);

                    cursos.Add(temp);
                }

                return cursos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Cursos/5
        [ResponseType(typeof(Cursos))]
        public IHttpActionResult GetCursos(int id)
        {
            try
            {
                List<CursosModel> cursos = new List<CursosModel>();
                string resp = validaciones.validarcodigo(id.ToString());
             
                if (resp.Equals("1"))
                {
                    List<Cursos> data = db.obtenerCursosFiltrado(id);
                    if (data.Count > 0)
                    {
                        foreach (Cursos curso in data)
                        {
                            CursosModel temp = new CursosModel();
                            temp.Codigo = curso.Codigo;
                            temp.Nombre = curso.Nombre;
                            temp.NombreCarrera = temp.obtenerNombreCarrera(curso.idCarrera);

                            cursos.Add(temp);
                        }

                        return Ok(cursos);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    throw new Exception(resp);
                }
                
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Cursos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCursos(int id, CursosModel cursos)
        {
            try
            {
                string resp = validaciones.validarcodigo(id.ToString());
                if (resp.Equals("1"))
                {
                    resp = validaciones.validarDatosCurso(cursos.Codigo.ToString(), cursos.Nombre, cursos.NombreCarrera);
                    if (resp.Equals("1"))
                    {
                        resp = db.modificarCurso(id, cursos.Codigo, cursos.Nombre, cursos.NombreCarrera);
                        if (resp.Equals("1"))
                        {
                            return StatusCode(HttpStatusCode.NoContent);
                        }
                        else if (resp.Equals("No existe"))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw new Exception(resp);
                        }
                    }
                    else
                    {
                        throw new Exception(resp);
                    }
                }
                else
                {
                    throw new Exception(resp);
                }
                
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Cursos
        [ResponseType(typeof(Cursos))]
        public IHttpActionResult PostCursos(CursosModel cursos)
        {
            try
            {
                string data = validaciones.validarDatosCurso(cursos.Codigo.ToString(), cursos.Nombre, cursos.NombreCarrera);
                if (data.Equals("1"))
                {
                    data = db.CrearCurso(cursos.Codigo, cursos.Nombre, cursos.NombreCarrera);
                    if (data.Equals("1"))
                    {
                        return Created("DefaultApi", "Curso creado"); //201
                    }
                    else if (data.Equals("El curso ya esta registrado"))
                    {
                        return Conflict(); //404
                    }
                    else if (data.Equals("La carrera no existe"))
                    {
                        return NotFound(); //409
                    }
                    else
                    {
                        throw new Exception(data);
                    }
                }
                else
                {
                    throw new Exception(data);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Cursos/5
        [ResponseType(typeof(Cursos))]
        public IHttpActionResult DeleteCursos(int id)
        {
            try
            {
                string resp = validaciones.validarcodigo(id.ToString());

                if (resp.Equals("1"))
                {
                    resp = db.eliminarCurso(id);
                    if (resp.Equals("1"))
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }
                    else if (resp.Equals("El curso no esta registrado"))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw new Exception(resp);
                    }
                }
                else
                {
                    throw new Exception(resp);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}