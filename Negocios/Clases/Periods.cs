using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Clases
{
    public class Periods
    {
        private Periodo periodo = new Periodo();

        public string CrearPeriodo(string numero, DateTime FechaInicio, DateTime FechaFinal, bool activo)
        {
            try
            {
                if (periodo.ConsultarExistePeriodo(numero) == false)
                {
                    int resp = periodo.CrearPeriodo(new Periodos()
                    {
                        Numero = numero,
                        FechaInicio = FechaInicio,
                        FechaFinal = FechaFinal,
                        activo = activo
                    });

                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al insertar un periodo"; //404
                    }
                }
                else
                {
                    return "El periodo ya esta registrado"; //409
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Periodos> obtenerPeriodo()
        {
            try
            {
                return periodo.obtenerPeriodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Periodos> obtenerPeriodosFiltrado(string numero)
        {
            try
            {
                List<Periodos> periodos = new List<Periodos>();
                List<Periodos> data = periodo.obtenerPeriodosFiltrado(numero);
                foreach (Periodos periodo in data)
                {
                    Periodos temp = new Periodos();
                    temp.Numero = periodo.Numero;
                    temp.FechaInicio = periodo.FechaInicio;
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

        public string eliminarPeriodo(string numero)
        {
            try
            {
                if (periodo.ConsultarExistePeriodo(numero))
                {
                    int idPeriodo = periodo.IDPeriodoExistente(numero);
                    int resp = periodo.EliminarPeriodo(idPeriodo);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de eliminar periodo.";
                    }
                }
                else
                {
                    return "El periodo no esta registrado"; //404
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarPeriodos(string numeroactal, string numero, DateTime FechaInicio, DateTime FechaFinal, bool activo)
        {
            try
            {
                if (periodo.ConsultarExistePeriodo(numero))
                {
                    int idPeriodo = periodo.IDPeriodoExistente(numeroactal);
                    int resp = periodo.ActualizarPeriodo(idPeriodo, numero, FechaInicio, FechaFinal, activo);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de modificar el periodo";
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
    }
}
