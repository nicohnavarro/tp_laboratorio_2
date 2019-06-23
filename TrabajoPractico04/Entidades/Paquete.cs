using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Entidades
{
    public enum EEstado
    {
        Ingresado,EnViaje,Entregado
    }
    public class Paquete:IMostrar<Paquete>
    {

        //Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        //Propiedades
        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }

        //Constructor
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        //Metodos
        public void MockCicloDeVida()
        {
            while(this.Estado!=EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(this.Estado, EventArgs.Empty);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(SqlException)
            { }
        }

        /// <summary>
        /// Muestra la informacion del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Informacion del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}\n",this.TrackingID,this.DireccionEntrega);
        }

        //Sobrecargas
        /// <summary>
        /// Dos Paquetes son igual si su trackingId son iguales
        /// </summary>
        /// <param name="paquete1"></param>
        /// <param name="paquete2"></param>
        /// <returns>true si son iguales</returns>
        public static bool operator ==(Paquete paquete1,Paquete paquete2)
        {
            bool retorno = false;
            if(paquete1.TrackingID==paquete2.TrackingID)
            {
                retorno = true;
                throw new TrackingIdRepetidoException("Lamentablemente hay dos paquetes con el mismo TrackingID");
            }
            return retorno;
        }

        /// <summary>
        /// Dos Paquetes son distintos si su trackingId es Distinto
        /// </summary>
        /// <param name="paquete1"></param>
        /// <param name="paquete2"></param>
        /// <returns>True si son distintos</returns>
        public static bool operator !=(Paquete paquete1, Paquete paquete2)
        {
            return !(paquete1 == paquete2);
        }

        //Sobreescritura
        /// <summary>
        /// Sobreescritura del metodo ToString
        /// </summary>
        /// <returns>Informacion del Paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        //Evento y Delegado
        public event DelegadoEstado InformaEstado;
        public delegate void DelegadoEstado(object sender, EventArgs e);
    }

}
