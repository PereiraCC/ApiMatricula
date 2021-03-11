using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class TelefonoModel
    {

        public string telefono { get; set; }

        public int idUsuario { get; set; }

        public List<TelefonoModel> obtenerTelefonos(List<Telefonos> telefonos)
        {
            try
            {
                List<TelefonoModel> telefono = new List<TelefonoModel>();
                foreach (Telefonos tel in telefonos)
                {
                    TelefonoModel temp = new TelefonoModel();
                    temp.telefono = tel.Telefono;
                    temp.idUsuario = tel.idUsuario;

                    telefono.Add(temp);
                }

                return telefono;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}