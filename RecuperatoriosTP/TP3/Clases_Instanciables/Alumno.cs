using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Costructores
        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\r\n", this.estadoCuenta);
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator==(Alumno a,Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                retorno = true;
            return retorno;
        }
        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma != clase)
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASES DE: {0}\n", this.claseQueToma.ToString());
        }
        /// <summary>
        /// ToString hará públicos los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
