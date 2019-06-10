using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Universidad
        {
            public enum EClases
            {
                Programacion,
                Laboratorio,
                Legislacion,
                SPD
            }
            private List<Alumno> alumnos;
            private List<Jornada> jornada;
            private List<Profesor> profesores;

            public Universidad()
            {
                Alumnos = new List<Alumno>();
                Jornadas = new List<Jornada>();
                Profesores = new List<Profesor>();
            }
           
            public List<Alumno> Alumnos
            {
                get { return alumnos; }
                set { alumnos = value; }
            }
          
            public List<Profesor> Profesores
            {
                get { return profesores; }
                set { profesores = value; }
            }
            
            public List<Jornada> Jornadas
            {
                get { return jornada; }
                set { jornada = value; }
            }
            
            public Jornada this[int i]
            {
                get
                {
                    if (i >= 0 && i < Jornadas.Count)
                    {
                        return Jornadas[i];
                    }
                    else
                    {
                        return null;
                    }

                }
                set
                {
                    if (i >= 0 && i < Jornadas.Count)
                    {
                        Jornadas[i] = value;
                    }
                }
            }
          
            private static string MostrarDatos(Universidad uni)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Jornada j in uni.Jornadas)
                {
                    sb.AppendLine(j.ToString());
                }
                foreach (Profesor p in uni.Profesores)
                {
                    sb.AppendFormat("Profesor:\n{0}\n", p.ToString());
                }
                foreach (Alumno a in uni.Alumnos)
                {
                    sb.AppendFormat("Alumno:\n{0}", a.ToString());
                }


                return sb.ToString();
            }
        
            public override string ToString()
            {
                return MostrarDatos(this);
            }
            
            public static bool Guardar(Universidad uni)
            {
                bool retorno = false;
                Xml<Universidad> newSerializer = new Xml<Universidad>();
                try
                {
                    newSerializer.Guardar("Universidad", uni);
                    retorno = true;
                }
                catch (ArchivosException e)
                {
                    throw new ArchivosException(e);
                }

                return retorno;
            }
            
            public static Universidad Leer()
            {

                Xml<Universidad> newSerializer = new Xml<Universidad>();
                Universidad retorno;
                try
                {

                    newSerializer.Leer("Universidad", out retorno);

                }
                catch (ArchivosException e)
                {
                    throw new ArchivosException(e);
                }

                return retorno;
            }

            public static Profesor operator ==(Universidad g, EClases clase)
            {
                foreach (Profesor p in g.Profesores)
                {
                    if (p == clase)
                    {
                        return p;
                    }
                }

                throw new SinProfesorException();
            }
            public static Profesor operator !=(Universidad g, EClases clase)
            {
                foreach (Profesor p in g.Profesores)
                {
                    if (p != clase)
                    {
                        return p;
                    }
                }

                throw new SinProfesorException();
            }
            
            public static bool operator ==(Universidad g, Profesor i)
            {
                bool retorno = false;
                foreach (Profesor p in g.Profesores)
                {
                    if (i == p)
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
            
            public static bool operator ==(Universidad g, Alumno a)
            {
                bool retorno = false;
                foreach (Alumno al in g.Alumnos)
                {
                    if (a == al)
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
            
            public static Universidad operator +(Universidad u, Alumno a)
            {
                if (u != a)
                {
                    u.Alumnos.Add(a);

                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
                return u;
            }
            
            public static Universidad operator +(Universidad u, Profesor i)
            {
                if (u != i)
                {
                    u.Profesores.Add(i);
                }
                return u;
            }
           
            public static Universidad operator +(Universidad g, EClases clase)
            {
                Jornada jornada = new Jornada(clase, g == clase);
                foreach (Alumno alumnoAux in g.Alumnos)
                {
                    if (alumnoAux == clase)
                    {
                        jornada.Alumnos.Add(alumnoAux);
                    }
                }
                g.Jornadas.Add(jornada);

                return g;
            }
        
    }    
}