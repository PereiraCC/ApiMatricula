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
using Negocios;
using Negocios.Clases;
using WebApiMatricula.Models;

namespace WebApiMatricula.Controllers
{
    public class UsuariosController : ApiController
    {
        //private CatalogoEntities db = new CatalogoEntities();
        private Users db = new Users();
        private Validaciones validaciones = new Validaciones();

        //GET: api/Usuarios
        [ResponseType(typeof(Usuarios))]
        public List<UsuarioModel> GetUsuarios()
        {
            TelefonoModel telm = new TelefonoModel();
            EmailModel emailm = new EmailModel();
            List<UsuarioModel> usuarios = new List<UsuarioModel>();
            List<Usuarios> data = db.obtenerUsuarios();
            foreach (Usuarios user in data)
            {
                UsuarioModel temp = new UsuarioModel();
                temp.NumeroIdentificacion = user.NumeroIdentificacion;
                temp.TipoIdentificacion = user.TipoIdentificacion.Descripcion;
                temp.TipoUsuario = user.TipoUsuario.Descripcion;
                temp.Nombre = user.Nombre;
                temp.Apellidos = user.Apellidos;
                temp.FechaNac = user.FechaNac;
                temp.Telefonos = telm.obtenerTelefonos(user.Telefonos.ToList());
                temp.Emails = emailm.obtenerEmails(user.Emails.ToList());

                usuarios.Add(temp);
            }

            return usuarios;
        }

