using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Clases
{
    public class Careers
    {
        private Carrera carrera = new Carrera();

        public string CrearCarrera(string codigo, string nombre)
        {
            try
            {
                if (carrera.ConsultarExisteCarrera(codigo) == false)
                {
                    int resp = carrera.CrearCarrera(new Carreras()
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                    });

                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al insertar una carrera"; //404
                    }
                }
                else
                {
                    return "El carrera ya esta registrado"; //409
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Carreras> obtenerCarrera()
        {
            try
            {
               return carrera.obtenerCarreras();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Carreras> obtenerCarrerasFiltrado(string codigo)
        {
            try
            {
                List<Carreras> carreras = new List<Carreras>();
                List<Carreras> data = carrera.obtenerCarreraFiltrado(codigo);
                foreach (Carreras carrera in data)
                {
                    Carreras temp = new Carreras();
                    temp.Codigo = carrera.Codigo;
                    temp.Nombre = carrera.Nombre;
                    temp.idCarrera = carrera.idCarrera;

                    carreras.Add(temp);
                }

                return carreras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarCarrera(string codigo)
        {
            try
            {
                if (carrera.ConsultarExisteCarrera(codigo))
                {
                    int idCarrera = carrera.IDCarreraExistente(codigo);
                    int resp = carrera.EliminarCarrera(idCarrera);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de eliminar carrera.";
                    }
                }
                else
                {
                    return "La carrera no esta registrada"; //404
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarCarrera(string id, string codigo, string nombre)
        {
            try
            {
                if (carrera.ConsultarExisteCarrera(id))
                {
                    int resp = carrera.ActualizarCarrera(id, codigo, nombre);
                    if (resp == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "Error al momento de modificar la carrera";
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
