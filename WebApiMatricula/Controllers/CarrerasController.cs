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
    public class CarrerasController : ApiController
    {
        private Careers db = new Careers();
        private Validaciones validaciones = new Validaciones();

        // GET: api/Carreras
        public List<CarrerasModel> GetCarreras()
        {
            try
            {
                List<CarrerasModel> carreras = new List<CarrerasModel>();
                List<Carreras> data = db.obtenerCarrera();
                foreach (Carreras carrera in data)
                {
                    CarrerasModel temp = new CarrerasModel();
                    temp.Codigo = carrera.Codigo;
                    temp.Nombre = carrera.Nombre;

                    carreras.Add(temp);
                }

                return carreras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Carreras/5
        [ResponseType(typeof(Carreras))]
        public IHttpActionResult GetCarreras(string id)
        {
            try
            {
                List<CarrerasModel> carreras = new List<CarrerasModel>();
                List<Carreras> data = db.obtenerCarrerasFiltrado(id);
                string resp = validaciones.validarcodigo(id.ToString());

                if (resp.Equals("1"))
                {
                    if (data.Count > 0)
                    {
                        foreach (Carreras carrera in data)
                        {
                            CarrerasModel temp = new CarrerasModel();
                            temp.Codigo = carrera.Codigo;
                            temp.Nombre = carrera.Nombre;

                            carreras.Add(temp);
                        }

                        return Ok(carreras);
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

        // PUT: api/Carreras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarreras(string id, Carreras carreras)
        {
            try
            {
                string resp = validaciones.validarcodigo(id);
                if (resp.Equals("1"))
                {
                    resp = validaciones.validarDatosCarrera(carreras);
                    if (resp.Equals("1"))
                    {
                        resp = db.modificarCarrera(id, carreras.Codigo, carreras.Nombre);
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
                return InternalServerError(ex);
            }
        }

        // POST: api/Carreras
        [ResponseType(typeof(Carreras))]
        public IHttpActionResult PostCarreras(Carreras carreras)
        {
            try
            {
                string data = validaciones.validarDatosCarrera(carreras);
                if (data.Equals("1"))
                {
                    data = db.CrearCarrera(carreras.Codigo, carreras.Nombre);
                    if (data.Equals("1"))
                    {
                        return Created("DefaultApi", "Carrera creada"); //201
                    }
                    else if (data.Equals("El carrera ya esta registrado"))
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

                return InternalServerError(ex);
            }
        }

        // DELETE: api/Carreras/5
        [ResponseType(typeof(Carreras))]
        public IHttpActionResult DeleteCarreras(string id)
        {
            try
            {
                string resp = validaciones.validarcodigo(id.ToString());

                if (resp.Equals("1"))
                {
                    resp = db.eliminarCarrera(id);
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