using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        public Universidad.EClases Clase { get { return this.clase; } set { this.clase = value; } }
        public Profesor Instructor { get { return this.instructor; } set { this.instructor = value; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Se inicializará la lista de alumnos en el constructor por defecto.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase,Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos
        public static bool Guardar(Jornada jornada)
        {
            string path = String.Format(@"{0}\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Texto texto = new Texto();
            return texto.Guardar(path, jornada.ToString());
        }

        public static string Leer()
        {
            string path = String.Format(@"{0}\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            string retorno="";
            Texto texto = new Texto();
            if(texto.Leer(path, out retorno))
                return retorno;
            return "";
        }

        /// <summary>
        /// ToString mostrará todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: \n");
            sb.AppendFormat("CLASE DE {0} POR {1}\n", this.Clase.ToString(), this.Instructor.ToString());
            sb.AppendLine("");
            sb.AppendLine("ALUMNOS: \n");
            foreach (Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
                sb.AppendLine("");
            }

            sb.AppendLine("<-------------------------------------------------------->");
            return sb.ToString();
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            bool retorno = false;
            foreach(Alumno alumnoAux in j.Alumnos)
            {
                if(alumnoAux==a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +,
        /// validando que no estén previamente cargados
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j;
        }
        #endregion
    }
}
