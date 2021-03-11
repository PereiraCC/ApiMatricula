using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMatricula.Models
{
    public class PeriodosModel
    {
        public string Numero { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public bool activo { get; set; }
    }
}