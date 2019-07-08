using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido { get { return this.apellido; } set { this.apellido = ValidarNombreApellido(value); } }
        public int DNI { get { return this.dni; } set { this.dni = ValidarDni(this.nacionalidad, value); } }
        public ENacionalidad Nacionalidad { get { return this.nacionalidad; } set { this.nacionalidad = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = ValidarNombreApellido(value); } }
        public string StringToDNI { set { this.dni = ValidarDni(this.nacionalidad, value); } }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor con 3 parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con 4 parametros (dni int)
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor con 4 parametros (dni string)
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Metodo para informar los datos de una persona
        /// </summary>
        /// <returns>informacion de persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\r\n",this.Apellido,this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Valida la nacionalidad con el numero de dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>el numero de dni(int)</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int datoRetorno = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 0 && dato <= 89999999)
                        datoRetorno = dato;
                    else
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                        datoRetorno = dato;
                    else
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    break;
            }
            return datoRetorno;
        }
        /// <summary>
        /// Valida la nacionalidad con el dni (string)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>dni (int)</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoRetorno = 0;
            int intDni;
            string dniFormat = "^[0-9]{8}$";
            Regex regexDni = new Regex(dniFormat);
            if (regexDni.IsMatch(dato))
            {
                intDni = int.Parse(dato);
                datoRetorno = ValidarDni(nacionalidad, intDni);
            }
            else
                throw new DniInvalidoException();
            return datoRetorno;
        }

        /// <summary>
        /// Valida que el nombre o apellido sea correcto atravez de expresiones regulares
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>nombre o apellido</returns>
        private string ValidarNombreApellido(string dato)
        {
            string datoRetorno="";
            string nombreFormat = "[A-Z]{1}[a-z]*$";
            Regex regexNombre = new Regex(nombreFormat);
            if (regexNombre.IsMatch(dato))
                datoRetorno = dato;
            return datoRetorno;
        }
        #endregion
    }
}
