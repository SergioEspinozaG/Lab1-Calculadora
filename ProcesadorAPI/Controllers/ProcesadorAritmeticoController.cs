using Microsoft.Ajax.Utilities;
using ProcesadorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace ProcesadorAPI.Controllers
{
    public class ProcesadorAritmeticoController : ApiController
    {
        public IHttpActionResult Post(Operacion operacionData) {

            if (operacionData.tipoOperacion.IsNullOrWhiteSpace()) {
                throw new Exception("Error no se especifico la operacion a realizar");
            }

            if (operacionData.valor1 == null) {
                operacionData.valor1 = 0;
            }

            if (operacionData.valor2 == null)
            {
                operacionData.valor2 = 0;
            }

            operacionData.tipoOperacion.ToLower();

            var result = Calculador.Procesar(operacionData);

            return Content(HttpStatusCode.OK, result);
        }
    }
}
