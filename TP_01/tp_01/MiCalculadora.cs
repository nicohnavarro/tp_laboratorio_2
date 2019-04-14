using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_01
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Method to operar do the operation selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(txtNumero1.Text==""|| txtNumero2.Text=="" || cmbOperador.Text=="")
            {
                MessageBox.Show("Primero debes Ingresar: \n -Numero 1\n -Numero 2\n -Operador\n", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double resultado;
                resultado=Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
                lblResultado.Text = resultado.ToString();
            }
        }

        /// <summary>
        /// Method to clean all the windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Method to close the windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Method that change the number into binary number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero binario = new Numero();
            string numerobinario;
            numerobinario = binario.DecimalBinario(lblResultado.Text);

            lblResultado.Text = numerobinario;
        }

        /// <summary>
        /// Method to change the binary number into number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroBinario;
            numeroBinario = lblResultado.Text;
            Numero binario = new Numero();
            string numeroDecimal;
            numeroDecimal = binario.BinarioDecimal(numeroBinario);
            lblResultado.Text = numeroDecimal;
        }

        /// <summary>
        /// Remove all information
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Method to operate with strings and calls method operar from Calculadora
        /// </summary>
        /// <param name="numeroStr1">txtbox1</param>
        /// <param name="numeroStr2">txtbox2</param>
        /// <param name="operador">cmbox</param>
        /// <returns>double result</returns>
        private static double Operar(string numeroStr1,string numeroStr2,string operador)
        {
            double resultado;
            Numero numero1 = new Numero(numeroStr1);
            Numero numero2 = new Numero(numeroStr2);
            resultado = Calculadora.Operar(numero1, numero2, operador);
            return resultado;
        }
    }
}
