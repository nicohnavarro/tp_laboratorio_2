using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        //Metodo
        /// <summary>
        /// Realiza la operacion entre dos numero pasados por parametro con el operador que corresponda
        /// </summary>
        /// <param name="num1">Numero1</param>
        /// <param name="num2">Numero2</param>
        /// <param name="operador">Operador</param>
        /// <returns>Resultado de la Operacion</returns>
        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double resultado=0;
            switch(ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        //Validar
        /// <summary>
        /// Valida el operador
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Si corresponde devuelve el operador de caso contrario +</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno;
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                retorno = operador;
            else
                retorno = "+";
            return retorno;
        }
    }
}
