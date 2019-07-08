using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Costructores
        public Profesor()
        {

        }

        /// <summary>
        /// Se inicializará a Random sólo en un constructor estatico
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// En el constructor de instancia se inicializará ClasesDelDia 
        /// y se asignarán dos clases al azar al Profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Agrega dos clases distintas a la cola del Profesor
        /// </summary>
        private void _randomClases()
        {
            do
            {
                Universidad.EClases claseAgregar = (Universidad.EClases)random.Next(0, 3);
                if(this!=claseAgregar)
                    this.clasesDelDia.Enqueue(claseAgregar);
            } while (this.clasesDelDia.Count <=1);
            
        }

        /// <summary>
        /// Sobrescribir el método MostrarDatos con todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases claseDelProfesor in i.clasesDelDia)
            {
                if(claseDelProfesor==clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DEL DIA:\n");
            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendFormat("{0}\n", clase.ToString());
                sb.AppendLine("");
            }
            return sb.ToString();
        }

        /// <summary>
        /// ToString hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
