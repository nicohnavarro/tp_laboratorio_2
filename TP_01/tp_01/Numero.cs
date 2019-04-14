using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_01
{
    class Numero
    {
        private double numero;

        /// <summary>
        /// property set
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Method to change binary number into decimal number
        /// </summary>
        /// <param name="binario">string binary number</param>
        /// <returns>decimal number</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno;
            double total = 0;
            for (int i =0; i< binario.Length; i++)
            {
                if (binario[i] == '1')
                {
                    total = total + Math.Pow(2,(binario.Length-(i+1)));
                }
            }
            retorno = total.ToString();
            return retorno;
        }

        /// <summary>
        /// Method to change decimal number into binary number
        /// </summary>
        /// <param name="numero">decimal number</param>
        /// <returns>binary number</returns>
        public string DecimalBinario(double numero)
        {
            string resultado = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        resultado = "0" + resultado;
                    }
                    else
                    {
                        resultado = "1" + resultado;
                    }
                    numero = (int)(numero / 2);
                }
            }
            return resultado;
        }

        /// <summary>
        /// Method to change string binary number into string decimal number
        /// </summary>
        /// <param name="numero">binary number</param>
        /// <returns>string of decimal number</returns>
        public string DecimalBinario(string numero)
        {
            string resultado;
            double numeroFinal;
            Numero auxNumero = new Numero();
            auxNumero.SetNumero=numero;
            numeroFinal = TrabajarConBinarios(auxNumero.numero);
            resultado=DecimalBinario(numeroFinal);
            return resultado;
        }

        /// <summary>
        /// Builder
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Builder with parametre
        /// </summary>
        /// <param name="numero">double number</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Builder with parametre
        /// </summary>
        /// <param name="strNumero">string number</param>
        public Numero(string strNumero)
        {
            this.SetNumero=strNumero;
        }

        /// <summary>
        /// Overload of operator - 
        /// </summary>
        /// <param name="numero1">number one</param>
        /// <param name="numero2">number two</param>
        /// <returns>result of operation</returns>
        public static double operator -(Numero numero1, Numero numero2)
        {
            double resultado;
            resultado=numero1.numero - numero2.numero;
            return resultado;
        }

        /// <summary>
        /// Overload of operator + 
        /// </summary>
        /// <param name="numero1">number one</param>
        /// <param name="numero2">number two</param>
        /// <returns>result of operation</returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            double resultado;
            resultado = numero1.numero + numero2.numero;
            return resultado;
        }

        /// <summary>
        /// Overload of operator *
        /// </summary>
        /// <param name="numero1">number one</param>
        /// <param name="numero2">number two</param>
        /// <returns>result of operation</returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            double resultado;
            resultado = numero1.numero * numero2.numero;
            return resultado;
        }

        /// <summary>
        /// Overload of operator /
        /// </summary>
        /// <param name="numero1">number one</param>
        /// <param name="numero2">number two</param>
        /// <returns>result of operation</returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            double resultado;
            resultado = numero1.numero / numero2.numero;
            return resultado;
        }

        /// <summary>
        /// Private Method to validate a number
        /// </summary>
        /// <param name="strNumero">string of number</param>
        /// <returns>double number</returns>
        private static double ValidarNumero(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero)) { }
            else
            {
                numero = 0;
            }
            return numero;
        }

        /// <summary>
        /// Private method to work with integer and positive numbers
        /// </summary>
        /// <param name="numero">double number</param>
        /// <returns>number ready to work</returns>
        private double TrabajarConBinarios(double numero)
        {
            double numeroAux;
            numeroAux = Math.Abs(numero);
            return numeroAux;
        }

        public double GetNumero()
        {
            return this.numero;
        }

    }
}
