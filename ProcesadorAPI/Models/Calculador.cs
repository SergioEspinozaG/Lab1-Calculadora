using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcesadorAPI.Models
{
    public class Calculador
    {
        public static double Procesar(Operacion operacion) {

            switch (operacion.tipoOperacion)
            {
                case OperacionesConst.Suma: return operacion.valor1.Value + operacion.valor2.Value;
                case OperacionesConst.Resta: return operacion.valor1.Value - operacion.valor2.Value;
                case OperacionesConst.Multiplicacion: return operacion.valor1.Value * operacion.valor2.Value;
                case OperacionesConst.Division: return operacion.valor1.Value / operacion.valor2.Value;
                default: return 0;
            }
        }
    }
}