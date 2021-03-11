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
    public class HorariosController : ApiController
    {
        private Schedule db = new Schedule();
        private Validaciones validaciones = new Validaciones();

        // GET: api/Horarios
        public List<HorarioModel> GetHorarios()
        {
            try
            {
                List<HorarioModel> horarios = new List<HorarioModel>();
                List<Horarios> data = db.obtenerHorarios();
                foreach (Horarios horario in data)
                {
                    HorarioModel temp = new HorarioModel();
                    temp.Codigo = horario.Codigo;
                    temp.Dia = horario.dia;
                    temp.HoraInicio = horario.HoraInicio;
                    temp.HoraFinal = horario.HoraFinal;

                    horarios.Add(temp);
                }

                return horarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Horarios/5
        [ResponseType(typeof(Horarios))]
        public IHttpActionResult GetHorarios(string id)
        {
            try
            {
                List<HorarioModel> horarios = new List<HorarioModel>();
                
                string resp = validaciones.validarnombreCurso(id);

                if (resp.Equals("1"))
                {
                    List<Horarios> data = db.obtenerHorarioFiltrado(id);
                    if (data.Count > 0)
                    {
                        foreach (Horarios horario in data)
                        {
                            HorarioModel temp = new HorarioModel();
                            temp.Codigo = horario.Codigo;
                            temp.Dia = horario.dia;
                            temp.HoraInicio = horario.HoraInicio;
                            temp.HoraFinal = horario.HoraFinal;

                            horarios.Add(temp);
                        }

                        return Ok(horarios);
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

        // PUT: api/Horarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHorarios(int id, Horarios horarios)
        {
            try
            {
                string resp = validaciones.validarcodigo(id.ToString());
                if (resp.Equals("1"))
                {
                    resp = validaciones.validarDatosHorarios(horarios);
                    if (resp.Equals("1"))
                    {
                        resp = db.modificarHorario(id, horarios.Codigo, horarios.dia, horarios.HoraInicio, horarios.HoraFinal);
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

        // POST: api/Horarios
        [ResponseType(typeof(Horarios))]
        public IHttpActionResult PostHorarios(Horarios horarios)
        {
            try
            {
                string data = validaciones.validarDatosHorarios(horarios);
                if (data.Equals("1"))
                {
                    data = db.CrearHorario(horarios.Codigo,  horarios.dia, horarios.HoraInicio, horarios.HoraFinal);
                    if (data.Equals("1"))
                    {
                        return Created("DefaultApi", "Horario creado"); //201
                    }
                    else if (data.Equals("El horario ya esta registrado"))
                    {
                        return Conflict(); //404
                    }
                    else if (data.Equals("El grupo no existe"))
                    {
                        return NotFound(); //404
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

        // DELETE: api/Horarios/5
        [ResponseType(typeof(Horarios))]
        public IHttpActionResult DeleteHorarios(int id)
        {
            try
            {
                string resp = validaciones.validarcodigo(id.ToString());

                if (resp.Equals("1"))
                {
                    resp = db.eliminarHorario(id);
                    if (resp.Equals("1"))
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }
                    else if (resp.Equals("El horario no esta registrado"))
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