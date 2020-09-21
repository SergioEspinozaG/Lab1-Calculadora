using Newtonsoft.Json;
using ProcesadorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            while (true)
            {
                var inputData = ImprimirMenu();

                Calculadora(inputData).Wait();

                Console.ReadLine();
            }

        }

        public static Operacion ImprimirMenu() {

            var data = new Operacion();

            Console.WriteLine("------------------------------------");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|             Calculadora          |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("***Seleccione el tipo de Operacion***");
            Console.WriteLine("1- Suma");
            Console.WriteLine("2- Resta");
            Console.WriteLine("3- Division");
            Console.WriteLine("4- Multiplicacion");
            var numeroOperacion = Convert.ToInt32(Console.ReadLine());
            data.tipoOperacion = ObtenerTipoOperacion(numeroOperacion);

            Console.WriteLine("***Ingrese el primer valor***");
            data.valor1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("***Ingrese el segundo valor***");
            data.valor2 = Convert.ToInt32(Console.ReadLine());

            return data;
        }


        public static string ObtenerTipoOperacion(int numeroOperacion) {
            var operacionResult = "";
            switch (numeroOperacion)
            {
                case 1: operacionResult = OperacionesConst.Suma;
                    break;
                case 2: operacionResult = OperacionesConst.Resta;
                    break;
                case 3: operacionResult = OperacionesConst.Division;
                    break;
                case 4: operacionResult = OperacionesConst.Multiplicacion;
                    break;
            }
            return operacionResult;
        }

        public static async Task Calculadora(Operacion data) {

            try
            {
                // Serialize our concrete class into a JSON String
                var stringData = await Task.Run(() => JsonConvert.SerializeObject(data));

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringData, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = httpClient.PostAsync("http://localhost:2190/api/ProcesadorAritmetico", httpContent).Result;

                    if (httpResponse.Content != null)
                    {
                        var result = await httpResponse.Content.ReadAsStringAsync();
                        Console.WriteLine("Resultado : " + result);
                    }
                    else {
                        Console.WriteLine("Error al ejecutar la operacion.");
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al realizar la operacion", e);
            }
        }
    }
}
