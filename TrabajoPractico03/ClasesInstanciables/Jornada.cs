using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto writing = new Texto();
            try
            {
                writing.Guardar("Jornada.txt", jornada.ToString());
                retorno = true;
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();

        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public static string Leer()
        {
            string retorno = "";
            Texto reading = new Texto();
            try
            {
                reading.Leer("Jornada.txt", out retorno);
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aAux in j.Alumnos)
            {
                if (aAux == a)
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

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Clase de {0} por {1}\n", this.Clase.ToString(), this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: \r\n");
            foreach(Alumno i in this.Alumnos)
            {
                sb.AppendFormat("{0}\n", i.ToString());
            }
            sb.AppendLine("\r\n");
            return sb.ToString();

        }

    }
}
