using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    [Serializable]
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }
        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }

        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador
        /// </summary>
        /// <param name="i">index</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i < this.Jornadas.Count && i >= 00)
                    return this.Jornadas[i];
                return null;
            }
            set
            {
                if (i <= 0 && i < this.Jornadas.Count)
                    this.Jornadas[i] = value;
                else if (i == this.Jornadas.Count)
                    this.Jornadas.Add(value);
            }
        }
        #endregion

        #region Constructor
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        public static bool Guardar(Universidad uni)
        {
            string path = String.Format(@"{0}\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Xml<Universidad> miXml = new Xml<Universidad>();
            return miXml.Guardar(path, uni);
        }

        public static Universidad Leer()
        {
            string path = String.Format(@"{0}\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Universidad miUni;
            Xml<Universidad> miXml = new Xml<Universidad>();
            miXml.Leer(path, out miUni);
            return miUni;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in g.Alumnos)
            {
                if(alumno==a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach(Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach(Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach(Profesor profesor in g.Instructores)
            {
                if (profesor != clase)
                    return profesor;
            }

            return null;
        }

        /// <summary>
        /// Se agregarán Alumnos  mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad uni, Alumno a)
        {
            if (uni != a)
                uni.Alumnos.Add(a);
            else if(uni==a)
                throw new AlumnoRepetidoException();
            return uni;
        }
        /// <summary>
        /// Se agregarán Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad uni, Profesor i)
        {
            if (uni != i)
                uni.Instructores.Add(i);
            return uni;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        ///clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        ///toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad uni, EClases clase)
        {
            Profesor miProfesor;
            miProfesor = uni == clase;
            Jornada miJornada = new Jornada(clase, miProfesor);
            foreach (Alumno miAlumno in uni.Alumnos)
            {
                if (miAlumno == clase)
                    miJornada.Alumnos.Add(miAlumno);
            }
            uni.Jornadas.Add(miJornada);
            return uni;
        }
        #endregion
    }
}
