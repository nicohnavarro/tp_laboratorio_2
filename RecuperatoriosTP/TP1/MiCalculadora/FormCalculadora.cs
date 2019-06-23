using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        public FormCalculadora()
        {
            InitializeComponent();
        }

        /*
        public LaCalculadora()
        {

        }
        */

        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Opera entre numeros y operador
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(string numero1,string numero2,string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Evento click para realizar la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtNumero1.Text;
            string num2 = txtNumero2.Text;
            string operador = cmbOperador.Text.ToString();
            lblResultado.Text = Operar(num1, num2, operador).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte a binario si puede
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero(lblResultado.Text);
            string numResultado = lblResultado.Text;
            lblResultado.Text=resultado.DecimalBinario(numResultado);
        }

        /// <summary>
        /// Convierte a decimal si el numero es binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero(lblResultado.Text);
            string numResultado = lblResultado.Text;
            if (EsBinario(numResultado))
            {
                lblResultado.Text = resultado.BinarioDecimal(numResultado);
            }
        }

        /// <summary>
        /// Metodo para saber si el string es Binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>true si es binario false si no</returns>
        private bool EsBinario(string numero)
        {
            bool retorno = false;
            foreach(char i in numero)
            {
                if (i == '1' || i == '0')
                    retorno = true;
                else
                    retorno = false;
            }
            return retorno;
        }
    }
}
