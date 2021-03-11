using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class UsuarioModel
    {

        public string NumeroIdentificacion { get; set; }

        public string TipoIdentificacion { get; set; }

        public string TipoUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNac { get; set; }

        public List<TelefonoModel> Telefonos { get; set; }

        public List<EmailModel> Emails { get; set; }
    }
}