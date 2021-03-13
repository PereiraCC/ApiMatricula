using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuario
    {
        private CatalogoEntities entities;

        public Usuario()
        {
            entities = new CatalogoEntities();
        }

        //validamos que exista un usuario
        public bool ConsultarExisteUsuario(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula
                            select c;

                List<Usuarios> usuario = query.ToList<Usuarios>();
                if(usuario.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool ConsultarExisteEstudiante(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula && c.idTipoUsuario == 2
                            select c;

                List<Usuarios> usuario = query.ToList<Usuarios>();
                if (usuario.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ConsultarExisteProfesor(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula && c.idTipoUsuario == 2
                            select c;

                List<Usuarios> usuario = query.ToList<Usuarios>();
                if (usuario.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IDUsuarioExistente(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula
                            select c;

                List<Usuarios> usuario = query.ToList<Usuarios>();
                foreach (Usuarios usu in usuario)
                {
                    if (usu.NumeroIdentificacion.Equals(cedula))
                    {
                        return usu.idUsuario;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IDUsuarioExistenteProfesor(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula && c.idTipoUsuario == 1
                            select c;

                List<Usuarios> usuario = query.ToList<Usuarios>();
                foreach (Usuarios usu in usuario)
                {
                    if (usu.NumeroIdentificacion.Equals(cedula))
                    {
                        return usu.idUsuario;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IDUsuarioExistenteEstudiante(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula && c.idTipoUsuario == 2
                            select c;

                List<Usuarios> usuario = query.ToList<Usuarios>();
                foreach (Usuarios usu in usuario)
                {
                    if (usu.NumeroIdentificacion.Equals(cedula))
                    {
                        return usu.idUsuario;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CedulaProfesor(int idProfesor)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.idUsuario == idProfesor && c.idTipoUsuario == 1
                            select c;

                List<Usuarios> usuario = query.ToList<Usuarios>();
                foreach (Usuarios usu in usuario)
                {
                    if (usu.idUsuario == idProfesor)
                    {
                        return usu.NumeroIdentificacion;
                    }
                }

                return "No";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CedulaEstudiante(int idEstudiante)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.idUsuario == idEstudiante && c.idTipoUsuario == 2
                            select c;

                List<Usuarios> usuario = query.ToList<Usuarios>();
                foreach (Usuarios usu in usuario)
                {
                    if (usu.idUsuario == idEstudiante)
                    {
                        return usu.NumeroIdentificacion;
                    }
                }

                return "No";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearUsuario(Usuarios usu)
        {
            try
            {
                entities.Usuarios.Add(usu);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CrearTelefono(Telefonos telefono)
        {
            try
            {
                entities.Telefonos.Add(telefono);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CrearEmails(Emails email)
        {
            try
            {
                entities.Emails.Add(email);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int TipoIdentificacion(string identificacion)
        {
            try
            {
                var query = from c in entities.TipoIdentificacion
                            where c.Descripcion == identificacion
                            select c;

                List<TipoIdentificacion> usuario = query.ToList<TipoIdentificacion>();

                foreach (TipoIdentificacion usu in usuario)
                {
                    if (usu.Descripcion.Equals(identificacion))
                    {
                        return usu.idTipoIdentificacion;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int BorrarUsuario(string cedula)
        {
            try
            {
                
                Usuarios usu = entities.Usuarios.First<Usuarios>(x => x.NumeroIdentificacion == cedula);
                entities.Usuarios.Remove(usu);
                return entities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarTelefonos(int idUsuario)
        {
            try
            {
                List<Telefonos> telefonos = entities.Telefonos.ToList<Telefonos>();
                foreach(Telefonos tel in telefonos)
                {
                    if (tel.idUsuario == idUsuario)
                    {
                        entities.Telefonos.Remove(tel);
                    }
                    
                }
                return entities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarEmails(int idUsuario)
        {
            try
            {
                List<Emails> emails = entities.Emails.ToList<Emails>();
                foreach (Emails email in emails)
                {
                    if (email.idUsuario == idUsuario)
                    {
                        entities.Emails.Remove(email);
                    }

                }
                return entities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarUsuario(string cedula, string nombre, string apellido, DateTime fecha)
        {
            try
            {
                Usuarios usu = entities.Usuarios.First<Usuarios>(x => x.NumeroIdentificacion == cedula);
                usu.Nombre = nombre;
                usu.Apellidos = apellido;
                usu.FechaNac = fecha;

                entities.Entry(usu).State = EntityState.Modified;

                return entities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ActualizarTelefonos(int idUsuario, string telefono, int consecutivo)
        {
            try
            {
                var query = from c in entities.Telefonos
                            where c.idUsuario == idUsuario && c.Consecutivo == consecutivo
                            select c;

                Telefonos tel = query.First<Telefonos>();
                tel.Telefono = telefono;

                entities.Entry(tel).State = EntityState.Modified;

                return entities.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarEmails(int idUsuario, string email, int consecutivo)
        {
            try
            {
                var query = from c in entities.Emails
                            where c.idUsuario == idUsuario && c.Consecutivo == consecutivo
                            select c;

                Emails ema = query.First<Emails>();
                ema.Email = email;

                entities.Entry(ema).State = EntityState.Modified;
                return entities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerUsuario()
        {
            try
            {
                return entities.Usuarios.ToList<Usuarios>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerProfesores()
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.idTipoUsuario == 1
                            select c;

                return query.ToList<Usuarios>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerEstudiantes()
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.idTipoUsuario == 2
                            select c;

                return query.ToList<Usuarios>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerUsuarioFiltrado(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula
                            select c;

                return query.ToList<Usuarios>();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerEstudianteFiltrado(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula && c.idTipoUsuario == 2
                            select c;

                return query.ToList<Usuarios>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerProfesorFiltrado(string cedula)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.NumeroIdentificacion == cedula && c.idTipoUsuario == 1
                            select c;

                return query.ToList<Usuarios>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int obtenercantidadTelefonos(int idusuario)
        {
            try
            {
                var query = from c in entities.Telefonos
                            where c.idUsuario == idusuario
                            select c;
                return query.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Telefonos> obtenerTelefonos(int idusuario)
        {
            try
            {
                var query = from c in entities.Telefonos
                            where c.idUsuario == idusuario
                            select c;
                return query.ToList<Telefonos>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Emails> obtenerEmails(int idusuario)
        {
            try
            {
                var query = from c in entities.Emails
                            where c.idUsuario == idusuario
                            select c;
                return query.ToList<Emails>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> ObtenerProfesores()
        {
            try {

                var query = from temp in entities.Usuarios
                            where temp.idTipoUsuario == 1
                            select temp;
                return query.ToList<Usuarios>();

            
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        


    }
}
