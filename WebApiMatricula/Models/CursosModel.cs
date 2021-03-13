using Datos;
using Datos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class CursosModel
    {
        private Carrera carreras = new Carrera();

        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string NombreCarrera { get; set; }

        public string obtenerNombreCarrera(int idCarrera)
        {
            try
            {
                string nombreCarrera = carreras.obtenerNombreCarrera(idCarrera);
                if (!nombreCarrera.Equals("0"))
                {
                    return nombreCarrera;
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