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
    public class GruposController : ApiController
    {
        private Groups db = new Groups();
        private Validaciones validaciones = new Validaciones();
        private GruposModel gm = new GruposModel();

        // GET: api/Grupos
        public List<GruposModel> GetGrupos()
        {
            try
            {
                List<GruposModel> grupos = new List<GruposModel>();
                List<Grupos> data = db.obtenerGrupos();
                foreach (Grupos grupo in data)
                {
                    GruposModel temp = new GruposModel();
                    temp.codigoProfesor = gm.obtenerCedulaProfesor(grupo.idProfesor);
                    temp.Numero = grupo.Numero.ToString();
                    temp.nombreCurso = gm.obtenerNombreCurso(grupo.idCurso);
                    temp.codigoHorario = gm.obtenerCodigoHorario(grupo.idHorario);
                    temp.codigoPeriodo = gm.obtenerCodigoPeriodo(grupo.idPeriodo);

                    grupos.Add(temp);
                }

                return grupos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Grupos/5
        [ResponseType(typeof(Grupos))]
        public IHttpActionResult GetGrupos(int id)
        {
            try
            {
                List<GruposModel> grupos = new List<GruposModel>();
                List<Grupos> data = db.obtenerGruposFiltrado(id);
                string resp = validaciones.validarcodigo(id.ToString());

                if (resp.Equals("1"))
                {
                    if (data.Count > 0)
                    {
                        foreach (Grupos grupo in data)
                        {
                            GruposModel temp = new GruposModel();
                            temp.codigoProfesor = gm.obtenerCedulaProfesor(grupo.idProfesor);
                            temp.Numero = grupo.Numero.ToString();
                            temp.nombreCurso = gm.obtenerNombreCurso(grupo.idCurso);
                            temp.codigoHorario = gm.obtenerCodigoHorario(grupo.idHorario);
                            temp.codigoPeriodo = gm.obtenerCodigoPeriodo(grupo.idPeriodo);

                            grupos.Add(temp);
                        }

                        return Ok(grupos);
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
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ResponseType(typeof(Grupos))]
        [Route("api/Grupos/GruposPeriodo", Name = "GetGruposPeriodo")]
        public IHttpActionResult GetGruposPeriodo(string id)
        {
            try
            {
                List<GruposModel> grupos = new List<GruposModel>();
                string resp = validaciones.validarcodigoPeriodo(id);

                if (resp.Equals("1"))
                {
                    List<Grupos> data = db.obtenerGruposPeriodo(id);
                    if (data.Count > 0)
                    {
                        foreach (Grupos grupo in data)
                        {
                            GruposModel temp = new GruposModel();
                            temp.codigoProfesor = gm.obtenerCedulaProfesor(grupo.idProfesor);
                            temp.Numero = grupo.Numero.ToString();
                            temp.nombreCurso = gm.obtenerNombreCurso(grupo.idCurso);
                            temp.codigoHorario = gm.obtenerCodigoHorario(grupo.idHorario);
                            temp.codigoPeriodo = gm.obtenerCodigoPeriodo(grupo.idPeriodo);

                            grupos.Add(temp);
                        }

                        return Ok(grupos);
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
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ResponseType(typeof(Grupos))]
        [Route("api/Grupos/GruposProfesor", Name = "GetGruposProfesor")]
        public IHttpActionResult GetGruposProfesor(string id)
        {
            try
            {
                List<GruposModel> grupos = new List<GruposModel>();
                string resp = validaciones.validarcodigo(id);

                if (resp.Equals("1"))
                {
                    List<Grupos> data = db.obtenerGruposProfesor(id);
                    if (data.Count > 0)
                    {
                        foreach (Grupos grupo in data)
                        {
                            GruposModel temp = new GruposModel();
                            temp.codigoProfesor = gm.obtenerCedulaProfesor(grupo.idProfesor);
                            temp.Numero = grupo.Numero.ToString();
                            temp.nombreCurso = gm.obtenerNombreCurso(grupo.idCurso);
                            temp.codigoHorario = gm.obtenerCodigoHorario(grupo.idHorario);
                            temp.codigoPeriodo = gm.obtenerCodigoPeriodo(grupo.idPeriodo);

                            grupos.Add(temp);
                        }

                        return Ok(grupos);
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
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ResponseType(typeof(Grupos))]
        [Route("api/Grupos/GruposCurso", Name = "GetGruposCurso")]
        public IHttpActionResult GetGruposCurso(string id)
        {
            try
            {
                List<GruposModel> grupos = new List<GruposModel>();
                string resp = validaciones.validarNombreCurso(id);

                if (resp.Equals("1"))
                {
                    List<Grupos> data = db.obtenerGruposCurso(id);
                    if (data.Count > 0)
                    {
                        foreach (Grupos grupo in data)
                        {
                            GruposModel temp = new GruposModel();
                            temp.codigoProfesor = gm.obtenerCedulaProfesor(grupo.idProfesor);
                            temp.Numero = grupo.Numero.ToString();
                            temp.nombreCurso = gm.obtenerNombreCurso(grupo.idCurso);
                            temp.codigoHorario = gm.obtenerCodigoHorario(grupo.idHorario);
                            temp.codigoPeriodo = gm.obtenerCodigoPeriodo(grupo.idPeriodo);

                            grupos.Add(temp);
                        }

                        return Ok(grupos);
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
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Grupos/5
        //[ResponseType(typeof(void))]
        public IHttpActionResult PutGrupos(string id, GruposModel grupos)
        {
            try
            {
                string resp = validaciones.validarcodigo(id);
                if (resp.Equals("1"))
                {
                    resp = validaciones.validarDatosGrupo(grupos.codigoProfesor, grupos.Numero, grupos.nombreCurso, grupos.codigoHorario,  grupos.codigoPeriodo);
                    if (resp.Equals("1"))
                    {
                        resp = db.modificarGrupo(Int32.Parse(id), grupos.codigoProfesor, grupos.Numero, grupos.nombreCurso, grupos.codigoHorario, grupos.codigoPeriodo);
                        if (resp.Equals("1"))
                        {
                            return StatusCode(HttpStatusCode.NoContent);
                        }
                        else if (resp.Equals("No existe"))
                        {
                            return NotFound();
                        }
                        else if (resp.Equals("Error el profesor no existe") || resp.Equals("Error el curso no existe")
                                    || resp.Equals("Error el horario no existe") || resp.Equals("Error el periodo no existe"))
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
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Grupos
        [ResponseType(typeof(Grupos))]
        public IHttpActionResult PostGrupos(GruposModel grupos)
        {
            try
            {
                string data = validaciones.validarDatosGrupo(grupos.codigoProfesor, grupos.Numero, grupos.nombreCurso, grupos.codigoHorario,  grupos.codigoPeriodo);
                if (data.Equals("1"))
                {
                    data = db.CrearGrupo(grupos.codigoProfesor, grupos.Numero, grupos.nombreCurso, grupos.codigoHorario, grupos.codigoPeriodo);
                    if (data.Equals("1"))
                    {
                        return Created("DefaultApi", "Grupo creado"); //201
                    }
                    else if (data.Equals("El grupo ya esta registrado"))
                    {
                        return Conflict(); //404
                    }
                    else if(data.Equals("Error el profesor no existe")|| data.Equals("Error el curso no existe") 
                        || data.Equals("Error el horario no existe") || data.Equals("Error el periodo no existe"))
                    {
                        return NotFound();
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

        // DELETE: api/Grupos/5
        [ResponseType(typeof(Grupos))]
        public IHttpActionResult DeleteGrupos(int id)
        {
            try
            {
                string resp = validaciones.validarcodigo(id.ToString());

                if (resp.Equals("1"))
                {
                    resp = db.eliminarGrupo(id);
                    if (resp.Equals("1"))
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }
                    else if (resp.Equals("La carrera no esta registrada"))
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