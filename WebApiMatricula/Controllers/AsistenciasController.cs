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
    public class AsistenciasController : ApiController
    {
        private Assistance db = new Assistance();
        private Validaciones validaciones = new Validaciones();

        // GET: api/Asistencias
        //public IQueryable<Asistencias> GetAsistencias()
        //{
        //    return db.Asistencias;
        //}

        // GET: api/Asistencias/5
        //[ResponseType(typeof(Asistencias))]
        //public IHttpActionResult GetAsistencias(int id)
        //{
        //    Asistencias asistencias = db.Asistencias.Find(id);
        //    if (asistencias == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(asistencias);
        //}

        // PUT: api/Asistencias/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutAsistencias(int id, Asistencias asistencias)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != asistencias.idAsistencia)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(asistencias).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AsistenciasExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Asistencias
        [ResponseType(typeof(Asistencias))]
        public IHttpActionResult PostAsistencias(AsistenciaModel asistencias)
        {
            try
            {
                string data = validaciones.validarDatosAsistencia(asistencias.FechaAsistencia, asistencias.Estudiante, asistencias.Grupo, asistencias.Curso, asistencias.TipoAsistencia);
                if (data.Equals("1"))
                {
                    data = db.CrearAsistencia(asistencias.Estudiante, Int32.Parse(asistencias.Grupo), Int32.Parse(asistencias.Curso), asistencias.TipoAsistencia, asistencias.FechaAsistencia);
                    if (data.Equals("1"))
                    {
                        return Created("DefaultApi", "Asistencia registrada"); //201
                    }
                    else if (data.Equals("La asistencia ya esta registrado"))
                    {
                        return Conflict(); //404
                    }
                    else if (data.Equals("Error el estudiante no existe") || data.Equals("Error el curso no existe")
                        || data.Equals("Error el grupo no existe") || data.Equals("Error el tipo de asistencia no existe"))
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

        // DELETE: api/Asistencias/5
        //[ResponseType(typeof(Asistencias))]
        //public IHttpActionResult DeleteAsistencias(int id)
        //{
        //    Asistencias asistencias = db.Asistencias.Find(id);
        //    if (asistencias == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Asistencias.Remove(asistencias);
        //    db.SaveChanges();

        //    return Ok(asistencias);
        //}

    }
}