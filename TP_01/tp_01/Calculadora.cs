using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_01
{
    class Calculadora
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
            switch(ValidarOperador(operador))
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
                    {
                        if (numero2.GetNumero() == 0)
                        {
                            resultado = double.MinValue;
                            break;
                        }
                        else
                        {
                            resultado = numero1 / numero2;
                            break;
                        }
                    }
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
            string retorno;
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }
            else
            {
                retorno = "+";
            }
            return retorno;
        }

    }
}
