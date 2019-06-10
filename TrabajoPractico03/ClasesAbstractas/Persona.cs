using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }
        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }

        public Persona()
        {
            this.apellido = "";
            this.dni = 0;
            this.nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre Completo: {0} {1} \n", this.Nombre, this.Apellido);
            sb.AppendFormat("Nacionalidad: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                default:
                    break;
            }
            return dato;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniAux;
            if (int.TryParse(dato, out dniAux))
            {
                return ValidarDni(nacionalidad, dniAux);
            }
            else
            {
                throw new DniInvalidoException("El DNI es Invalido.");
            }
        }

        private string ValidarNombreApellido(string dato)
        {
            if (string.IsNullOrEmpty(dato))
            {
                dato = " ";
            }
            else
            {
                for (int i = 0; i < dato.Length; i++)
                {
                    if (!char.IsLetter(dato[i]))
                        dato = " ";
                }
            }
            return dato;
        }

    }
}
