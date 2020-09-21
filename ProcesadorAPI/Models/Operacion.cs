using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcesadorAPI.Models
{
    public class Operacion
    {
        public string tipoOperacion { get; set; }

        public double? valor1 { get; set; }

        public double? valor2 { get; set; }

        public double resultado { get; set; }
    }
}