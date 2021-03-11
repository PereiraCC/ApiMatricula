using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocios
{
    public class Users
    {
        private Usuario usuario = new Usuario();

        public string CrearUsuario(string cedula, int tipoIdentificacion, int tipoUsuario, string nombre, string apellidos, DateTime fecha)
        {
            try
            {
                if(usuario.ConsultarExisteUsuario(cedula) == false)
                {
                    int resp = usuario.CrearUsuario(new Usuarios()
                    {
                        NumeroIdentificacion = cedula,
                        idTipoIdentificacion = tipoIdentificacion,
                        idTipoUsuario = tipoUsuario,
                        Nombre = nombre,
                        Apellidos = apellidos,
                        FechaNac = fecha,
                    });

                    if(resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al insertar un usuario"; //404
                    }
                }
                else
                {
                    return "El usuario ya esta registrado"; //409
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string CrearTelefonos(List<Telefonos> telefonos, string cedula)
        {
            try
            {
                if (usuario.ConsultarExisteUsuario(cedula))
                {
                    int contador = 0;
                    int resp;
                    int idUsuario = usuario.IDUsuarioExistente(cedula);
                    foreach (Telefonos data in telefonos)
                    {
                        resp = usuario.CrearTelefono(new Telefonos()
                        {
                            idUsuario = idUsuario,
                            Telefono = data.Telefono,
                            Consecutivo = contador++,
                        });
                    }

                    return "1";
                }
                else
                {
                    return "El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CrearEmails(List<Emails> emails, string cedula)
        {
            try
            {
                if (usuario.ConsultarExisteUsuario(cedula))
                {
                    int contador = 0;
                    int resp;
                    int idUsuario = usuario.IDUsuarioExistente(cedula);
                    foreach (Emails data in emails)
                    {
                        resp = usuario.CrearEmails(new Emails()
                        {
                            idUsuario = idUsuario,
                            Email = data.Email,
                            Consecutivo = contador++,
                        });
                    }

                    return "1";
                }
                else
                {
                    return "El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerUsuarios()
        {
            try
            {
                List<Usuarios> usuarios = new List<Usuarios>();
                List<Usuarios> data =  usuario.obtenerUsuario();
                foreach(Usuarios user in data)
                {
                    Usuarios temp = new Usuarios();
                    temp.NumeroIdentificacion = user.NumeroIdentificacion;
                    temp.TipoIdentificacion = user.TipoIdentificacion;
                    temp.TipoUsuario = user.TipoUsuario;
                    temp.Nombre = user.Nombre;
                    temp.Apellidos = user.Apellidos;
                    temp.FechaNac = user.FechaNac;
                    temp.Telefonos = user.Telefonos;
                    temp.Emails = user.Emails;

                    usuarios.Add(temp);
                }

                return usuarios;
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
                List<Usuarios> usuarios = new List<Usuarios>();
                List<Usuarios> data = usuario.obtenerProfesores();
                foreach (Usuarios user in data)
                {
                    Usuarios temp = new Usuarios();
                    temp.NumeroIdentificacion = user.NumeroIdentificacion;
                    temp.TipoIdentificacion = user.TipoIdentificacion;
                    temp.TipoUsuario = user.TipoUsuario;
                    temp.Nombre = user.Nombre;
                    temp.Apellidos = user.Apellidos;
                    temp.FechaNac = user.FechaNac;
                    temp.Telefonos = user.Telefonos;
                    temp.Emails = user.Emails;

                    usuarios.Add(temp);
                }

                return usuarios;
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
                List<Usuarios> usuarios = new List<Usuarios>();
                List<Usuarios> data = usuario.obtenerEstudiantes();
                foreach (Usuarios user in data)
                {
                    Usuarios temp = new Usuarios();
                    temp.NumeroIdentificacion = user.NumeroIdentificacion;
                    temp.TipoIdentificacion = user.TipoIdentificacion;
                    temp.TipoUsuario = user.TipoUsuario;
                    temp.Nombre = user.Nombre;
                    temp.Apellidos = user.Apellidos;
                    temp.FechaNac = user.FechaNac;
                    temp.Telefonos = user.Telefonos;
                    temp.Emails = user.Emails;

                    usuarios.Add(temp);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerUnUsuario(string cedula)
        {
            try
            {
                List<Usuarios> usuarios = new List<Usuarios>();
                List<Usuarios> data = usuario.obtenerUsuarioFiltrado(cedula);
                foreach (Usuarios user in data)
                {
                    Usuarios temp = new Usuarios();
                    temp.NumeroIdentificacion = user.NumeroIdentificacion;
                    temp.TipoIdentificacion = user.TipoIdentificacion;
                    temp.TipoUsuario = user.TipoUsuario;
                    temp.Nombre = user.Nombre;
                    temp.Apellidos = user.Apellidos;
                    temp.FechaNac = user.FechaNac;
                    temp.Telefonos = user.Telefonos;
                    temp.Emails = user.Emails;

                    usuarios.Add(user);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerUnEstudiante(string cedula)
        {
            try
            {
                List<Usuarios> usuarios = new List<Usuarios>();
                List<Usuarios> data = usuario.obtenerEstudianteFiltrado(cedula);
                foreach (Usuarios user in data)
                {
                    Usuarios temp = new Usuarios();
                    temp.NumeroIdentificacion = user.NumeroIdentificacion;
                    temp.TipoIdentificacion = user.TipoIdentificacion;
                    temp.TipoUsuario = user.TipoUsuario;
                    temp.Nombre = user.Nombre;
                    temp.Apellidos = user.Apellidos;
                    temp.FechaNac = user.FechaNac;
                    temp.Telefonos = user.Telefonos;
                    temp.Emails = user.Emails;

                    usuarios.Add(user);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> obtenerUnProfesor(string cedula)
        {
            try
            {
                List<Usuarios> usuarios = new List<Usuarios>();
                List<Usuarios> data = usuario.obtenerProfesorFiltrado(cedula);
                foreach (Usuarios user in data)
                {
                    Usuarios temp = new Usuarios();
                    temp.NumeroIdentificacion = user.NumeroIdentificacion;
                    temp.TipoIdentificacion = user.TipoIdentificacion;
                    temp.TipoUsuario = user.TipoUsuario;
                    temp.Nombre = user.Nombre;
                    temp.Apellidos = user.Apellidos;
                    temp.FechaNac = user.FechaNac;
                    temp.Telefonos = user.Telefonos;
                    temp.Emails = user.Emails;

                    usuarios.Add(user);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarUsuario(string cedula)
        {
            try
            {
                if (usuario.ConsultarExisteUsuario(cedula))
                {
                    int idUsuario = usuario.IDUsuarioExistente(cedula);
                    int resp = usuario.EliminarTelefonos(idUsuario);
                    if(resp > 0)
                    {
                        resp = usuario.EliminarEmails(idUsuario);
                        if(resp > 0)
                        {
                            resp = usuario.BorrarUsuario(cedula);
                            if(resp == 1)
                            {
                                return "1";
                            }
                            else
                            {
                                return "Error al momento de eliminar el usuario";
                            }
                        }
                        else
                        {
                            return "Error al momento de eliminar correos electronicos.";
                        }
                    }
                    else
                    {
                        return "Error al momento de eliminar telefonos.";
                    }
                }
                else
                {
                    return "El usuario no esta registrado"; //404
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string modificarUsuario(string idUsu, string cedula, string nombre, string apellidos, DateTime fecha)
        {
            try
            {
                if (usuario.ConsultarExisteUsuario(idUsu))
                {
                    int resp = usuario.ActualizarUsuario(cedula, nombre, apellidos, fecha);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de modificar el usuario";
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

        public string modificarTelefonos(string cedula, List<Telefonos> telefono)
        {
            try
            {
                if (usuario.ConsultarExisteUsuario(cedula))
                {
                    int idUsuario = usuario.IDUsuarioExistente(cedula);
                    bool band = false;
                    int consecutivo = 0;
                    if(InsertarNuevosTelefonos(usuario.obtenerTelefonos(idUsuario), telefono, idUsuario))
                    {
                        foreach (Telefonos tel in telefono)
                        {
                            int resp = usuario.ActualizarTelefonos(idUsuario, tel.Telefono, consecutivo);
                            if (resp != 1)
                            {
                                band = true;
                                break;
                            }
                            consecutivo++;
                        }

                        if (band == false)
                        {
                            return "1";
                        }
                        else
                        {
                            return "Error al momento de modificar los telefonos.";
                        }
                    }
                    else
                    {
                        foreach (Telefonos tel in telefono)
                        {
                            int resp = usuario.ActualizarTelefonos(idUsuario, tel.Telefono, consecutivo);
                            if (resp != 1)
                            {
                                band = true;
                                break;
                            }
                            consecutivo++;
                        }

                        if (band == false)
                        {
                            return "1";
                        }
                        else
                        {
                            return "Error al momento de modificar los telefonos.";
                        }
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

        public bool InsertarNuevosTelefonos(List<Telefonos> viejo, List<Telefonos> nuevo, int idUsuario)
        {
            try
            {
                if (viejo.Count == nuevo.Count)
                {
                    return false;
                }
                else
                {
                    int consecutivo = viejo.Count - 1;
                    int temp = 0;
                    int resp = 0;
                    bool band = false;
                    foreach (Telefonos tem in nuevo)
                    {
                        if (consecutivo < temp)
                        {
                            //aqui seria crear los nuevos telefonos
                            // consecutivo que vas agregar a la BD temp
                            resp = usuario.CrearTelefono(new Telefonos()
                            {
                                idUsuario = idUsuario,
                                Telefono = tem.Telefono,
                                Consecutivo = temp,
                            });

                            if (resp != 1)
                            {
                                band = true;
                                break;
                            }
                        }
                        temp++;
                    }
                    if (band == false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public string modificarEmails(string cedula, List<Emails> emails)
        {
            try
            {
                if (usuario.ConsultarExisteUsuario(cedula))
                {
                    int idUsuario = usuario.IDUsuarioExistente(cedula);
                    int consecutivo = 0;
                    bool band = false;
                    if (InsertarNuevosEmails(usuario.obtenerEmails(idUsuario), emails, idUsuario))
                    {
                        foreach (Emails ema in emails)
                        {
                            int resp = usuario.ActualizarEmails(idUsuario, ema.Email, consecutivo);
                            if (resp != 1)
                            {
                                band = true;
                                break;
                            }
                            consecutivo++;
                        }

                        if (band == false)
                        {
                            return "1";
                        }
                        else
                        {
                            return "Error al momento de modificar los emails";
                        }
                    }
                    else
                    {
                        foreach (Emails ema in emails)
                        {
                            int resp = usuario.ActualizarEmails(idUsuario, ema.Email, consecutivo);
                            if (resp != 1)
                            {
                                band = true;
                                break;
                            }
                            consecutivo++;
                        }

                        if (band == false)
                        {
                            return "1";
                        }
                        else
                        {
                            return "Error al momento de modificar los emails";
                        }
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

        public bool InsertarNuevosEmails(List<Emails> viejo, List<Emails> nuevo, int idUsuario)
        {
            try
            {
                if (viejo.Count == nuevo.Count)
                {
                    return false;
                }
                else
                {
                    int consecutivo = viejo.Count - 1;
                    int temp = 0;
                    int resp = 0;
                    bool band = false;
                    foreach (Emails tem in nuevo)
                    {
                        if (consecutivo < temp)
                        {
                            //aqui seria crear los nuevos telefonos
                            // consecutivo que vas agregar a la BD temp
                            resp = usuario.CrearEmails(new Emails()
                            {
                                idUsuario = idUsuario,
                                Email = tem.Email,
                                Consecutivo = temp,
                            });

                            if (resp != 1)
                            {
                                band = true;
                                break;
                            }
                        }
                        temp++;
                    }
                    if (band == false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
