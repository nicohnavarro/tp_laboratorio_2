using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        //Atributos de la Clase Correo
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        //Propiedad de la Clase Correo
        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        //Constructor
        /// <summary>
        /// Inicializa las listas 
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        //Metodos de la Clase Correo
        /// <summary>
        /// Termina todos los hilos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hiloAux in this.mockPaquetes)
            {
                if(hiloAux.IsAlive)
                    hiloAux.Abort();
            }
        }

        /// <summary>
        /// Muestra todos los datos de la lista de Paquetes
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> paquetesAux = (List<Paquete>)((Correo)elementos).paquetes;
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paqueteAux in paquetesAux)
            {
                sb.AppendFormat("{0} para {1} ({2})\n", paqueteAux.TrackingID, paqueteAux.DireccionEntrega, paqueteAux.Estado);
            }
            return sb.ToString();
        }

        //Sobrecargas
        /// <summary>
        /// Sobrecarga operador +
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="paquete"></param>
        /// <returns>objeto correo con el paquete agregado(de ser posible) y  agregar hilo del metodo del paquete</returns>
        public static Correo operator +(Correo correo, Paquete paquete)
        {
            foreach (Paquete paqueteAux in correo.paquetes)
            {
                if (paqueteAux == paquete)
                {
                    throw new TrackingIdRepetidoException("Cuidado! Tracking ID Coincidentes. Posible Error");
                }
            }
            correo.paquetes.Add(paquete);
            Thread hilo = new Thread(paquete.MockCicloDeVida);
            correo.mockPaquetes.Add(hilo);
            hilo.Start();
            return correo;
        }
    }
}
