using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class AsistenciaModel
    {
        public DateTime FechaAsistencia { get; set; }

        public string Estudiante { get; set; }

        public string Grupo { get; set; }

        public string Curso { get; set; }

        public string TipoAsistencia { get; set; }
    }
}