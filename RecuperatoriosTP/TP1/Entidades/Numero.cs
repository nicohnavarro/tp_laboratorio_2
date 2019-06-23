using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        //Atributos
        private double numero;
        //Propiedades
        private string SetNumero { set { this.numero = ValidarNumero(value); } }
        //Metodos
        /// <summary>
        /// El método BinarioDecimal convertirá un número binario a decimal, en caso
        /// de ser posible.Caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            string retorno;
            double total = 0;

            if (binario.Contains("1") || binario.Contains("0"))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[i] == '1')
                    {
                        total = total + Math.Pow(2, (binario.Length - (i + 1)));
                    }
                }
                retorno = total.ToString();
            }
            else
                retorno = "Valor Invalido";
            
            return retorno;
        }
        /// <summary>
        /// DecimalBinario convertirán un número decimal
        /// a binario, en caso de ser posible.Caso contrario retornará "Valor inválido"
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
        /// <summary>
        /// DecimalBinario convertirán un número decimal
        /// a binario, en caso de ser posible.Caso contrario retornará "Valor inválido"
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            int conversion;
            string retorno = string.Empty;

            if (int.TryParse(numero, out conversion))
            {
                while (conversion > 0)
                {
                    retorno = (conversion % 2).ToString() + retorno;
                    conversion = conversion / 2;
                }
            }
            else
                retorno = "Valor Inválido";

            return retorno;
        }
        //Constructores
        public Numero():this(0)
        {

        }
        public Numero(double numero):this(numero.ToString())
        {

        }
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }
        //Sobrecargas
        public static double operator-(Numero num1,Numero num2)
        {
            return num1.numero - num2.numero;
        }
        public static double operator+(Numero num1,Numero num2)
        {
            return num1.numero + num2.numero;
        }
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        public static double operator /(Numero num1, Numero num2)
        {
            return num2.numero == 0 ? double.MinValue : num1.numero / num2.numero;
        }
        //Validacion
        private double ValidarNumero(string strNumero)
        {
            double parseNumero;
            return (double.TryParse(strNumero, out parseNumero)) ? parseNumero : 0;
        }
    }
}
