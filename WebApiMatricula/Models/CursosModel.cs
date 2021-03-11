using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class CursosModel
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public int CodigoCarrera { get; set; }
    }
}