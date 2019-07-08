using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructor
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor con datos
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Método protegido y virtual MostrarDatos 
        /// </summary>
        /// <returns>retornará todos los datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO: {0}\n", this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Metodo para saber si dos Universitarios son iguales
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo
        /// y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                retorno = true;
            return retorno;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        ///  Método protegido y abstracto ParticiparEnClase
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
