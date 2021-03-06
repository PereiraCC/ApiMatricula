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
    public class MatriculaController : ApiController
    {
        private Enroll db = new Enroll();
        private Validaciones validaciones = new Validaciones();
        private MatriculaModel model = new MatriculaModel();

        // GET: api/Carreras
        public List<MatriculaModel> GetMatricula()
        {
            try
            {
                List<MatriculaModel> matriculas = new List<MatriculaModel>();
                List<Matriculas> data = db.obtenerMatriculas();
                foreach (Matriculas matri in data)
                {
                    MatriculaModel temp = new MatriculaModel();
                    temp.FechaMatricula = matri.Fecha;
                    temp.Estudiante = temp.obtenerCedulaEstudiante(matri.idEstudiante);
                    List<LineasMatricula> lineas = db.obtenerLineasMatriculas(matri.idMatricula);
                    temp.Materias = temp.obtenerMaterias2(lineas);
                    temp.NombreCarrera = temp.obtenerNombreCarrera(lineas);
                    temp.Periodo = temp.obtenerPeriodo(lineas);
                    temp.TipoMatricula = temp.obtenerTipoMatricula(matri.idTipoMatricula);
                    matriculas.Add(temp);
                }

                return matriculas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //// GET: api/Carreras/5
        //[ResponseType(typeof(Carreras))]
        //public IHttpActionResult GetCarreras(string id)
        //{
        //    try
        //    {
        //        List<CarrerasModel> carreras = new List<CarrerasModel>();
        //        List<Carreras> data = db.obtenerCarrerasFiltrado(id);
        //        string resp = validaciones.validarcodigo(id.ToString());

        //        if (resp.Equals("1"))
        //        {
        //            if (data.Count > 0)
        //            {
        //                foreach (Carreras carrera in data)
        //                {
        //                    CarrerasModel temp = new CarrerasModel();
        //                    temp.Codigo = carrera.Codigo;
        //                    temp.Nombre = carrera.Nombre;

        //                    carreras.Add(temp);
        //                }

        //                return Ok(carreras);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception(resp);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //// PUT: api/Carreras/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCarreras(string id, Carreras carreras)
        //{
        //    try
        //    {
        //        string resp = validaciones.validarcodigo(id);
        //        if (resp.Equals("1"))
        //        {
        //            resp = validaciones.validarDatosCarrera(carreras);
        //            if (resp.Equals("1"))
        //            {
        //                resp = db.modificarCarrera(id, carreras.Codigo, carreras.Nombre);
        //                if (resp.Equals("1"))
        //                {
        //                    return StatusCode(HttpStatusCode.NoContent);
        //                }
        //                else if (resp.Equals("No existe"))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw new Exception(resp);
        //                }
        //            }
        //            else
        //            {
        //                throw new Exception(resp);
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception(resp);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        // POST: api/Carreras

        [ResponseType(typeof(Carreras))]
        public IHttpActionResult PostMatricula(MatriculaModel matricula)
        {
            try
            {
                string data = validaciones.validarDatosMatricula(matricula.FechaMatricula, matricula.Estudiante, matricula.NombreCarrera, matricula.Periodo, matricula.TipoMatricula);
                if (data.Equals("1"))
                {
                    List<string> materias = model.obtenerMaterias(matricula.Materias);
                    data = validaciones.validarDatosMaterias(materias);
                    if (data.Equals("1"))
                    {
                        data = db.MatricularEstudiante(matricula.FechaMatricula, matricula.Estudiante, materias,  matricula.Periodo, matricula.TipoMatricula);
                        if (data.Equals("1"))
                        {
                            return Created("DefaultApi", "Matricula realizada"); //201
                        }
                        else if (data.Equals("La matricula ya esta registrada"))
                        {
                            return Conflict(); //404
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

        // DELETE: api/Carreras/5
        //[ResponseType(typeof(Carreras))]
        //public IHttpActionResult DeleteCarreras(string id)
        //{
        //    try
        //    {
        //        string resp = validaciones.validarcodigo(id.ToString());

        //        if (resp.Equals("1"))
        //        {
        //            resp = db.eliminarCarrera(id);
        //            if (resp.Equals("1"))
        //            {
        //                return StatusCode(HttpStatusCode.NoContent);
        //            }
        //            else if (resp.Equals("La carrera no esta registrada"))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw new Exception(resp);
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception(resp);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}