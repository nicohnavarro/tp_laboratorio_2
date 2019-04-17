using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Method to make an operation
        /// </summary>
        /// <param name="numero1">number one</param>
        /// <param name="numero2">number two</param>
        /// <param name="operador">operator</param>
        /// <returns>result of operation</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    if((numero1 / numero2).ToString() == (0.0 / 0).ToString())
                    {
                        resultado = double.MinValue;
                    }
                    else
                    {
                        resultado = numero1 / numero2;
                    }
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Method to validate an operation
        /// </summary>
        /// <param name="operador">string of operator</param>
        /// <returns>possible operator</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno="+";
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }
            return retorno;
        }
    }
}
