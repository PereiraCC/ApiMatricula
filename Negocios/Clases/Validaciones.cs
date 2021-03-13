using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocios.Clases
{
    public class Validaciones
    {
        public string validarcodigo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return "El id esta vacio";
                }
                else if (!validarNumero(id))
                {
                    return "El id no debe contener letras";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarnombreCurso(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    return "El nombre esta vacio";
                }
                else if (!validarTexto(nombre))
                {
                    return "El nombre no debe contener numeros";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarNombreCurso(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return "El id esta vacio";
                }
                else if (!validarTexto(id))
                {
                    return "El nombre del curso no debe contener numeros";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarcodigoPeriodo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return "El id esta vacio";
                }
                else if (!validarCaracteresEspeciales(id))
                {
                    return "El id no debe contener caracteres especiales";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosUsuario(Usuarios usuario)
        {
            try
            {
                if (vacioTexto(usuario.NumeroIdentificacion) || vacioTexto(usuario.Nombre)
                        || vacioTexto(usuario.Apellidos) || usuario.FechaNac == default(DateTime)
                        || usuario.idTipoIdentificacion == 0 || usuario.idTipoUsuario == 0
                        || usuario.Telefonos.Count == 0 || usuario.Emails.Count == 0
                        || validarVacioListaTelefonos(usuario.Telefonos.ToList()) || validarVacioListaEmails(usuario.Emails.ToList()))
                {
                    return "El datos estan incompletos";
                }
                else if (validarKeyWords(usuario.NumeroIdentificacion) || validarKeyWords(usuario.Nombre)
                        || validarKeyWords(usuario.Apellidos) || usuario.FechaNac == default(DateTime)
                        || validarKeyWords(usuario.idTipoIdentificacion.ToString()) || validarKeyWords(usuario.idTipoUsuario.ToString())
                        || validarKeyWordsListaTelefonos(usuario.Telefonos.ToList()) ||validarKeyWordsListaEmails(usuario.Emails.ToList()))
                {
                    return "Los datos son invalidos";
                }
                else if (!validarNumero(usuario.NumeroIdentificacion))
                {
                    return "El numero de identificacion deben contener solo numeros";
                }
                else if (!validarTexto(usuario.Nombre) || !validarTexto(usuario.Apellidos))
                {
                    return "El nombre y los apellidos deben contener solo letras";
                }
                else if (validarListaTelefonos(usuario.Telefonos.ToList()))
                {
                    return "Los telefonos tiene un formato invalido.";
                }
                else if (!validarListaEmails(usuario.Emails.ToList()))
                {
                    return "Los correo tiene un formato invalido.";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosCurso(string codigo, string curso, string carrera)
        {
            try
            {
                if (vacioTexto(codigo) || vacioTexto(curso) || vacioTexto(carrera))
                {
                    return "El datos estan incompletos";
                }
                else if (validarKeyWords(codigo)|| validarKeyWords(curso) || validarKeyWords(carrera))
                {
                    return "El datos son invalidos";
                }
                else if (!validarNumero(codigo))
                {
                    return "El codigo del curso deben contener solo numeros";
                }
                else if (!validarTexto(curso))
                {
                    return "El nombre del curso deben contener solo letras";
                }
                else if (!validarTexto(carrera))
                {
                    return "El nombre del carrera deben contener solo letras";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosCarrera(Carreras curso)
        {
            try
            {
                if (vacioTexto(curso.Codigo) || vacioTexto(curso.Nombre))
                {
                    return "El datos estan incompletos";
                }
                else if (validarKeyWords(curso.Codigo) || validarKeyWords(curso.Nombre))
                {
                    return "El datos son invalidos";
                }
                else if (!validarNumero(curso.Codigo.ToString()))
                {
                    return "El codigo del curso deben contener solo numeros";
                }
                else if (!validarTexto(curso.Nombre))
                {
                    return "El nombre del carrera deben contener solo letras";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosPeriodo(Periodos periodo)
        {
            try
            {
                if (vacioTexto(periodo.Numero) || periodo.FechaInicio == default(DateTime)
                    || periodo.FechaFinal == default(DateTime))
                {
                    return "El datos estan incompletos"; 
                }
                else if (validarKeyWords(periodo.Numero))
                {
                    return "El datos son invalidos";
                }
                else if (!validarCaracteresEspeciales(periodo.Numero))
                {
                    return "El numero del periodo no debe contener caracteres especiales";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosGrupo(string cProfesor, string numero, string cCurso, string cHorario, string cPeriodo)
        {
            try
            {
                if (vacioTexto(cProfesor) || vacioTexto(numero)
                    || vacioTexto(cCurso) || vacioTexto(cHorario) || vacioTexto(cPeriodo))
                {
                    return "El datos estan incompletos";
                }
                else if (validarKeyWords(cProfesor) || validarKeyWords(numero)
                    || validarKeyWords(cCurso) || validarKeyWords(cHorario) || validarKeyWords(cPeriodo))
                {
                    return "El datos son invalidos";
                }
                else if (!validarNumero(cProfesor) || !validarNumero(numero) || !validarNumero(cHorario))
                {
                    return "Los datos: Codigo Profesor, Codigo Horario y numero de grupo no deben contener letras";
                }
                else if (!validarTexto(cCurso))
                {
                    return "Los datos: nombre curso no deben contener numeros";
                }
                else if (!validarCaracteresEspeciales(cPeriodo))
                {
                    return "Los datos: Codigo de Periodo no deben contener caracteres especiales";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosHorarios(Horarios horario)
        {
            try
            {
                if ( vacioTexto(horario.dia)
                    || vacioTexto(horario.Codigo.ToString()) || horario.HoraInicio == default(TimeSpan)
                    || horario.HoraFinal == default(TimeSpan))
                {
                    return "El datos estan incompletos";
                }
                else if ( validarKeyWords(horario.dia)
                    || validarKeyWords(horario.Codigo.ToString()))
                {
                    return "El datos son invalidos";
                }
                
                else if (!validarTexto(horario.dia))
                {
                    return "Los datos: nombre curso no deben contener numeros";
                }
                else if (!validarDia(horario.dia))
                {
                    return "Los datos: dia no es valido";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosMatricula(DateTime FechaMatricula, string Estudiante, string Carrera, string Periodo, string TipoMatricula)
        {
            try
            {
                if (vacioTexto(Estudiante) || vacioTexto(Carrera) || FechaMatricula == default(DateTime)
                    || vacioTexto(Periodo) || vacioTexto(TipoMatricula))
                {
                    return "El datos estan incompletos";
                }
                else if (validarKeyWords(Estudiante) || validarKeyWords(Carrera) || validarKeyWords(Periodo) || validarKeyWords(TipoMatricula))
                {
                    return "El datos son invalidos";
                }
                else if (!validarNumero(Estudiante) || !validarNumero(Carrera))
                {
                    return "Los datos: cedula estudiante y codigo carrera no deben contener letras";
                }
                else if (!validarTexto(TipoMatricula))
                {
                    return "Los datos: tipo de matricula no deben contener numeros";
                }
                else if (!validarCaracteresEspeciales(Periodo))
                {
                    return "Los datos: el periodo no debe contener caracteres especiales";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosMaterias(List<string> materias)
        {
            try
            {
                foreach(string data in materias)
                {
                    string[] temp = data.Split(',');

                    if (vacioTexto(temp[0]) || vacioTexto(temp[1]))
                    {
                        return "El datos estan incompletos";
                    }
                    else if (validarKeyWords(temp[0]) || validarKeyWords(temp[1]))
                    {
                        return "El datos son invalidos";
                    }
                    else if (!validarNumero(temp[0]) || !validarNumero(temp[1]))
                    {
                        return "Los datos: cedula estudiante y codigo carrera no deben contener letras";
                    }
                }

                return "1";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosAsistencia(DateTime Fecha, string Estudiante, string Grupo, string curso, string TipoA)
        {
            try
            {
                if (vacioTexto(Estudiante) || vacioTexto(Estudiante) || Fecha == default(DateTime)
                    || vacioTexto(Grupo) || vacioTexto(curso))
                {
                    return "El datos estan incompletos";
                }
                else if (validarKeyWords(Estudiante) || validarKeyWords(Grupo) || validarKeyWords(curso) || validarKeyWords(TipoA))
                {
                    return "El datos son invalidos";
                }
                else if (!validarNumero(Estudiante) || !validarNumero(Grupo) || !validarNumero(curso))
                {
                    return "Los datos: cedula estudiante, codigo grupo y codigo curso no deben contener letras";
                }
                else if (!validarTexto(TipoA))
                {
                    return "Los datos: tipo de asistencia no deben contener numeros";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarNumero(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                return data.All(char.IsDigit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarCaracteresEspeciales(string data)
        {
            try
            {
                if (Regex.IsMatch(data, "^[a-zA-Z0-9\x20]+$"))
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

        private bool vacioTexto(string data)
        {
            try
            {
                return string.IsNullOrEmpty(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarTexto(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                return data.All(char.IsLetter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarKeyWords(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                data = data.ToUpper();
                if ((data.Contains("SELECT") || data.Equals("SELECT")) || (data.Contains("UPDATE") || data.Equals("UPDATE")) || (data.Contains("INSERT") || data.Equals("INSERT")) || (data.Contains("DELETE")) || data.Equals("DELETE"))
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

        private bool validarDia(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                data = data.ToUpper();
                if ((data.Equals("DOMINGO")) || (data.Equals("LUNES")) || (data.Equals("MARTES")) 
                    || (data.Equals("MIERCOLES")) || (data.Equals("JUEVES")) || (data.Equals("VIERNES"))
                    || (data.Equals("SABADO")))
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

        private bool validarVacioListaTelefonos(List<Telefonos> telefonos)
        {
            try
            {
                foreach (Telefonos tel in telefonos)
                {
                    if (vacioTexto(tel.Telefono))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarListaTelefonos(List<Telefonos> telefonos)
        {
            try
            {
                foreach (Telefonos tel in telefonos)
                {
                    if (!validarNumero(tel.Telefono))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarKeyWordsListaTelefonos(List<Telefonos> telefonos)
        {
            try
            {
                foreach (Telefonos tel in telefonos)
                {
                    if (validarKeyWords(tel.Telefono))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarVacioListaEmails(List<Emails> emails)
        {
            try
            {
                foreach (Emails ema in emails)
                {
                    if (vacioTexto(ema.Email))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarListaEmails(List<Emails> emails)
        {
            try
            {
                String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                foreach (Emails ema in emails)
                {

                    if (!Regex.IsMatch(ema.Email, expresion))
                    {
                        if (Regex.Replace(ema.Email, expresion, String.Empty).Length != 0)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarKeyWordsListaEmails(List<Emails> emails)
        {
            try
            {
                foreach (Emails ema in emails)
                {
                    if (validarKeyWords(ema.Email))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