        //GET: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult GetUsuarios(string id)
        {
            try
            {
                TelefonoModel telm = new TelefonoModel();
                EmailModel emailm = new EmailModel();
                List<UsuarioModel> usuarios = new List<UsuarioModel>();
                string resp = validaciones.validarcodigo(id);

                if (resp.Equals("1"))
                {
                    List<Usuarios> data = db.obtenerUnUsuario(id);
                    if(data.Count > 0)
                    {
                        foreach (Usuarios user in data)
                        {
                            UsuarioModel temp = new UsuarioModel();
                            temp.NumeroIdentificacion = user.NumeroIdentificacion;
                            temp.TipoIdentificacion = user.TipoIdentificacion.Descripcion;
                            temp.TipoUsuario = user.TipoUsuario.Descripcion;
                            temp.Nombre = user.Nombre;
                            temp.Apellidos = user.Apellidos;
                            temp.FechaNac = user.FechaNac;
                            temp.Telefonos = telm.obtenerTelefonos(user.Telefonos.ToList());
                            temp.Emails = emailm.obtenerEmails(user.Emails.ToList());

                            usuarios.Add(temp);
                        }

                        return Ok(usuarios);
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

        [ResponseType(typeof(Usuarios))]
        [Route("api/Usuarios/Estudiantes", Name = "GetEstudiantes")]
        public List<UsuarioModel> GetEstudiantes()
        {
            try
            {
                TelefonoModel telm = new TelefonoModel();
                EmailModel emailm = new EmailModel();
                List<UsuarioModel> usuarios = new List<UsuarioModel>();
                List<Usuarios> data = db.obtenerEstudiantes();
                foreach (Usuarios user in data)
                {
                    UsuarioModel temp = new UsuarioModel();
                    temp.NumeroIdentificacion = user.NumeroIdentificacion;
                    temp.TipoIdentificacion = user.TipoIdentificacion.Descripcion;
                    temp.TipoUsuario = user.TipoUsuario.Descripcion;
                    temp.Nombre = user.Nombre;
                    temp.Apellidos = user.Apellidos;
                    temp.FechaNac = user.FechaNac;
                    temp.Telefonos = telm.obtenerTelefonos(user.Telefonos.ToList());
                    temp.Emails = emailm.obtenerEmails(user.Emails.ToList());

                    usuarios.Add(temp);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ResponseType(typeof(Usuarios))]
        [Route("api/Usuarios/UnEstudiante", Name = "GetUnEstudiante")]
        public IHttpActionResult GetUnEstudiante(string id)
        {
            try
            {
                TelefonoModel telm = new TelefonoModel();
                EmailModel emailm = new EmailModel();
                List<UsuarioModel> usuarios = new List<UsuarioModel>();
                string resp = validaciones.validarcodigo(id);

                if (resp.Equals("1"))
                {
                    List<Usuarios> data = db.obtenerUnEstudiante(id);
                    if (data.Count > 0)
                    {
                        foreach (Usuarios user in data)
                        {
                            UsuarioModel temp = new UsuarioModel();
                            temp.NumeroIdentificacion = user.NumeroIdentificacion;
                            temp.TipoIdentificacion = user.TipoIdentificacion.Descripcion;
                            temp.TipoUsuario = user.TipoUsuario.Descripcion;
                            temp.Nombre = user.Nombre;
                            temp.Apellidos = user.Apellidos;
                            temp.FechaNac = user.FechaNac;
                            temp.Telefonos = telm.obtenerTelefonos(user.Telefonos.ToList());
                            temp.Emails = emailm.obtenerEmails(user.Emails.ToList());

                            usuarios.Add(temp);
                        }

                        return Ok(usuarios);
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

        [ResponseType(typeof(Usuarios))]
        [Route("api/Usuarios/Profesores", Name = "GetProfesores")]
        public List<UsuarioModel> GetProfesores()
        {
            try
            {
                TelefonoModel telm = new TelefonoModel();
                EmailModel emailm = new EmailModel();
                List<UsuarioModel> usuarios = new List<UsuarioModel>();
                List<Usuarios> data = db.obtenerProfesores();
                foreach (Usuarios user in data)
                {
                    UsuarioModel temp = new UsuarioModel();
                    temp.NumeroIdentificacion = user.NumeroIdentificacion;
                    temp.TipoIdentificacion = user.TipoIdentificacion.Descripcion;
                    temp.TipoUsuario = user.TipoUsuario.Descripcion;
                    temp.Nombre = user.Nombre;
                    temp.Apellidos = user.Apellidos;
                    temp.FechaNac = user.FechaNac;
                    temp.Telefonos = telm.obtenerTelefonos(user.Telefonos.ToList());
                    temp.Emails = emailm.obtenerEmails(user.Emails.ToList());

                    usuarios.Add(temp);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ResponseType(typeof(Usuarios))]
        [Route("api/Usuarios/UnProfesor", Name = "GetUnProfesor")]
        public IHttpActionResult GetUnProfesor(string id)
        {
            try
            {
                TelefonoModel telm = new TelefonoModel();
                EmailModel emailm = new EmailModel();
                List<UsuarioModel> usuarios = new List<UsuarioModel>();
                string resp = validaciones.validarcodigo(id);

                if (resp.Equals("1"))
                {
                    List<Usuarios> data = db.obtenerUnProfesor(id);
                    if (data.Count > 0)
                    {
                        foreach (Usuarios user in data)
                        {
                            UsuarioModel temp = new UsuarioModel();
                            temp.NumeroIdentificacion = user.NumeroIdentificacion;
                            temp.TipoIdentificacion = user.TipoIdentificacion.Descripcion;
                            temp.TipoUsuario = user.TipoUsuario.Descripcion;
                            temp.Nombre = user.Nombre;
                            temp.Apellidos = user.Apellidos;
                            temp.FechaNac = user.FechaNac;
                            temp.Telefonos = telm.obtenerTelefonos(user.Telefonos.ToList());
                            temp.Emails = emailm.obtenerEmails(user.Emails.ToList());

                            usuarios.Add(temp);
                        }

                        return Ok(usuarios);
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

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
         public IHttpActionResult PutUsuarios(string id, Usuarios usuarios)
         {
            try
            {
                string data = validaciones.validarDatosUsuario(usuarios);

                if (data.Equals("1"))
                {
                    data = db.modificarUsuario(id, usuarios.NumeroIdentificacion, usuarios.Nombre, usuarios.Apellidos, usuarios.FechaNac);
                    if (data.Equals("1"))
                    {
                        data = db.modificarTelefonos(usuarios.NumeroIdentificacion, usuarios.Telefonos.ToList());
                        if (data.Equals("1"))
                        {
                            data = db.modificarEmails(usuarios.NumeroIdentificacion, usuarios.Emails.ToList());
                            if (data.Equals("1"))
                            {
                                return StatusCode(HttpStatusCode.NoContent);
                            }
                            else if (data.Equals("No existe"))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw new Exception(data);
                            }
                        }
                        else if (data.Equals("No existe"))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw new Exception(data);
                        }
                    }
                    else if(data.Equals("No existe"))
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
                throw ex;
            }
        }

        // POST: api/Usuarios
        public IHttpActionResult PostUsuarios(Usuarios usuarios)
        {
            try
            {
                string data = validaciones.validarDatosUsuario(usuarios);
                if (data.Equals("1"))
                {
                    data = db.CrearUsuario(usuarios.NumeroIdentificacion, usuarios.idTipoIdentificacion, usuarios.idTipoUsuario, usuarios.Nombre, usuarios.Apellidos, usuarios.FechaNac);

                    if (data.Equals("1"))
                    {
                        data = db.CrearTelefonos(usuarios.Telefonos.ToList(), usuarios.NumeroIdentificacion);
                        if (data.Equals("1"))
                        {
                            data = db.CrearEmails(usuarios.Emails.ToList(), usuarios.NumeroIdentificacion);
                            if (data.Equals("1"))
                            {
                                return Created("DefaultApi", "Usuario creado"); //201
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
                    else if (data.Equals("El usuario ya esta registrado"))
                    {
                        return Conflict(); //409
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

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult DeleteUsuarios(string id)
        {
            try
            {
                TelefonoModel telm = new TelefonoModel();
                EmailModel emailm = new EmailModel();
                string resp = validaciones.validarcodigo(id);

                if (resp.Equals("1"))
                {
                    resp = db.eliminarUsuario(id);
                    if (resp.Equals("1"))
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }
                    else if(resp.Equals("El usuario no esta registrado"))
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}