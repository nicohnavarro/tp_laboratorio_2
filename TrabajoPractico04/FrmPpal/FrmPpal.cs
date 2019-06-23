using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        //Atributo
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            //Inicializo 
            this.correo = new Correo();
        }

        /// <summary>
        /// Se agrega el paquete con la direccion y el trackingId proporsionado por el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string direccion = txtDireccion.Text;
            string tracking = mtxtTrackingID.Text;
            Paquete nuevoPaquete = new Paquete(direccion, tracking);
            nuevoPaquete.InformaEstado += paq_InformaEstado;
            try
            {
                this.correo += nuevoPaquete;
            }
            catch (TrackingIdRepetidoException exception)
            {
                MessageBox.Show(exception.Message, "UPS!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
            this.ActualizarEstados();
        }

        /// <summary>
        /// Se informa el estado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {

            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            { // Llamar al método }
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Se Actualiza el estado de todos los listBox
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete paqueteAux in correo.Paquetes)
            {
                switch ((int)paqueteAux.Estado)
                {
                    case 0:
                        lstEstadoIngresado.Items.Add(paqueteAux);
                        break;
                    case 1:
                        lstEstadoEnViaje.Items.Add(paqueteAux);
                        break;
                    case 2:
                        lstEstadoEntregado.Items.Add(paqueteAux);
                        break;
                }
            }
        }

        //Al cerrar el Formulario se llama al metodo del objeto correo para
        //Cerrar los hilos
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /// <summary>
        /// Click en el boton Mostrar Todos llama al metodo
        /// MostrarInformacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra la Informacion de todos los paquetes y de ser posible Guardar en un 
        /// archivo de texto situado en el Escritorio
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lamentablemente NO se pudo Guardar...", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        //ToolStripMenuItem???
        private void mostrarToolStripMenuItem1(object sender, EventArgs e)
        {

            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mostrarToolStripMenuItem1(sender, e);
        }
    }
}
