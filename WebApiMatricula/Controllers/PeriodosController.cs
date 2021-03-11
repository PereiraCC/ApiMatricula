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
    public class PeriodosController : ApiController
    {
        private Periods db = new Periods();
        private Validaciones validaciones = new Validaciones();

        // GET: api/Periodos
        public List<PeriodosModel> GetPeriodos()
        {
            try
            {
                List<PeriodosModel> periodos = new List<PeriodosModel>();
                List<Periodos> data = db.obtenerPeriodo();
                foreach (Periodos periodo in data)
                {
                    PeriodosModel temp = new PeriodosModel();
                    temp.Numero = periodo.Numero;
                    temp.FechaInicial = periodo.FechaInicio;
                    temp.FechaFinal = periodo.FechaFinal;
                    temp.activo = periodo.activo;

                    periodos.Add(temp);
                }

                return periodos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Periodos/5
        [ResponseType(typeof(Periodos))]
        public IHttpActionResult GetPeriodos(string id)
        {
            try
            {
                List<PeriodosModel> periodos = new List<PeriodosModel>();
                List<Periodos> data = db.obtenerPeriodosFiltrado(id);
                string resp = validaciones.validarcodigoPeriodo(id);

                if (resp.Equals("1"))
                {
                    if (data.Count > 0)
                    {
                        foreach (Periodos periodo in data)
                        {
                            PeriodosModel temp = new PeriodosModel();
                            temp.Numero = periodo.Numero;
                            temp.FechaInicial = periodo.FechaInicio;
                            temp.FechaFinal = periodo.FechaFinal;
                            temp.activo = periodo.activo;

                            periodos.Add(temp);
                        }

                        return Ok(periodos);
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
                throw ex;
            }
        }

        // PUT: api/Periodos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPeriodos(string id, Periodos periodos)
        {
            try
            {
                string resp = validaciones.validarcodigoPeriodo(id);
                if (resp.Equals("1"))
                {
                    resp = validaciones.validarDatosPeriodo(periodos);
                    if (resp.Equals("1"))
                    {
                        resp = db.modificarPeriodos(id,periodos.Numero, periodos.FechaInicio, periodos.FechaFinal, periodos.activo);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Periodos
        [ResponseType(typeof(Periodos))]
        public IHttpActionResult PostPeriodos(Periodos periodos)
        {
            try
            {
                string data = validaciones.validarDatosPeriodo(periodos);
                if (data.Equals("1"))
                {
                    data = db.CrearPeriodo(periodos.Numero, periodos.FechaInicio, periodos.FechaFinal, periodos.activo);
                    if (data.Equals("1"))
                    {
                        return Created("DefaultApi", "Periodo creado"); //201
                    }
                    else if (data.Equals("El periodo ya esta registrado"))
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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/Periodos/5
        [ResponseType(typeof(Periodos))]
        public IHttpActionResult DeletePeriodos(string id)
        {
            try
            {
                string resp = validaciones.validarcodigoPeriodo(id);

                if (resp.Equals("1"))
                {
                    resp = db.eliminarPeriodo(id);
                    if (resp.Equals("1"))
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }
                    else if (resp.Equals("El periodo no esta registrado"))
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
                throw ex;
            }
        }

    }
}